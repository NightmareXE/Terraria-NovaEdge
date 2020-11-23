using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Armors {
    [AutoloadEquip(EquipType.Body)]
    public class LivingWoodChestplate : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Lively Wood Coverings");
            Tooltip.SetDefault("Increases damage by 10%");
        }
        public override void SetDefaults(){
            item.width = 40;
            item.height = 40;
            item.rare = ItemRarityID.Green;
            item.value = 15000;
            item.defense = 5;
        }
        public override bool IsArmorSet(Item head , Item body , Item legs){
         
            return head.type == ItemType<LivingWoodGoggles>() || head.type == ItemType<LivingWoodHeadgear>() || head.type == ItemType<LivingWoodHeadband>() || head.type == ItemType<LivingWoodMask>() && legs.type == ItemType<LivingWoodLeggings>();
        }
        public override void UpdateEquip(Player player){
            player.allDamage += 0.1f;
        }
        public override void UpdateArmorSet(Player player){
            player.setBonus = "All attacks will have a 25% chance to give Dryad's Blessing to the user\nAttacks also have a 25% chance to inflict Dryad's Bane on enemies";
            player.GetModPlayer<NovaEdgePlayer>().livelyWood = true; //gotta do the dryads blessing
            
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood , 80);
            recipe.AddIngredient(ItemType<Materials.MagicalSprout>() , 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}