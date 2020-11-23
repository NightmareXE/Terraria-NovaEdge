using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Items.Materials{
    public class MagicalSprout : ModItem{
        public override void SetDefaults(){
            item.width = 20;
            item.height = 20;
            item.rare = ItemRarityID.Blue;
            item.value = 1000;
            
        }
    }
}