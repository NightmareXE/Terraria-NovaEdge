using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NovaEdge.Items.Armors
{
    [AutoloadEquip(EquipType.Legs)]
    public class SpaceTortoiseLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Tortoise Mech Legs");
            Tooltip.SetDefault("Decreases movement speed by 15% \nIncreases enemy aggression \nIncreases minion damage by 10%");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 5);
            item.height = item.width = 18;
            item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed -= 0.15f;
            player.minionDamage += 0.1f;
            player.aggro++;
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleLeggings);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 75);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

    }
}
