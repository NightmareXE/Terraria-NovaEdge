using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using NovaEdge.Projectiles.Warhorn;


namespace NovaEdge.Projectiles.Warhorn{
    public class GoblinRing : WarhornProj{
        //public override string Texture => "Terraria/Item_" + ProjectileID.DemonScythe;
        public override void SafeSetDefaults(){
            projectile.width = 20;
            projectile.height = 26;
            projectile.tileCollide = true;
            projectile.ignoreWater = true;
            projectile.minion = true;
            projectile.aiStyle = 0;
            
            projectile.friendly = true;
            projectile.penetrate = 300;
            projectile.timeLeft = 130;
            projectile.scale = 1.5f;
            



        }
        /*public override void AI(){
            UpdateScale();
            projectile.ai[0] += 1f;
            projectile.ai[1] += 1f;
            if(projectile.ai[0] == 12f){
                projectile.ai[0] = 0;
                projectile.width -= 1;
            }
            if(projectile.ai[1] == 24f){
                projectile.ai[1] = 0;
                projectile.height -= 1;
            }
        }
        private void UpdateScale(){
            float scaleSize = 1/130f;
            

            projectile.scale -= scaleSize;
            if(projectile.scale < 0.1){
                projectile.Kill();
            }
        }
        public override bool OnTileCollide(Vector2 oldVelocity){  //THIS WILL BE COPIED QUITE A BIT
            projectile.penetrate--;
            if (projectile.penetrate <= 0) {
				projectile.Kill();
			}
			else {
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X) {
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y) {
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
        }
        public override void Kill(int timeLeft)
		{
			
			Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
			Main.PlaySound(SoundID.Item10, projectile.position);
		}*/
       
    }
}