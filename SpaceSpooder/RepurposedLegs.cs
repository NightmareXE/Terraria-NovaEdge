using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NovaEdge.Items.SpaceSpooder
{
    public class RepurposedLegs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Repurposed Legs");
            Tooltip.SetDefault("'ewwww.... Spider legs are gross, but effective'");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.ranged = true;
            item.width = 12;
            item.height = 38;
            item.maxStack = 1;
            item.useTime = 8;
            item.useAnimation = 28;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.knockBack = 11;
            item.value = 100000;
            item.rare = ItemRarityID.LightPurple;
            item.UseSound = SoundID.Item12;
            item.noMelee = true;
            item.shoot = ProjectileID.WoodenArrowFriendly;
            item.useAmmo = AmmoID.Arrow;
            item.shootSpeed = 8f;
            item.autoReuse = true;

        }

            public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                type = ProjectileID.VenomBullet;
            }
            return true;
        }
    }
}
