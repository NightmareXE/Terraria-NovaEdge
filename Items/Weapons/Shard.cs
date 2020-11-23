using NovaEdge.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons{
    public class Shard : ModItem{
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("Designed to exterminate");
            ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 21;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }

        public override void SetDefaults(){
            item.width = 58;
            item.height = 53;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.rare = ItemRarityID.Yellow;
            item.value = Item.sellPrice(0, 13, 0, 0);
            item.channel = true;
            item.useTime = 25;
            item.useAnimation = 25;
            item.shootSpeed = 15f;
            item.knockBack = 4f;
            item.damage = 165;
            item.melee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.shoot = ProjectileType<ShardProjectile>();
        }

        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Nanites, 20);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 25);
            recipe.AddIngredient(ItemID.Ectoplasm, 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
    }
}