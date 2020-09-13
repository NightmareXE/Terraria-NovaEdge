using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.ID;



namespace NovaEdge.Projectiles{
    public class VenomOrb : ModProjectile{
        
        public override void SetDefaults(){
            projectile.aiStyle = -1;
            projectile.penetrate = -1;
            projectile.hostile = true;
            projectile.width = projectile.height = 16;
            projectile.scale = 1.5f;
            
        }
        public override void OnHitNPC(NPC target , int damage , float knockback , bool crit){
            target.AddBuff(BuffID.Venom , 180);
        }
        public override void AI(){
            Lighting.AddLight(projectile.Center , 1f , 0 , 1f);
            Dust dust = Dust.NewDustDirect(projectile.position , projectile.width , projectile.height , 27);
           
            /*projectile.ai[0]++;
            if(projectile.ai[0] < 10){
                projectile.velocity.Y += 0.04f;
            }
            else if(projectile.ai[0] < 20 && projectile.ai[0] > 10){
                projectile.velocity.Y -= 0.04f;
            }
            else if(projectile.ai[0] > 20){
                projectile.ai[0] = 0;
            }*/
            
            
        }
        /*public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor) {
			//Redraw the projectile with the color not influenced by light
			Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
			for (int k = 0; k < projectile.oldPos.Length; k++) {
				Vector2 drawPos = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
				Color color = projectile.GetAlpha(lightColor) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
				spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPos, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
			}
			return true;
		}*/
    }
}