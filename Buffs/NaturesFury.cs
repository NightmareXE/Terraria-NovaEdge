using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Buffs
{
    public class NaturesFury : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("NaturesFury");
            Description.SetDefault("Even nature has rules...");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            
        }
        public override void Update(Player player, ref int BuffIndex){
            player.lifeRegen = -32;    //OG electrifed does only -4 when target is not moving ,
                                    
            
            
        }
        
    }
    
    
}