using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Armors {
    [AutoloadEquip(EquipType.Head)]
    public class LivingWoodMask : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Lively Wood Rootmask");
            Tooltip.SetDefault("Increases melee speed by 12%");
        }
        public override void SetDefaults(){
            item.defense = 6;
            item.rare = ItemRarityID.Blue;
            item.width = 40;
            item.height = 40;
            item.value = 12000;
        }
        public override void UpdateEquip(Player player){
            player.meleeSpeed += 0.12f;
            
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