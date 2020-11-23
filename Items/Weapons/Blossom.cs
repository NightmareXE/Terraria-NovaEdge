using NovaEdge.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons
{
    public class Blossom : ModItem
    {
		
		public override void SetStaticDefaults()
		{

            DisplayName.SetDefault("Blossom");
            Tooltip.SetDefault("It hosts the fury of the jungle...");

            ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 21;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}


		public override void SetDefaults()
		{
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.width = 30;
            
			item.height = 26;
			item.useAnimation = 25;
			item.useTime = 25;
			item.shootSpeed = 16f;
			item.knockBack = 3.6f;
			item.damage = 100;
			item.rare = ItemRarityID.Orange;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 3);
			item.shoot = ProjectileType<BlossomProjectile>();
		}
		
        



    }
}