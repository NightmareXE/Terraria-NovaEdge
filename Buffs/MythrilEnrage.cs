using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using NovaEdge.NPCs;

namespace NovaEdge.Buffs{
    public class MythrilGuard : ModBuff{
        
        public override void SetDefaults(){
            DisplayName.SetDefault("Mythril Guard");
            Description.SetDefault("The bizzare metal empowers the bearer on being damaged");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player , ref int buffIndex){
            player.allDamage += 0.05f;  
        }
       
    }
}