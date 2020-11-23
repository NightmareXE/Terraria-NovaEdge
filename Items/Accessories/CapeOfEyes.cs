using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NovaEdge.Items.Accessories
{
    public class CapeOfEyes : ModItem
    {
        //public override string Texture => "Terraria/Item_" + ItemID.WormFood;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cape of Eyes");
            Tooltip.SetDefault("Grants 'Corrupted Eyes' buff for 5 seconds \nIf the buff is removed forcefully a 10 seconds cooldown applies");
        }
        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.rare = ItemRarityID.Blue;
            item.accessory = true;


        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<NovaEdgePlayer>().capeOfEyesAcc = true;
        }
    }
}
