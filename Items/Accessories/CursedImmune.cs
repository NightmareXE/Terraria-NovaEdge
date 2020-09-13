using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace NovaEdge.Items.Accessories{
    public class CursedImmune : ModItem{
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("Immunity to Cursed Inferno");
        }
        public override void SetDefaults(){ //ADD DETAILS LATER
            item.rare= 4;
            item.value = 820000;
            item.accessory = true;
            item.width = 30;
            item.height = 34;


        }
        public override void UpdateAccessory(Player player , bool hideVisual){
            player.buffImmune[BuffID.CursedInferno] = true;

        }
        //ADD RECIPE LATER
    }
}