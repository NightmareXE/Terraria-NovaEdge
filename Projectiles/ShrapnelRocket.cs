using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

using Terraria.ID;

namespace NovaEdge.Projectiles{
    public class ShrapnelRocket : ModProjectile{
        public override string Texture => "Terraria/Item_773";
        public override void SetDefaults(){
            
            projectile.width = projectile.height = 14;
            aiType = 140;
            
            projectile.friendly = true;
            projectile.penetrate = 0;
            projectile.ranged = true;
            projectile.CloneDefaults(140);
            projectile.tileCollide = true;
            projectile.timeLeft = 300;
           



        }
        public override void AI(){
            projectile.type = 140;
            projectile.penetrate = 1;
            

        }
        public override void Kill(int timeLeft){
            int shrapnelCount = 8 + Main.rand.Next(3);
            for(int i = 0; i < shrapnelCount; i++){
                Vector2 Speed = new Vector2(7f , 7f).RotatedByRandom(MathHelper.ToRadians(359));
                Projectile.NewProjectile(projectile.Center.X , projectile.Center.X , Speed.X , Speed.Y , ProjectileID.Bullet ,projectile.damage , projectile.knockBack , Main.player[i].whoAmI);
            }

        }
        public override void OnHitNPC(NPC target , int damage , float knockback , bool crit){
            projectile.Kill();
           
        }

      
    }
}