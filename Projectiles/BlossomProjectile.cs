using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NovaEdge.Dusts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Projectiles
{
    public class BlossomProjectile : ModProjectile
    {
        public int a = 0;
        public int b = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 250f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] =  9f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 16f;

        }
        public override void SetDefaults(){
            projectile.melee = true;
            projectile.aiStyle = 99;
            projectile.width = 30;
            projectile.height = 30;
            projectile.scale = 1f;
            projectile.extraUpdates = 0;
            projectile.penetrate = -1;
            projectile.friendly = true;
            
        }
        public override void AI(){
            
 
            
            a++;
            b++;
            int damage = 70;
            float knockBack = 6f;
            float XVel;
            float YVel;
            
			Player player = Main.player[projectile.owner];

            if(a == 20){
            Projectile.NewProjectile(projectile.position.X , projectile.position.Y , projectile.velocity.X , projectile.velocity.Y, ProjectileID.TerraBeam , damage , knockBack , player.whoAmI);
            a = 0;
            }
            if(b == 15){
                if(projectile.velocity.X < 0){
                    XVel = -0.8f;
                }
                else{
                    XVel = 0.8f;
                }
                if(projectile.velocity.Y < 0){
                    YVel = -0.8f;
                }
                else{
                    YVel = 0.8f;
                }
                 Projectile.NewProjectile(projectile.position.X , projectile.position.Y , XVel, YVel , 567 , damage , knockBack , player.whoAmI);
                b = 0;
            }
            
        
        
        
        }
    }
}