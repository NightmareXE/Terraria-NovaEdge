using NovaEdge.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons
{
	public class Infernal : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Infernal");
			Tooltip.SetDefault("How are you gonna hold this?");

			
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 21;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}
		

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 30;
			item.height = 26;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 3.6f;
			item.damage = 40;
			item.rare = ItemRarityID.Orange;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 3);
			item.shoot = ProjectileType<InfernalProjectile>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CursedFlame , 25);
			recipe.AddIngredient(ItemID.CorruptYoyo , 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		
	}
}
