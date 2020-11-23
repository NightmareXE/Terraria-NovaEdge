using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace NovaEdge.Items.Accessories
{
    public class SteelEssence : ModItem{
        public override string Texture => "Terraria/Item_442";
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("Work in progress");
        }

        public override void SetDefaults(){
            item.width = item.height = 40;
            item.rare = ItemRarityID.LightRed;
            item.accessory = true;

        }
        public override void UpdateAccessory(Player player , bool hideVisual){
            player.GetModPlayer<NovaEdgePlayer>().steelDefense = true;
            
        } 
    }
}