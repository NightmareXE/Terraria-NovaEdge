/*using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using NovaEdge.NPCs;
using NovaEdge.Items.Ammo;
using System.Collections.Generic;
using System.IO;
using Terraria.Utilities;

namespace NovaEdge.Items.VanillaChanges{
    public class NovaEdgeBuff : GlobalBuff{
        public override void Update(int type , Player player , ref int buffIndex){
            switch(buffIndex){
                case BuffID.OnFire:
                    player.GetModPlayer<NovaEdgePlayer>().burn = true;
                    break;
                case BuffID.Poisoned:
                    if(player.statLife < (int)(player.statLifeMax * 0.4f) ){
                        player.lifeRegen = -12;
                        
                    }
                    else {
                        player.lifeRegen -= (int)(player.lifeRegen * 0.08);
                    }
                    break;
                case BuffID.Frostburn:
                    player.GetModPlayer<NovaEdgePlayer>().frostburn = true;
                    player.moveSpeed -= 0.1f;
                    break;
                case BuffID.Venom:

                    player.moveSpeed -= 0.15f;
                    break;
                case BuffID.CursedInferno:
                    
                    player.GetModPlayer<NovaEdgePlayer>().cursedBurn = true;
                    if(player.wet){
                        player.lifeRegen -= 12;
                    }
                    break;
                case BuffID.ShadowFlame:
                    player.lifeRegen += 2;
                    if(!Main.dayTime){
                        player.lifeRegen -= 6;
                    }
                    player.statDefense -= 10;
                    if(player.statDefense < 0){
                        player.statDefense = 0;
                    }
                    break;
                    
            }
        }
        public override void Update(int type , NPC npc , ref int buffIndex){
            switch(type){
                case BuffID.OnFire:
                    npc.GetGlobalNPC<NovaEdgeGlobalNPC>().burnNPC = true;
                    break;
                case BuffID.Poisoned:
                    if(npc.life < (int)(npc.lifeMax * 0.4f) ){
                        npc.lifeRegen = -12;
                        
                    }
                    else {
                        npc.lifeRegen -= (int)(npc.lifeRegen * 0.08);
                    }
                    break;
                case BuffID.Frostburn:
                    npc.GetGlobalNPC<NovaEdgeGlobalNPC>().frostburnNPC = true;
                    npc.velocity *= 0.85f;
                    break;
                case BuffID.Venom:
                    npc.velocity *= 0.9f;
                    break; 
                case BuffID.CursedInferno:
                    
                    npc.GetGlobalNPC<NovaEdgeGlobalNPC>().cursedBurnNPC = true;
                    if(npc.wet){
                        npc.lifeRegen -= 12;
                    }
                    break;
                case BuffID.ShadowFlame:
                    npc.lifeRegen += 2;
                    if(!Main.dayTime){
                        npc.lifeRegen -= 12;
                    }
                    npc.defense -= 10;
                   
                    break;
                    
            }
        }
    }
}*/