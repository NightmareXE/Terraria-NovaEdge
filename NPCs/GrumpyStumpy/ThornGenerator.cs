using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace NovaEdge.NPCs.GrumpyStumpy{
    public class ThornGenerator : ModProjectile{
        public override string Texture => "Terraria/Item_4";

        public override void SetDefaults(){
            projectile.hostile = true;
            projectile.width = projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            projectile.timeLeft = 180;
            projectile.tileCollide = false;
        }
        public override void AI(){
            projectile.ai[0]++;
            if(projectile.ai[0] % 15 == 0){
                Vector2 velocity = new Vector2(0 , -6);
                int damage = 12;
                int type = ModContent.ProjectileType<ThornProj>();
                Projectile.NewProjectile(projectile.Center ,velocity , type , damage , 2f , Main.myPlayer );
            }
        }
    }
}