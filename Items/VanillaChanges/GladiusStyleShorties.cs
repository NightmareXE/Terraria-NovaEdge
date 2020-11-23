using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;


namespace NovaEdge.Items.VanillaChanges
{
    public class GladiusStyleShorties : ModProjectile
    {
		public override string Texture => "Terraria/Item_" + ItemID.PlatinumShortsword;

        public override void SetDefaults()
        {
			projectile.width = 18;
			projectile.height = 18;
			//.aiStyle = 161;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.tileCollide = false;
			projectile.scale = 1.5f;
			projectile.ownerHitCheck = true;
			projectile.melee = true;
			projectile.extraUpdates = 1;
			projectile.hide = true;
		}
		private float GetLerpValue(float from, float to, float t, bool clamped = false)
		{
			if (clamped)
			{
				if (from < to)
				{
					if (t < from)
					{
						return 0f;
					}
					if (t > to)
					{
						return 1f;
					}
				}
				else
				{
					if (t < to)
					{
						return 1f;
					}
					if (t > from)
					{
						return 0f;
					}
				}
			}
			return (t - from) / (to - from);
		}
		public override void AI()
        {
			Player player = Main.player[projectile.owner];
			Vector2 vel = Main.MouseWorld - projectile.Center;
			vel.Normalize();
			if(projectile.ai[0] == 0)
            {
				projectile.velocity = vel.RotatedByRandom(MathHelper.PiOver4) * 2.4f;

			}
			projectile.rotation = projectile.direction == 1 ? projectile.velocity.ToRotation() + MathHelper.PiOver4 : projectile.velocity.ToRotation() + MathHelper.PiOver2;
			projectile.ai[0] += 1f;
			float num2 = (projectile.Opacity = GetLerpValue(0f, 7f, projectile.ai[0], clamped: true) * GetLerpValue(16f, 12f, projectile.ai[0], clamped: true));
			projectile.Center = player.RotatedRelativePoint(player.MountedCenter, false) + projectile.velocity * (projectile.ai[0] - 1f);
			projectile.spriteDirection = projectile.direction = Math.Sign(projectile.velocity.X);
			if (projectile.ai[0] >= 16f)
			{
				projectile.Kill();
			}
			else
			{
				
				player.heldProj = projectile.whoAmI;
				player.itemTime = 2;
				player.itemAnimation = 2;
				player.ChangeDir(projectile.direction);
				player.itemRotation = MathHelper.WrapAngle(projectile.rotation);

			}
		    
		}
		
    }
}
