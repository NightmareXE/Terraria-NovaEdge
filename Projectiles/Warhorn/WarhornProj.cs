using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;


namespace NovaEdge.Projectiles.Warhorn
{
    public abstract class WarhornProj : ModProjectile
    {

        public virtual void SafeSetDefaults()
        { //Override this to SetDefaults
        }
        public virtual void SafeKill(int timeLeft)
        {

        }
        public virtual void SafeTileCollide(Vector2 oldVelocity)
        {

        }
        public virtual void SafeAI()
        {

        }

       
        public bool fadeInStart = false;
        public int fadeInTime = 10;
        public int tagDamage = 0;

        public bool infinitePierce = true;

        public float rotationIncrease = 0;
        public int timeleft
        {
            get => projectile.timeLeft;
            set => projectile.timeLeft = value;
        }
        public sealed override void SetDefaults()
        {
            SafeSetDefaults();
        }
        public sealed override void AI()
        {
            if (fadeInStart)
            {
                FadeIn(fadeInTime);
            }
            ReduceScale(timeleft);
            SafeAI();
            projectile.rotation = projectile.velocity.ToRotation() + rotationIncrease;

        }
        public void ReduceScale(int timeLeft)
        {
            float scaleSize = 1f / timeLeft;


            projectile.scale -= scaleSize;
            if (projectile.scale < 0.1f)
            {
                projectile.Kill();
            }
        }
        public sealed override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (!infinitePierce)
            {
                projectile.penetrate--;
                if (projectile.penetrate <= 0)
                {
                    projectile.Kill();
                }
            }
            else
            {
                Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
                Main.PlaySound(SoundID.Item10, projectile.position);
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
            }

            SafeTileCollide(oldVelocity);
            return false;
        }
        public override void Kill(int timeLeft)
        {
            SafeKill(timeLeft);
            Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
            Main.PlaySound(SoundID.Item10, projectile.position);
        }

        public void FadeIn(int fadeTime)
        {
            projectile.ai[0]++;
            if (projectile.ai[0] < fadeTime)
            {
                projectile.alpha -= 255 / fadeTime;
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
            }
        }

        
    }
}