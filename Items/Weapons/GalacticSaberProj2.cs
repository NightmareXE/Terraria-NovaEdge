using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;


namespace NovaEdge.Items.Weapons{
    public class GalacticSaberProj2 : ModProjectile{
        public int i = 0;
        public override void SetDefaults(){

            projectile.width = projectile.height = 100;
            projectile.melee = true;
            
            projectile.ignoreWater =true;
            projectile.penetrate = 200;
            projectile.timeLeft = 300;
            
            projectile.friendly = true;
            
           // drawOffsetX = 15;
			//drawOriginOffsetY = 15;
            //projectile.extraUpdates = 1;
            
            //aiType = ProjectileID.PaladinsHammer;

            
           
            
        }
       
        public override void AI(){
            //projectile.velocity = projectile.velocity * 1.5;

            projectile.rotation += 0.1f;
            Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 150);
            Lighting.AddLight(projectile.Center , 1.1f , 0.5f , 0.5f);
            Player player = Main.player[projectile.owner];
            if(player.ownedProjectileCounts[projectile.type] > 3)
            {
                Vector2 returnVel = player.Center - projectile.Center;
                returnVel.Normalize();
                projectile.velocity = returnVel * 9f;
                if(Vector2.Distance(player.Center , projectile.Center) < 32)
                {
                    projectile.Kill();
                }
            }
           
        }
        public override bool PreDraw(SpriteBatch spriteBatch  , Color lightColor ){
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width  * 0.5f , projectile.height * 0.5f);
            
                Vector2 drawPos = projectile.position - Main.screenPosition + drawOrigin +  new Vector2(0f , projectile.gfxOffY);
            Color color = Color.Azure;
                spriteBatch.Draw(Main.projectileTexture[projectile.type] , drawPos , null , color , projectile.rotation , drawOrigin , projectile.scale , SpriteEffects.None , 0f);

            
            return true;
        }
        public override void Kill(int timeLeft){
            Collision.HitTiles(projectile.position + projectile.velocity , projectile.velocity , projectile.width , projectile.height);
            
        }
    }
}