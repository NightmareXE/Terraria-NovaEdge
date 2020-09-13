using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Armors {
    [AutoloadEquip(EquipType.Legs)]
    public class FrigidIceLeggings : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Frigid Ice  Leggings");
            Tooltip.SetDefault("Increases summon damage by 5%");
        }
        public override void SetDefaults(){
            item.defense = 3;
            item.rare = 1;
            item.width = 40;
            item.height = 40;
            item.value = 1200;
        }
        public override void UpdateEquip(Player player){
            player.minionDamage += 0.05f;
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.IceSphere>() , 20);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}