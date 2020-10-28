using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace NovaEdge.Items.SpaceSpooder{
    public class HoloSpiderProj : ModProjectile{
        //public float dist;

        public override void SetDefaults(){
            projectile.friendly = true;
            projectile.width = projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            projectile.timeLeft = 240;
            projectile.magic = true;

        }
        
        public override void AI(){
            projectile.netUpdate = true;
            projectile.ai[0]++;
            
            
            
        
            if(projectile.ai[0] > 60 && projectile.ai[0] % 30 == 0){
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
                    Vector2 move = Main.npc[i].Center - projPos;
                    float dist = Vector2.Distance(move, projPos);
                    if(dist < 640f)
                    {
                        Projectile.NewProjectile(projPos, move, ProjectileID.LaserMachinegunLaser, 50, 3.7f, Main.myPlayer);

                    }




                }
            }
        }
    }

}