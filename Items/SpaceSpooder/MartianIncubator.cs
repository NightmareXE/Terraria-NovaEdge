using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Items.SpaceSpooder{
    public class MartianIncubator : ModItem{
        public override string Texture => "Terraria/Item_4";

        public override void SetDefaults(){
            item.width = item.height = 32;
            item.accessory = true;
            item.rare = ItemRarityID.Yellow;
            item.value = 13000000;
        }
        public override void UpdateAccessory(Player player, bool hideVisual){
            
        }
    }
}