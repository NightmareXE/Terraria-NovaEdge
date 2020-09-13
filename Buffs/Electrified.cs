using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Buffs
{
    public class Electrified : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Electrified");
            Description.SetDefault("Rapidly losing life");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            
        }
        public override void Update(NPC npc, ref int BuffIndex){
            npc.lifeRegen = -32;    //OG electrifed does only -4 when target is not moving ,
                                    
            if(npc.velocity.X == 0 && npc.velocity.Y == 0){
                npc.lifeRegen = -8;
            }
            
        }
        
    }
    
    
}