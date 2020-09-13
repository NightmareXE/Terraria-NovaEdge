using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Buffs
{
    public class Rooted : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rooted");
            Description.SetDefault("You are unable to move!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;

        }
        public override void Update(Player player , ref int BuffIndex)
        {
           
            player.velocity *= 0;
            player.position = player.oldPosition;
            for(int i = 0; i < 1; i++){
            Dust dust = Dust.NewDustDirect(player.position , player.width , player.height , 6);
            }
            //npc.lifeRegen = 0;
        }
    }
}