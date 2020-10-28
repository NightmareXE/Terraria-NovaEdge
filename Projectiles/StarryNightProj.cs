using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NovaEdge.Dusts;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Projectiles
{
	public class StarryNightProj : ModProjectile
	{
		public override void SetStaticDefaults() {
			
			ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] =  26f;
			
			ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 300f;
			
			ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 14f;
		}

		public override void SetDefaults() {
			
			projectile.width = 32;
			projectile.height = 32;
			projectile.friendly = true;
			projectile.penetrate = -1;
			projectile.melee = true;
			projectile.scale = 1f;
			projectile.aiStyle = 99;
		}
        public override void AI(){
            projectile.ai[0]++;
            if(projectile.ai[0] % 40 == 0 && Main.player[projectile.owner].controlUseItem) {
                Projectile.NewProjectile(projectile.Center , Vector2.Zero , ModContent.ProjectileType<StarryNightSparkle>() , projectile.damage , 2f , Main.myPlayer);
            }
        }
	}
    public class StarryNightSparkle : ModProjectile{
        public override string Texture => "Terraria/Item_" + ItemID.FallenStar;
        public override void SetDefaults(){
            projectile.friendly = true;
            projectile.width = projectile.height = 16;
            projectile.ignoreWater = true;
            projectile.aiStyle = -1;
            projectile.timeLeft = 180;
        }
        public override void AI(){
            projectile.ai[1]++;
            
            if(projectile.owner == Main.myPlayer && projectile.timeLeft <= 2){
                projectile.alpha = 255;
                projectile.tileCollide = false;
                projectile.position = projectile.Center;
                projectile.height = 64;
                projectile.width = 64;
                projectile.damage = 67;
                projectile.knockBack = 6f;
                projectile.Center = projectile.position;
            }
        
        }
        public override bool OnTileCollide(Vector2 oldVelocity){
            if(projectile.ai[1] != 0){
                projectile.timeLeft = 2;
                return true;
            }
            return false;
        }
        public override void Kill(int timeLeft){
            Main.PlaySound(SoundID.Item15, projectile.position);
            for(int i = 0; i < 15;i++){
                Dust.NewDustDirect(projectile.Center , projectile.width , projectile.height , 6);
            }
        }
        
    }
}