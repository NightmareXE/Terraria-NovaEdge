using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Microsoft.Xna.Framework;

namespace NovaEdge.Projectiles
{
    public class BloodClot : ModProjectile
    {
        public override string Texture => "Terraria/Projectile_" + ProjectileID.TheMeatball;
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.SporeTrap);
            projectile.width = projectile.height = 16;
            projectile.friendly = true;
            projectile.timeLeft = 300;
            projectile.penetrate = 3;
            
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.Ichor, 420);
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.2f, 0, 0);
            if (Main.rand.NextBool(4))
            {
                Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, DustID.GoldFlame);
            }
        }
        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 4; i++)
            {
                Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, DustID.GoldFlame);
            }
        }

    }
}
