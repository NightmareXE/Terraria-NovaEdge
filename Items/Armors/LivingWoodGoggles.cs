using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using NovaEdge.Items.Materials;
namespace NovaEdge.Items.Armors {
    [AutoloadEquip(EquipType.Head)]
    public class LivingWoodGoggles : ModItem {

        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Lively Wood Goggles");
            Tooltip.SetDefault("Increases your max number of minions by 1");

        }
        public override void SetDefaults(){
            item.rare = 1;
            item.width = 40;
            item.height = 40;
            item.defense = 3;
            item.value = 12000;

        }
        public override void UpdateEquip(Player player){
            
            player.maxMinions++;
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood , 50);
            recipe.AddIngredient(ItemType<Materials.MagicalSprout>() , 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}