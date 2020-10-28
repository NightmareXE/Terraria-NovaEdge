using NovaEdge.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons
{
	public class Infectious : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Infectious");
			Tooltip.SetDefault("It drips with blood.");

			
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 21;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}
		

		public override void SetDefaults() {
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 261;
			item.height = 222;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 4.2f;
			item.damage = 38;
			item.rare = ItemRarityID.Orange;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 3 , silver: 56);
			item.shoot = ProjectileType<InfectiousProjectile>();
		}

		public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Ichor , 25);
			recipe.AddIngredient(ItemID.CrimsonYoyo , 1);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		
		
	}
}
