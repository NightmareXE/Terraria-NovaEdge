using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using NovaEdge.Buffs;
using System.Collections.Generic;
using System.IO;
using Terraria.Utilities;

namespace NovaEdge {
    public class NovaEdgePlayer : ModPlayer{
        public bool walkerMinion;
        public int timer = 0;
        public int maxStealth = 100;
        public bool isStealthFull;
       
        public bool stealthStrikeDone;
        public bool mythrilEnrage;
        public bool capeOfEyes;
        public bool capeOfEyesAcc;
        public bool spiritBladeMinion;
        public bool livingRoseSummon;
        public bool gigashark;
        public int gigasharkDmgLimit;
        public int mythrilEnrageLVL;
        public bool cursedBurn;
        public bool sunkenBlade;
        public bool burn;
        public bool frostburn;  
        public bool livelyWood;     
        public bool steelDefense;
        public bool martianIncubator;  //i should sort these and half of them are unused

        //Asssassin stuff
        


        


        public override void ResetEffects(){
            walkerMinion = false;
            isStealthFull = false;
            
            gigasharkDmgLimit = 750;
            capeOfEyes = false;
            capeOfEyesAcc = false;
            gigashark = false;
            maxStealth = 99;
            stealthStrikeDone = false;
            mythrilEnrage = false;
            cursedBurn = false;
            burn = false;
            frostburn = false;
            livelyWood = false;
            steelDefense = false;
            martianIncubator = false;
            sunkenBlade = false;
            spiritBladeMinion = false;
            livingRoseSummon = false;
            //assassin stuff
           
         

        }



        /*public override void Update(Player player){
            if(steelDefense){
                int index = player.FindBuffIndex(BuffType<Buffs.SteelDefense>());
                if(index > -1){
                    if(player.buffTime[index] == 3600){
                        player.AddBuff(BuffType<Buffs.SteelDefense>() , 300);
                    }
                }
            }
        }*/
        int gigasharkDmg = 0;
        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (gigashark)
            {
                gigasharkDmg += damage;
                if (gigasharkDmg > gigasharkDmgLimit && player.ownedProjectileCounts[ModContent.ProjectileType<Projectiles.GhostSharkcs>()] < 2)
                {
                    Projectile.NewProjectile(player.Center, Vector2.Zero, ModContent.ProjectileType<Projectiles.GhostSharkcs>(), 0, 0f, player.whoAmI);
                    gigasharkDmg = 0;
                }
            }
        }
        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (sunkenBlade)
            {
                player.armorPenetration += 10;
                if(target.life < target.lifeMax / 3)
                {
                    player.armorPenetration += 5;
                }
            }
            
        }
        public override void PostHurt(bool pvp , bool quiit , double damage , int hitDirection , bool crit){
            if(mythrilEnrage){
                player.AddBuff(BuffType<MythrilGuard>() , 600);
            }

        }
        public override void ModifyHitByNPC(NPC npc , ref int damage , ref bool crit){
            if(cursedBurn){
                damage =(int)(damage * 1.15f);
            }
            if(martianIncubator && damage > 30){
                NPC.NewNPC((int)(npc.Center.X + 160f) , (int)npc.Center.Y , NPCType<NPCs.SpaceSpooder.MechEgg>());
                NPC.NewNPC((int)(npc.Center.X - 160f) , (int)npc.Center.Y , NPCType<NPCs.SpaceSpooder.MechEgg>());

            }
            if (capeOfEyesAcc)
            {
                if (player.HasBuff(ModContent.BuffType<Buffs.CorruptedEyes>()))
                {
                    player.ClearBuff(BuffType<Buffs.CorruptedEyes>());
                }
                player.AddBuff(ModContent.BuffType<Buffs.CorruptedEyes>(), 300);
                
            }
            if (capeOfEyes)
            {
                if(damage < 200)
                {
                    damage -= (int)(damage * 0.1f);
                }
                else if(damage > 200 && damage < 450)
                {
                    int quotient = damage / 16;
                    int OnePercentDMG = damage / 100;
                    damage -= quotient * OnePercentDMG;
                }
                else if(damage > 450)
                {
                    damage *= (int)0.75f;
                }
            }
        }
        public override void ModifyHitNPC(Item item , NPC target , ref int damage , ref float knockback , ref bool crit){
            if(livelyWood && Main.rand.NextBool(4)){
                target.AddBuff(186 , 300); //165 is Dryads Bane lel
            }
        }
        public override void ModifyHitNPCWithProj(Projectile proj , NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection){
            if(livelyWood && Main.rand.NextBool(4)){
                target.AddBuff(186 , 300); //165 is Dryads Bane lel
            }
        }
       
        
        
    }
    
}