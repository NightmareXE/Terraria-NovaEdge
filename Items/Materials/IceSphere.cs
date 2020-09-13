using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Items.Materials{
    public class IceSphere : ModItem{

        public override string Texture => "Terraria/Item_" + ItemID.IceBlock;
        public override void SetDefaults(){
            item.width = 20;
            item.height = 20;
            item.rare = 1;
            item.value = 1000;
            
        }
    }    
}