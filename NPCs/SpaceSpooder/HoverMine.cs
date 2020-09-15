using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using NovaEdge.NPCs.SpaceSpooder;
using static Terraria.ModLoader.ModContent;


namespace NovaEdge.NPCs.SpaceSpooder{
    public class HoverMine : ModProjectile{
         public override void SetStaticDefaults(){
            ProjectileID.Sets.Homing[projectile.type] = true;
            Main.projFrames[projectile.type] = 2;

        }
        public override void SetDefaults(){
            
            projectile.width = projectile.height = 16;
            projectile.hostile = true;
            projectile.scale = 2.2f;
            projectile.penetrate = 1;
            projectile.timeLeft = 180;
            drawOffsetX = 5;
			drawOriginOffsetY = 5;
        }
        private const int MAX_TIME = 60;
        private int TargetWhoAmI {
            get => (int)projectile.ai[1];
            set => projectile.ai[1] = value;
        }

        public override void AI(){
            TargetWhoAmI++;
            
            if(TargetWhoAmI >= MAX_TIME){
                projectile.frame = 1;
                if(projectile.localAI[0] == 0f){
                AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
                TargetWhoAmI = MAX_TIME;
            }

            Vector2 move = Vector2.Zero;
            float Distance = 384f;
            bool LockOn =  false;
            for(int i = 0; i < 200; i++){
                if(Main.player[i].active &&  !Main.npc[i].dontTakeDamage ){
                    Vector2 newMove = Main.player[i].Center - projectile.Center;
                    float DistanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if(Distance > DistanceTo){
                        move = newMove;
                        Distance = DistanceTo;
                        LockOn = true;
                    }

                }
            }
            if(LockOn){
                AdjustMagnitude(ref move);
                projectile.velocity = (10* projectile.velocity + move) / 40f;
                AdjustMagnitude(ref projectile.velocity);

            }
            if (projectile.owner == Main.myPlayer && projectile.timeLeft <= 2){
                projectile.alpha = 255;
                projectile.tileCollide = false;
                projectile.position = projectile.Center;
                projectile.height = 128;
                projectile.width = 128;
                projectile.damage = 67;
                projectile.knockBack = 6f;
                projectile.Center = projectile.position;
            }
        }

        }
        private void AdjustMagnitude(ref Vector2 vector){
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude < 6f){
                vector *=6f/magnitude;
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
            for(int k = 0; k < 15; k++){
                int dustI = Dust.NewDust(new Vector2(projectile.position.X , projectile.position.Y) , projectile.width , projectile.height ,31, 0f, 0f, 100, default(Color), 2f);
                Main.dust[dustI].velocity *= 1.2f;
                Main.dust[dustI].noGravity = true;
            }
            for (int i = 0; i < 25; i++)
            {
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 3f);
				Main.dust[dustIndex].noGravity = true;
				Main.dust[dustIndex].velocity *= 5f;
				dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 3f;
            }
            for (int g = 0; g < 2; g++) {
				int goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y + 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X + 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
				goreIndex = Gore.NewGore(new Vector2(projectile.position.X + (float)(projectile.width / 2) - 24f, projectile.position.Y + (float)(projectile.height / 2) - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[goreIndex].scale = 1.5f;
				Main.gore[goreIndex].velocity.X = Main.gore[goreIndex].velocity.X - 1.5f;
				Main.gore[goreIndex].velocity.Y = Main.gore[goreIndex].velocity.Y - 1.5f;
			}
            projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
			projectile.width = 15;
			projectile.height = 15;
			projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
			projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
            projectile.ai[0] += 1f;
        }
        /*public override bool OnTileCollide(Vector2 oldVelocity){
            if(projectile.ai[1] != 0){
                return true;
            }
        }*/
        
    }
}