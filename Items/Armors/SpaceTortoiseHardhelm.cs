using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Threading.Tasks;

namespace NovaEdge.Items.Armors
{
    [AutoloadEquip(EquipType.Head)]
    public class SpaceTortoiseHardhelm : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Tortoise Hardhelm");
            Tooltip.SetDefault("Increases minion damage by 10% \nIncreases max number of minions by 1 \nIncreased enemy aggression");
        }
        public override void SetDefaults()
        {
            item.defense = 15;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 8, silver: 30);
            item.width = 40;
            item.height = 40;

        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions++;
            player.minionDamage += 0.1f;
            player.aggro++;


        }
        public override void AddRecipes()
        {
            ModRecipe recipe= new ModRecipe(mod);
            recipe.AddIngredient(ItemID.TurtleHelmet);
            recipe.AddIngredient(ItemID.MartianConduitPlating);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return head.type == ModContent.ItemType<SpaceTortoiseHardhelm>() && body.type == ModContent.ItemType<SpaceTortoiseSuit>() && legs.type == ModContent.ItemType<SpaceTortoiseLegs>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Set Bonus: Hardshell Enforcement \nUsing the 'Set Bonus Trigger' button wraps the player in a turtle shell \nThese bonuses apply while inside the shell \n-5 Boosted jumps that replace other sources of flight \n-Inability to stay still \n-Booster Dash that can ram enemies\n-50% increased damage reduction \n-50% decreased summon damage and movement speed \n-This shell has a 10second cooldown after being toggled off";
            player.endurance += 0.5f;
            player.moveSpeed -= 0.5f;
            player.minionDamage -= 0.5f;
            //player.GetModPlayer<NovaEdgePlayer>().spaceTortoise = true;

        }
    }
    
}
