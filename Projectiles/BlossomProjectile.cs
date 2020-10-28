using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NovaEdge.Dusts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Projectiles
{
    public class BlossomProjectile : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 250f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = 9f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;

        }
        public override void SetDefaults()
        {
            projectile.melee = true;
            projectile.aiStyle = 99;
            projectile.width = 30;
            projectile.height = 30;
            projectile.scale = 1f;
            projectile.extraUpdates = 0;
            projectile.penetrate = -1;
            projectile.friendly = true;

        }
        public override void AI()
        {
            projectile.ai[0]++;
            for(int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
                float dist = Vector2.Distance(npc.Center, projectile.Center);

                if(dist < 256)
                {
                    Vector2 vel = npc.Center - projectile.Center;
                    vel.Normalize();

                    Projectile.NewProjectile(projectile.Center, vel * 14, ProjectileID.Seed, projectile.damage, 5f, projectile.owner);
                }
            }




        }




    }
}
