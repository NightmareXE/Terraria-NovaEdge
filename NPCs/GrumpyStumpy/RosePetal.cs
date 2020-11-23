using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.NPCs.GrumpyStumpy
{
    public class RosePetal : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.FlowerPowPetal;

        public override void SetDefaults()
        {
            projectile.hostile = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 180;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.2f, 0.05f, 0.05f);
            projectile.rotation = projectile.velocity.ToRotation() + ++projectile.ai[0] ;

        }
    }
}
