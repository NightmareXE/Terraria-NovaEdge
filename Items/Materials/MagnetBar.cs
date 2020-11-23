using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace NovaEdge.Items.Materials
{
    public class MagnetBar : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.LeadBar;
        public override void SetDefaults()
        {
            item.width = item.height = 32;
            item.maxStack = 999;
            item.material = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useTime = 20;
            item.useAnimation = 20;
        }
        
    }
}
