using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace NovaEdge.Items.Accessories{
    public class GoldenMonacle : ModItem{
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("Immunity to Ichor");
        }
        public override void SetDefaults(){
            item.rare= 4;
            item.value = 820000;
            item.accessory = true;
            item.width = 30;
            item.height = 34;


        }
        public override void UpdateAccessory(Player player , bool hideVisual){
            player.buffImmune[BuffID.Ichor] = true;

        } 
        //ADD RECIPE LATER
    }
}