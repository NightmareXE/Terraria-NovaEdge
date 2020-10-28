using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;

namespace NovaEdge.Projectiles{
    public class ShroomDart : ModProjectile
    {
        public int a = 0;
        
        public override void SetDefaults(){

           
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.penetrate = 1;
			projectile.ranged = true;
			projectile.scale = 1f;
			projectile.aiStyle = 1;
            projectile.timeLeft = 300;
            projectile.tileCollide = true;
            
		
        }
        public override void AI(){
            a++;
            Player player = Main.player[projectile.owner];
            if(a == 12){
                 Projectile.NewProjectile(projectile.Center.X , projectile.Center.Y , 0 , 0 , ProjectileID.Mushroom , 0 , 3f , player.whoAmI);
                 a = 0;
            }
            
        }
      
    }   
}