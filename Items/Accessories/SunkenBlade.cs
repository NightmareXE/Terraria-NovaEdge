using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Items.Accessories
{
    public class SunkenBlade : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.WarriorEmblem;
        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.accessory = true;
            item.rare = ItemRarityID.Orange;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<NovaEdgePlayer>().sunkenBlade = true;
        }
    }
}
