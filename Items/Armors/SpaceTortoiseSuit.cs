using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NovaEdge.Items.Armors
{
    [AutoloadEquip(EquipType.Body)]
    public class SpaceTortoiseSuit : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Tortoise Suit");
            Tooltip.SetDefault("Increases minion damage by 15% \nIncreases max minions by 1 \nIncreases enemy aggro");
        }
        public override void SetDefaults()
        {
            item.defense = 25;
            item.rare = ItemRarityID.Lime;
            item.width = item.height = 40;
            item.value = Item.sellPrice(gold: 15);

        }
        public override void UpdateEquip(Player player)
        {
            player.minionDamage += 0.15f;
            player.maxMinions++;
            player.aggro++;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleScaleMail);
            //recipe.AddIngredient(ItemID.TurtleShell);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 100);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

            ModRecipe recipe2 = new ModRecipe(mod);
            //recipe2.AddIngredient(ItemID.TurtleScaleMail);
            recipe2.AddIngredient(ItemID.TurtleShell);
            recipe2.AddIngredient(ItemID.MartianConduitPlating, 100);
            recipe2.AddTile(TileID.MythrilAnvil);
            recipe2.SetResult(this);
            recipe2.AddRecipe();

        }
    }
}
