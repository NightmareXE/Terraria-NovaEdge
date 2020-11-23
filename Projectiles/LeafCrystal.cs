using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
namespace NovaEdge.Projectiles
{
    public class LeafCrystal : ModProjectile
    {
        bool target = false;
        Vector2 vel = Vector2.Zero;
        Vector2 targetPos = Vector2.Zero;
        Vector2 playerPos = Vector2.Zero;
        bool curved = false;
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 30;
            projectile.scale = 0.8f;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.friendly = true;
        }

        public override void AI()
        {
           
            projectile.ai[0]++;
            projectile.rotation = projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Lighting.AddLight(projectile.Center, 0.1f, 0.2f, 0.15f);


            if (projectile.ai[0] > 10 && projectile.ai[0] < 30 && !curved)
            {
                ExplosionDust(2, projectile.Center);
                Curve(Main.player[projectile.owner], 256, 14);
                curved = true;
            }
            if (Main.rand.NextFloat() < 0.3f) TrailDust();


        }
        private void Curve(Player player, float targetRange, float velMult)
        {

            playerPos = player.Center;
            float targetDist = targetRange;



            for (int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.CanBeChasedBy(this, false))
                {
                    float distance = Vector2.Distance(npc.Center, projectile.Center);
                    if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                    {
                        targetDist = distance;
                        target = true;
                        targetPos = npc.Center;
                    }
                }
            }




            if (target)
            {
                vel = targetPos - projectile.Center;
                vel.Normalize();
                projectile.velocity = vel * velMult;
            }
        }
        private void TrailDust()
        {

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

            dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 30, 30, 229, projectile.velocity.X * -0.2f, projectile.velocity.X * -0.2f, 0, new Color(255, 255, 255), 1f)];
            if (Main.rand.NextBool(4))
            {
                dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(67, Main.LocalPlayer);

            }
            else dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(102, Main.LocalPlayer);




        }
        private void ExplosionDust(int amount, Vector2 pos)
        {
            for (int i = 0; i < amount; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Main.dust[Terraria.Dust.NewDust(pos, 30, 30, 229, Main.rand.NextFloat(-4, 4), Main.rand.NextFloat(-4, 4), 0, new Color(255, 255, 255), 1f)];
                if (Main.rand.NextBool(4))
                {
                    dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(67, Main.LocalPlayer);

                }
                else dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(102, Main.LocalPlayer);

            }


        }

    }
}
