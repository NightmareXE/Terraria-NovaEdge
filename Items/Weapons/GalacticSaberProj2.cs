using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;


namespace NovaEdge.Items.Weapons{
    public class GalacticSaberProj2 : ModProjectile{
        public int i = 0;
        public override void SetDefaults(){

            projectile.width = projectile.height = 38;
            projectile.melee = true;
            
            projectile.ignoreWater =true;
            projectile.penetrate = 200;
            projectile.timeLeft = 300;
            projectile.aiStyle = 3;
            projectile.friendly = true;
            projectile.netUpdate = true;
            drawOffsetX = 15;
			drawOriginOffsetY = 15;
            
            //aiType = ProjectileID.PaladinsHammer;

            
           
            
        }
       
        public override void AI(){
             
              projectile.rotation += 0.5f;
            Lighting.AddLight(projectile.Center , 1.1f , 0.5f , 0.5f);
           
        }
        public override bool PreDraw(SpriteBatch spriteBatch  , Color lightColor ){
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width  * 0.5f , projectile.height * 0.5f);
            for(int e = 0; e < projectile.oldPos.Length; e++){
                Vector2 drawPos = projectile.oldPos[e] - Main.screenPosition + drawOrigin +  new Vector2(0f , projectile.gfxOffY);
                Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - e) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type] , drawPos , null , color , projectile.rotation , drawOrigin , projectile.scale , SpriteEffects.None , 0f);

            }
            return true;
        }
        public override void Kill(int timeLeft){
            Collision.HitTiles(projectile.position + projectile.velocity , projectile.velocity , projectile.width , projectile.height);

        }
    }
}