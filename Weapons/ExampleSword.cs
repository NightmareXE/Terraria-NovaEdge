using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria;
using NovaEdge.Buffs;
using NovaEdge.Items.VanillaChanges;
using NovaEdge.Items.AssassinClass;

namespace NovaEdge.Items.Weapons
{
	public class ExampleSword : AssassinItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("ExampleSword"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("This is a basic modded sword.");
		}

		public override void SafeSetDefaults() 
		{
			item.damage = 50;
			
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = ItemRarityID.Green;
			item.UseSound = SoundID.Item1;
			item.shoot = ProjectileType<TerraBeam>();
			item.shootSpeed = 10f;
			item.autoReuse = true;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
		public override void OnHitNPC(Player player , NPC target , int damage , float knockback , bool crit){
			NovaEdgePlayer ModPlayer = player.GetModPlayer<NovaEdgePlayer>();
			if(ModPlayer.isStealthFull){
				target.AddBuff(BuffType<Decay>() , 600);
			}
			
		}
		
	}
}