using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NovaEdge.Items.SpaceSpooder{
    public class HoloSpiderProj : ModProjectile{
        //public float dist;

        public override string Texture => "Terraria/Projectile_4";

        public override void SetDefaults(){
            projectile.friendly = true;
            projectile.width = projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            projectile.timeLeft = 240;
            projectile.penetrate = -1;
            projectile.magic = true;

        }
        
        public override void AI(){
            
            projectile.netUpdate = true;
            projectile.ai[0]++;
            
           
        
            if(projectile.ai[0] > 60 && projectile.ai[0] % 15 == 0){
                ShootLaser();

            }
            
            /*if(projectile.ai[0] % 25 == 0){
                int type = ModContent.ProjectileType<Projectiles.FleshRipperProj>();
                for(int a = 0; a < 8; a++){
                    Vector2 speed = projectile.velocity.RotatedBy(MathHelper.ToRadians(40));
                    int damage = 50;
                    Projectile.NewProjectile(projectile.Center , speed * 4 , type , damage , 3.7f , Main.myPlayer);
                }
            }*/ // this turned into spaget
        }
        private void ShootLaser(){
            Vector2 projPos = projectile.Center;
            //Vector2 pos = new Vector2(projectile.Center.X + 320f , projectile.Center.Y);
            //Vector2 direction = pos - projPos;
            //direction.Normalize();
            for(int i = 0; i < 200; i++){

                if(Main.npc[i].active && !Main.npc[i].dontTakeDamage){
                     float dist =  Vector2.Distance(Main.npc[i].Center , projPos);
                     if(dist < 450f){
                        Vector2 move = Main.npc[i].Center - projPos;
                        Projectile.NewProjectile(projPos , move , 440 , 50 , 3.7f , Main.myPlayer);
                    
                     }
                    
                }
            }
        }
    }

}