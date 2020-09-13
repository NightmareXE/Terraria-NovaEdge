using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;


namespace NovaEdge.Buffs
{
    public class Poggers : ModBuff
    {
        public override void SetDefaults(){
            DisplayName.SetDefault("POG");
            Description.SetDefault("Poggers \nGives a ech increase to all stats");
             Main.debuff[Type] = false;
        }
        public override void Update(Player player , ref int buffIndex){
            player.statDefense += 3;
            player.rangedCrit += 3;
            player.meleeCrit += 3;
            player.magicCrit += 3;
            player.allDamage += 7.5f;
            player.moveSpeed += 30;
            
        }
    }
}