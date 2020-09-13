using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Armors{
    [AutoloadEquip(EquipType.Legs)]
    public class LivingWoodLeggings : ModItem {
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Lively Wood Leggings");
            Tooltip.SetDefault("8% increased movement speed \nGives extra movement speed while under the effects of Dryad's Blessing");
        }
        public override void SetDefaults(){
            item.rare = 1;
            item.width = 18;
            item.height = 18;
            item.defense = 1;
            item.value = 11000;

        }
        public override void UpdateEquip(Player player){
            
            player.moveSpeed += 0.08f;
            if(player.HasBuff(165)){
                player.moveSpeed += 0.04f;
            }
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood , 20);
            recipe.AddIngredient(ItemType<Materials.MagicalSprout>() , 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}