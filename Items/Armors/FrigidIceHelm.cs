using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Armors {
    [AutoloadEquip(EquipType.Head)]
    public class FrigidIceHelm : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Frigid Ice Helm");
            Tooltip.SetDefault("Increases summon damage by 5%");
        }
        public override void SetDefaults(){
            item.defense = 1;
            item.rare = 1;
            item.width = 40;
            item.height = 40;
            item.value = 1200;
        }
        public override bool IsArmorSet(Item head , Item body , Item legs){
            return body.type == ItemType<FrigidIceChestplate>() && legs.type == ItemType<FrigidIceLeggings>();
        }
        public override void UpdateArmorSet(Player player){
            player.maxMinions++;
            
        }
        public override void UpdateEquip(Player player){
            player.setBonus = "Increases max minions by 1";
            player.minionDamage += 0.05f;
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<Items.Materials.IceSphere>() , 15);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}