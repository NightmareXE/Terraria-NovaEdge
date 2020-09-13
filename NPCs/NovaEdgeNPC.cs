using Microsoft.Xna.Framework;
using Terraria;
using System;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using NovaEdge.Projectiles;
using NovaEdge.Buffs;

namespace NovaEdge.NPCs {
    public class NovaEdgeGlobalNPC : GlobalNPC{

        public override bool InstancePerEntity => true;
        public bool fatalWounds;
        public bool decay;
        public bool deflourished;
        public bool burnNPC;
        public bool cursedBurnNPC;
        public bool frostburnNPC;
        public bool Manipulated;
        public bool Moolah;
        public bool venom;
        public int MoolahTimer;
        public bool sharpshooter;
        
        

        public override void ResetEffects(NPC npc){
            fatalWounds = false;
            decay = false;
            deflourished = false;
            burnNPC = false;
            cursedBurnNPC = false;
            frostburnNPC = false;
            Manipulated = false;
            Moolah = false;
            venom = false;
            MoolahTimer = 0;
            sharpshooter = false;
            


        }
        public override void SetDefaults(NPC npc){
             if(npc.boss){
                npc.buffImmune[BuffID.Midas] = true;
                    
            }
        }
       
       
       
        public override void ModifyHitByItem(NPC npc , Player player , Item item , ref int damage , ref float knockback , ref bool crit)
        {
            if(Moolah){
                if(MoolahTimer == 30){
                    MoolahTimer = 0;
                     int coins = damage/5;
               
                    if(Main.hardMode && coins < 100){
                        coins = 100;
                    }
                    else if(NPC.downedMoonlord && coins < 500){
                        coins = 500;
                    }
                    else if (coins > 25 && !Main.hardMode){
                        coins = 25;
                    }
                    string type = "CopperCoin";
                    Item.NewItem(npc.getRect(), mod.ItemType(type), coins);
                    
                    
                   
                }
            }
            if(burnNPC){
                damage = (int)(damage * 1.05f);
            }
            if(frostburnNPC){
                damage = (int)(damage * 1.1f);
            }
            if(cursedBurnNPC){
                damage = (int)(damage * 1.15f);
            }
            
            int index = npc.FindBuffIndex(BuffType<Decay>());
            if(decay){
                if(index > -1){
                    int timeDecay = npc.buffTime[index];
                     if(timeDecay <= 600){    //I HATE MYSELF FOR THIS HORRIBLE IF LOOP CHAIN
                    damage = (int)(damage * 1.05);
                        if(timeDecay <= 480){
                         damage = (int)(damage * 1.1);
                             if(timeDecay <= 300){
                             damage = (int)(damage * 1.2);
                                if(timeDecay <= 120){
                                damage = (int)(damage * 1.3);
                                 
                                } 
                            } 
                        }
                    }
                }
            }
        

            
            if(deflourished){
                int index1 = npc.FindBuffIndex(BuffType<Deflourished>());
                if(index > -1){
                    int timeDeflourished = npc.buffTime[index];
                    if(timeDeflourished <= 180){
                    damage = (int)(damage * 1.1f);
                        if(timeDeflourished <= 120){
                            damage = (int)(damage * 1.2f);
                            if(timeDeflourished <= 60){
                                damage = (int)(damage * 1.3f);
                            }
                        }
                    }   

                }

                
            }
           
        }
         public override void ModifyHitByProjectile(NPC npc , Projectile projectile , ref int damage , ref float knockback , ref bool crit , ref int hitDirection){
            if(projectile.ranged /* || projectile.type == 440 || projectile.type == 459*/){
                for(int k = 0; k < 255; k++){
                    if(Main.player[k].active ){
                        
                        float distanceCap = 640f;
                        float distanceCap1 = 704f;
                        float distanceCap2 = 768f;
                        float distanceCap3 = 832f;
                        float MaxDistance = 960f;
                        if (sharpshooter)
                        {
                            distanceCap = 800f;
                            distanceCap1 = 864f;
                            distanceCap2 = 928f;
                            distanceCap3 = 992f;
                            MaxDistance = 1056f;
                        }
                        float distance = Vector2.Distance(Main.player[k].Center , projectile.Center);
                        if(distance > distanceCap){
                            int originalDMG = damage;
                            damage -= (int)(originalDMG * 0.1);
                            if(distance > distanceCap1){
                                damage -= (int)(originalDMG * 0.1);
                                if(distance > distanceCap2){
                                    damage -= (int)(originalDMG * 0.1);
                                    if(distance > distanceCap3){
                                        damage -= (int)(originalDMG * 0.1);   
                            }
                                }
                                    }
                            if(distance > MaxDistance){
                                distance = 960f;
                            }
                        }
                    }
                }
            }
            
            if(projectile.type == ProjectileID.ChlorophyteBullet){
                damage -= damage/4;
            }
            if(projectile.type == ProjectileID.CrystalShard){
                damage /= 5;
            }
            for(int v = 0; v < 255; v++){
            if(npc.HasBuff(BuffType<OpenWounds>())  && npc.type != NPCID.TargetDummy && projectile.type == ProjectileType<Leech>()){
                int Heal = damage/20;
                Main.player[v].statLife += Heal;
                Main.player[v].HealEffect(Heal , true);
            }
            }
           

        }
        //MANIPULATON TEST
        public override void AI(NPC npc){
            if(npc.active /* &&   !Main.npc[a].dontTakeDamage && */ &&  npc.type == NPCID.Mimic && Manipulated){
                
                npc.friendly = true;
                npc.damage = 250;
                    
            }
        
        }
        public override void UpdateLifeRegen(NPC npc , ref int damagePerTick){
            if(fatalWounds){
                if(npc.lifeRegen > 0){
                    npc.lifeRegen = 0;
                }
                int latchedCount = 0;
                for(int i = 0; i < 1000; i++){
                    Projectile sword = Main.projectile[i];
                   
                    if(sword.active && sword.type == ProjectileType<FleshRipperProj>() || sword.type == ProjectileType<Leech>() && sword.ai[0] == 1f && sword.ai[1] == npc.whoAmI)
                    {
                        latchedCount++;
                        npc.lifeRegen -= latchedCount * 5;
                        damagePerTick = 5;

                    }
                   
               
            }
            /*for(int q = 0; q < Terraria.NPC.maxBuffs; q++){
                if(npc.buffType[q] == BuffID.Poisoned){
                    if(npc.life < (int)(npc.lifeMax * 0.4f)){
                        damagePerTick = 2;
                        npc.lifeRegen = -12;
                    }
                    else if(npc.)
            }
            }*/
            
            for(int o = 0;o <Terraria.NPC.maxBuffs; o++){
                
                switch(npc.buffType[o]){
                    case BuffID.OnFire:
                        npc.lifeRegen -= 6;
                        break;
                    case BuffID.Poisoned:
                        if(npc.life < (int)(npc.lifeMax * 0.4f)){
                            npc.lifeRegen -= 12;
                            damagePerTick = 2;
                        }
                        
                        break;
                    case BuffID.Frostburn:
                        frostburnNPC = true;
                        break;
                    case BuffID.Venom:
                        venom = true;
                        break;
                    case BuffID.CursedInferno:
                        if(npc.wet){
                            npc.lifeRegen -= 12;
                        }
                        cursedBurnNPC = true;
                        break;
                    case 153:
                        npc.lifeRegen += 2;
                        if(!Main.dayTime){
                            npc.lifeRegen -= 17;
                        }
                        npc.defense -= 10;
                        break;
                    case BuffID.Midas:
                        Moolah = true;
                        MoolahTimer++;
                        break;
                    
                        


                }
            }
        }

    }
    }
}
