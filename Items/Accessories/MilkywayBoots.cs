using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NovaEdge.Items.Accessories
{
    [AutoloadEquip(EquipType.Wings, EquipType.Shoes)]
    class MilkywayBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Milkyway Boots");
            Tooltip.SetDefault("Grants infinite boosted auto-jumps; counts as Wings" +
                "\nGrants a quick dash forward; allows fast movement and sprinting" +
                "\nAllows walking on liquids and complete control on ice" +
                "\nGrants 7 seconds of lava immunity");
        }

        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 32;
            item.accessory = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.AddIngredient(ItemID.BundleofBalloons);
            recipe.AddIngredient(ItemID.Tabi);
            recipe.AddIngredient(ItemID.FrostsparkBoots);
            recipe.AddIngredient(ItemID.LavaWaders);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 50);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //Don't use wing flying, TODO remove gliding if desired
            player.wingTimeMax = 0;

            //Double jump effects
            player.GetModPlayer<NovaEdgePlayer>().milkywayBootsJumpTimerMax = 20;
            player.doubleJumpCloud = true;
            player.jumpBoost = true;

            //Frog leg effects
            player.jumpSpeedBoost += 2.4f;
            player.autoJump = true;

            //Tabi effects
            player.dash = 1;

            //Frostspark Boots effects
            player.accRunSpeed = 6.75f;

            player.moveSpeed += 0.08f;
            player.iceSkate = true;

            //Lava Waders effects
            player.waterWalk = true; //player.waterWalk2 also exists, IDK what the difference is, I am following what the Lava Waders use
            player.fireWalk = true;

            player.lavaMax += 60 * 7;

        }
    }
}
