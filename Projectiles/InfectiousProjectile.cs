using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NovaEdge.Dusts;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Projectiles
{
    public class InfectiousProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 9f;

            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 245.5f;

            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
            projectile.aiStyle = 99;
        }

        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.3f, 0.1f, 0.1f);
            if (Main.rand.NextBool(7))
            {
                BloodDust();
            }
            else
            {
                IchorDust();

            }

        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (Main.rand.NextBool(3))
            {
                target.AddBuff(BuffID.Ichor, 420, false); //nice
            }
            for (int i = 0; i < 6; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
               
                dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 16, 16, 226, Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f), 0, new Color(255, 255, 255), 1f)];
                if (Main.rand.NextBool(7))
                {
                    dust.shader = GameShaders.Armor.GetSecondaryShader(59, Main.LocalPlayer);

                }
                else
                {
                    dust.shader = GameShaders.Armor.GetSecondaryShader(81, Main.LocalPlayer);
                }



            }
        }
        private void IchorDust()
        {
            if (Main.rand.NextFloat() < .81f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Terraria.Dust.NewDustPerfect(projectile.Center, 226, projectile.velocity * -0.4f, 0, new Color(255, 255, 255), 1f);
                dust.noGravity = true;
               
                dust.shader = GameShaders.Armor.GetSecondaryShader(81, Main.LocalPlayer);
            }

        }
        private void BloodDust()
        {
            if (Main.rand.NextFloat() < .81f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Terraria.Dust.NewDustPerfect(projectile.Center, 226, projectile.velocity.RotatedByRandom(MathHelper.ToRadians(3)) * -0.4f, 0, new Color(255, 255, 255), 1f);
                dust.shader = GameShaders.Armor.GetSecondaryShader(59, Main.LocalPlayer);
            }


        }




    }
}
