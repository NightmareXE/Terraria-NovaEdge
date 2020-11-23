using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NovaEdge.Dusts;
//using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Projectiles
{
    public class BlossomProjectile : ModProjectile
    {

        //Shader 9 is good green , 13 is nice too , 67 is a darker green , 70 is a parrot green , 102 is a tealish green
        bool target = false;
        Vector2 vel = Vector2.Zero;
        
        Vector2 targetPos = Vector2.Zero;
        Vector2 playerPos = Vector2.Zero;
        public override void SetStaticDefaults()
        {

            //ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1f;

            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 250f;

            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 13f;
        }

        public override void SetDefaults()
        {
            //projectile.extraUpdates = 0;
            projectile.width = 30;
            projectile.height = 30;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 0.75f;
            projectile.aiStyle = 99;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.1f, 0.3f, 0.1f);
            if (++projectile.localAI[1] % 60 == 0)
            {
                ExplosionDust(6, projectile.Center);
                for (int i = 0; i < Main.rand.Next(4, 7); i++)
                {
                    Vector2 vel = new Vector2(0, 1).RotatedByRandom(MathHelper.TwoPi);
                    Projectile.NewProjectile(projectile.Center, vel * 14, ModContent.ProjectileType<LeafCrystal>(), projectile.damage , 3f, projectile.owner);
                }
            }
            if (Main.rand.NextFloat() < .8f)
            {
                YoyoTrailDust();
            }



        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            ExplosionDust(5, projectile.Center);
        }
        private void YoyoTrailDust()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            
            dust = Terraria.Dust.NewDustPerfect(projectile.Center, 226, new Vector2(projectile.velocity.X * - 0.4f, projectile.velocity.Y * -0.4f), 0, new Color(255, 255, 255), 1f);
            dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(102, Main.LocalPlayer);
            dust.noGravity = true;

        }
        private void ExplosionDust(int amount , Vector2 pos)
        {
            for (int i = 0; i < amount; i++){
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Main.dust[Terraria.Dust.NewDust(pos, 30, 30, 226, Main.rand.NextFloat(-4 , 4 ), Main.rand.NextFloat(-4, 4),  0, new Color(255, 255, 255), 1f)];
                if (Main.rand.NextBool(4))
                {
                    dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(67, Main.LocalPlayer);

                }
                else dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(102, Main.LocalPlayer);
                
            }
            

        }
        






    }
}
