using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NovaEdge.Items.GrumpyStumpy
{
    public class VinewrathProjTip : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.VilethornTip;
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 100;
            
        }
        public override void AI()
        {
            projectile.ai[0]++;
            if(projectile.ai[0] % 20 == 0)
            {
                Projectile.NewProjectile(projectile.Center, Vector2.Zero, ModContent.ProjectileType<VinewrathProjBase>(), projectile.damage, 3f, Main.myPlayer);
            }
            projectile.rotation = projectile.velocity.ToRotation();
            if (projectile.timeLeft < 10)
            {
                projectile.alpha += 25;
                Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, DustID.GrassBlades);
            }

        }
    }
    public class VinewrathProjBase : ModProjectile
    {

        public override string Texture => "Terraria/Projectile_" + ProjectileID.VilethornBase;

        public override void SetDefaults()
        {
            projectile.ignoreWater = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.timeLeft = 40;
            projectile.melee = true;
        }
        public override void AI()
        {
            projectile.rotation = projectile.velocity.ToRotation();
            if (projectile.timeLeft < 10)
            {
                projectile.alpha += 25;
                Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, DustID.GrassBlades);
            }
        }
    }
}
