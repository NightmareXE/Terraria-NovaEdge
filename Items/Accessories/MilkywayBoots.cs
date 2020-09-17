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
    //TODO doesn't count as Wings yet; needs the 4-frame wing spritesheet (or some way to bypass it)
    //[AutoloadEquip(EquipType.Wings)]
    class MilkywayBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Milkyway Boots");
            Tooltip.SetDefault("Grants infinite boosted jumps; counts as Wings" +
                "\nGrants a quick dash forward; allows fast movement and sprinting" +
                "\nAllows walking on liquids and complete control on ice" +
                "\nGrants 7 seconds of lava immunity");
        }

        public override void SetDefaults()
        {
            //TODO this sprite is enormous when dropped
            item.width = 63;
            item.height = 61;
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
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //Double jump effects
            player.GetModPlayer<NovaEdgePlayer>().milkywayBootsJumpTimerMax = 20;
            player.doubleJumpCloud = true;
            player.jumpBoost = true;

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
