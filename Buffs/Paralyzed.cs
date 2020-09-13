using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Buffs
{
    public class Paralyzed : ModBuff
    {

        public override void SetDefaults()
        {
            DisplayName.SetDefault("Paralyzed");
            Description.SetDefault("You are unable to move!");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;

        }
        public override void Update(NPC npc , ref int BuffIndex)
        {
           
            npc.velocity *= 0;
            npc.position = npc.oldPosition;
            npc.lifeRegen = 0;
        }
    }
}