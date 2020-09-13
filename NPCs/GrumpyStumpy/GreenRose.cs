using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace NovaEdge.NPCs.GrumpyStumpy{
    public class GreenRose : ModProjectile{
        public override string Texture => "Terraria/Item_535";
        public override void SetDefaults(){
            projectile.hostile = true;
            projectile.width = projectile.height = 32;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;

            projectile.timeLeft = 180;
        }
        public override void AI(){
            projectile.velocity *= 0;
            for(int i = 0; i < 255; i++){
                if(Main.player[i].active){
                    projectile.ai[0]++;
                    Vector2 newMove = Main.player[i].Center - projectile.Center;
                    newMove.Normalize();
                    if(projectile.ai[0] % 45 == 0){
                        int type = ModContent.ProjectileType<Projectiles.VenomOrb>();
                        int damage = 15;
                        Projectile.NewProjectile(projectile.Center , newMove * 9f , type , damage , 4f , Main.myPlayer);
                    }

                }
            }
        }
    }
}