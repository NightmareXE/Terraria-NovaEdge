using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class ElectroManiacsHelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ElectroManiac's Head");
            Tooltip.SetDefault("Great for drawing!");
        }
        public override void SetDefaults()
        {
            item.vanity = true;
            item.rare = ItemRarityID.Blue;
            item.width = 40;
            item.height = 40;
            item.value = 1200;
        }
    }
}