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
        public bool testMinion;
        public int timer = 0;
        public int maxStealth = 100;
        public bool isStealthFull;
        public int stealth = 0;
        public bool stealthStrikeDone;
        public bool mythrilEnrage;
        public int mythrilEnrageLVL;
        public bool cursedBurn;
        public bool burn;
        public bool frostburn;  
        public bool livelyWood;     
        public bool steelDefense;
        public bool martianIncubator;  //i should sort these and half of them are unused


        


        public override void ResetEffects(){
            testMinion = false;
            isStealthFull = false;
            stealth = 0;
            maxStealth = 99;
            stealthStrikeDone = false;
            mythrilEnrage = false;
            cursedBurn = false;
            burn = false;
            frostburn = false;
            livelyWood = false;
            steelDefense = false;
            martianIncubator = false;
            
            

        }
        public virtual void Stealth(Player player){ //ATTEMPT AT MAKING STEALTH , CURRENTLY POST PONED FOR LATER ECH
        stealth += 3;
            if(stealth >= maxStealth){
                isStealthFull = true;
                if(stealthStrikeDone){
                    isStealthFull = false;
                }
            }
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