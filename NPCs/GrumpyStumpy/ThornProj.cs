using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace NovaEdge.NPCs.GrumpyStumpy{
    public class ThornProj : ModProjectile{
        //public override string Texture => "Terraria/Item_4";

        public override void SetDefaults(){
            projectile.hostile = true;
            projectile.width = projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            projectile.timeLeft = 21;
            projectile.tileCollide = false;
        }
        public override void AI(){
            projectile.ai[0]++;
            
            projectile.rotation = projectile.velocity.ToRotation();
            if(projectile.ai[0] % 3 == 0){
                int type = ModContent.ProjectileType<ThornProj2>();
                int damage = 12;
                Projectile.NewProjectile(projectile.Center , projectile.velocity * 0.01f , type , damage , 3f , Main.myPlayer);
            }
        }
    }
    public class ThornProj2 : ModProjectile{
         //public override string Texture => "Terraria/Item_4";

        public override void SetDefaults(){
            projectile.hostile = true;
            projectile.width = projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            projectile.tileCollide = false;

            projectile.timeLeft = 40;
        }
        public override void AI(){
            projectile.rotation = projectile.velocity.ToRotation();

        }
        
    }
}