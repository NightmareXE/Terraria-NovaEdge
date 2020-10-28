using Terraria;
using Terraria.ModLoader;
namespace NovaEdge.Projectiles
{
    public class BlossomProj2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.melee = true;
            projectile.friendly = true;
        }
        public override void AI()
        {
            
            projectile.rotation = projectile.velocity.ToRotation();
            Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 140);
        }

    }
}
