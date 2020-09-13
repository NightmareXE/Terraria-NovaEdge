using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Armors {
    [AutoloadEquip(EquipType.Head)]
    public class LivingWoodHeadband : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Lively Wood Headband");
            Tooltip.SetDefault("Increases ranged crit chance by 8%");
        }
        public override void SetDefaults(){
            item.defense = 2;
            item.rare = 1;
            item.width = 40;
            item.height = 40;
            item.value = 12000;
        }
        public override void UpdateEquip(Player player){
            //player.shootSpeed  = 3f;
            player.rangedCrit += 8;
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