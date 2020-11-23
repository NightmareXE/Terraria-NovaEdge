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
            projectile.localAI[0]++;
            if(projectile.localAI[0] % 40 == 0 && Main.player[projectile.owner].controlUseItem) {
                Projectile.NewProjectile(projectile.Center , Vector2.Zero , ModContent.ProjectileType<StarryNightSparkle>() , projectile.damage , 2f , Main.myPlayer);
                if(projectile.localAI[1] > 4)
                {
                    projectile.localAI[1] = 0;
                }
                for(int i = 0; i < 5; i++)
                {
                    StarShapedDust((int)projectile.localAI[1]);
                    projectile.localAI[1]++;

                }
            }
        }
        private void StarShapedDust(int index)
        {
            Vector2 vel;
            switch (index)
            {
                case 0:
                    vel = new Vector2(0, -1);
                    break;
                case 1:
                    vel = new Vector2(1, 1);
                    break;
                case 2:
                    vel = new Vector2(-1, 1);
                    break;
                case 3:
                    vel = new Vector2(-1, -1);
                    break;
                case 4:
                    vel = new Vector2(1, -1);
                    break;
                default:
                    vel = Vector2.Zero;
                    break;

            }
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
           
            dust = Terraria.Dust.NewDustPerfect(projectile.Center, 226, vel * 4, 0, new Color(255, 255, 255), 1f);
            dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(80, Main.LocalPlayer);


        }
        private void PurpleDustTrail()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            //Vector2 position = Main.LocalPlayer.Center;
            dust = Terraria.Dust.NewDustPerfect(projectile.Center, 226, projectile.velocity * -0.2f, 0, new Color(255, 255, 255), 1f);
            dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(33, Main.LocalPlayer);

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
            for(int i = 0; i < 10;i++){
                StarExplosionDust();
            }
        }
        private void StarExplosionDust()
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

            dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 16, 16, 43, Main.rand.NextFloat(-5, 5), Main.rand.NextFloat(-5, 5), 0, new Color(255, 255, 255), 1f)];

        }


    }
    
}