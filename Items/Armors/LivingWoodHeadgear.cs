using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Armors {
    [AutoloadEquip(EquipType.Head)]
    public class LivingWoodHeadgear : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Lively Wood Headgear");
            Tooltip.SetDefault("Reduces mana usage by 10%");
        }
        public override void SetDefaults(){
            item.defense = 4;
            item.rare = 1;
            item.width = 40;
            item.height = 40;
            item.value = 12000;
        }
        public override void UpdateEquip(Player player){
            //player.shootSpeed  = 3f;
           player.manaCost -= 0.1f;
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