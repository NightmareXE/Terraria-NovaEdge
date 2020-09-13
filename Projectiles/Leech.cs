using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;
using System;
using NovaEdge.Buffs;

namespace NovaEdge.Projectiles  {
    public class Leech : ModProjectile{
        public override void SetStaticDefaults(){
            ProjectileID.Sets.Homing[projectile.type] = true;
        }
        public override void SetDefaults(){
            projectile.width = 16;
            projectile.height = 8;
            projectile.friendly = true;
            projectile.melee = true;
            projectile.ignoreWater= true;
            projectile.penetrate = 1;
            projectile.timeLeft = 500;

        }
        private const int MAX_TIME = 13;
        private const int ALPHA_REDUCE = 15;
        public int TargetWhoAmI {
			get => (int)projectile.ai[1];
			set => projectile.ai[1] = value;
		}

        public override void AI(){
            
            if(isLatched) LatchedAI();
			else NormalAI();
            
            
        }
        private void AdjustMagnitude(ref Vector2 vector){
            float magnitide = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitide < 6f){
                vector *=6f/magnitide;
            }
        }
        private void UpdateAlpha()
		{
			
			
			projectile.alpha += 3;
			if (projectile.alpha >= 255) {
				
                projectile.timeLeft = 1;
			}
		}
        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI) {
			
			if (projectile.ai[0] == 1f) 
			{
				int npcIndex = (int)projectile.ai[1];
				if (npcIndex >= 0 && npcIndex < 200 && Main.npc[npcIndex].active) {
					if (Main.npc[npcIndex].behindTiles) {
						drawCacheProjsBehindNPCsAndTiles.Add(index);
					}
					else {
						drawCacheProjsBehindNPCs.Add(index);
					}

					return;
				}
			}
		
			drawCacheProjsBehindProjectiles.Add(index);
		}

		public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough){
			width = height = 10;
			return true;
		}
		public override bool? Colliding(Rectangle projHitbox , Rectangle targetHitbox){
			if (targetHitbox.Width > 8 && targetHitbox.Height > 8) {
				targetHitbox.Inflate(-targetHitbox.Width / 8, -targetHitbox.Height / 8);
			}
			return projHitbox.Intersects(targetHitbox);
		}
		public override void Kill(int timeLeft){
			/*Vector2 Pos = projectile.position;
			const int DUST_AMT = 25;
				Vector2 rotationVector = (projectile.rotation - MathHelper.ToRadians(90f)).ToRotationVector2();
				Pos += rotationVector * 16f;
			for(int k = 0; k < DUST_AMT; k++){
				Dust dust = Dust.NewDustDirect(Pos , projectile.width , projectile.height , 6);
				dust.position = (dust.position + projectile.Center) / 2f;
				dust.velocity += rotationVector * 2f;
				dust.velocity *= 0.5f;
				dust.noGravity = true;
				dust.scale = 2f;
				
				Pos -= rotationVector * 8f;
			}*/

		}
		//ATTEMPT TO MAKE GLOWMASK
		//IT WONT ACCEPT VECtor 2 for some reason
		/*public override void PostDraw(SpriteBatch spriteBatch , Color lightColor){
			float rotation = projectile.rotation;
			Texture2D texture = mod.GetTexture("Projectile/FleshRipperProj");
			spriteBatch.Draw(
				texture,
				new Vector2(
				
						projectile.position.X - Main.screenPosition.X + projectile.width * 0.5f,
						projectile.position.Y - Main.screenPosition.Y + projectile.height - texture.Height  * 0.5f + 2f
				),
				new Rectangle(0 , 0 , texture.Width , texture.Height),
				Color.Orange,
				rotation,
				texture.Size() * 0.5f,
				SpriteEffects.None,
				0f

			);
		}*/



        public bool isLatched {
            get => projectile.ai[0] == 1f;
            set => projectile.ai[0] = value ? 1f : 0f;
        }
       
		private const int MAX_LATCHED_COUNT = 5;
		private readonly Point[] _latched = new Point[MAX_LATCHED_COUNT];

		public override void ModifyHitNPC(NPC target , ref int damage , ref float knockback , ref bool crit , ref int hitDirection)
		{
			isLatched = true;
			projectile.damage = 0;
			TargetWhoAmI = target.whoAmI;
			projectile.velocity = (target.Center - projectile.Center) * 0.75f;
			projectile.netUpdate = true;
			target.AddBuff(BuffType<FatalWounds>() , 300);
			 if(Main.rand.NextBool(2)){
				  target.AddBuff(BuffType<OpenWounds>() , 300);
			 }
			
			//CODE IS SPLIT INTO METHODS

			UpdateLatchedSword(target);			
		}

		private void UpdateLatchedSword(NPC target){
			int currentSwordIndex = 0;

			for ( int i = 0; i < Main.maxProjectiles; i++){
				Projectile currentProjectile = Main.projectile[i];
				if (i != projectile.whoAmI
					&& currentProjectile.active
					&& currentProjectile.owner == Main.myPlayer
					&& currentProjectile.type == projectile.type
					&& currentProjectile.modProjectile is Leech swordProjectile
					&& swordProjectile.isLatched
					&& swordProjectile.TargetWhoAmI == target.whoAmI){
						_latched[currentSwordIndex++] = new Point(i, currentProjectile.timeLeft);
						if(currentSwordIndex >= _latched.Length)
							break;
					}
			}
			if(currentSwordIndex >= MAX_LATCHED_COUNT){
				int oldSwordIndex = 0;
				for (int i = 1; i < MAX_LATCHED_COUNT; i++){
					if(_latched[i].Y < _latched[oldSwordIndex].Y){
						oldSwordIndex = i;
					}
				}
				Main.projectile[_latched[oldSwordIndex].X].Kill();
			}
		}
		
		
		private void NormalAI(){
			Dust dust = Dust.NewDustDirect(projectile.position , projectile.width , projectile.height , 60);
			TargetWhoAmI++;
            if(TargetWhoAmI >= MAX_TIME)
            {
                projectile.rotation++;
                UpdateAlpha();
                const float velXmultiplier = 0.98f;
                const float velYmultiplier = 0.16f;
                projectile.velocity.X *= velXmultiplier;
				projectile.velocity.Y += velYmultiplier;
                if(projectile.localAI[0] == 0f){
                AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
                TargetWhoAmI = MAX_TIME;
            }
            Vector2 movement = Vector2.Zero;
            float Distance = 350f;
            bool target = false;

            for(int i = 0; i < 200 ; i++){
                if(Main.npc[i].active && !Main.npc[i].dontTakeDamage && !Main.npc[i].friendly && Main.npc[i].lifeMax > 5 && Main.npc[i].type != NPCID.TargetDummy){
                    Vector2 newMovement = Main.npc[i].Center - projectile.Center;
                    float DistanceTo = (float)Math.Sqrt(newMovement.X * newMovement.X + newMovement.Y * newMovement.Y);
                    if(DistanceTo < Distance){
                        movement = newMovement;
                        Distance = DistanceTo;
                        target = true;

                    }
                }

            }
            if(target){
                AdjustMagnitude(ref movement);
                projectile.velocity = (10 * projectile.velocity + movement) /20f;
                AdjustMagnitude(ref projectile.velocity);

            }
            }
			
			

			projectile.rotation += 0.3f;
		}
		private void LatchedAI(){
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			const int aiFactor = 3; //lifetime of the AI
			projectile.localAI[0] += 1f;

			bool hitEffect = projectile.localAI[0] % 30f == 0f;
			int projTargetIndex = (int)TargetWhoAmI;
			if (projectile.localAI[0] >= 60 * aiFactor || projTargetIndex < 0 || projTargetIndex >= 200) { 
				projectile.Kill();
			}
			else if (Main.npc[projTargetIndex].active && !Main.npc[projTargetIndex].dontTakeDamage) { 
				
				projectile.Center = Main.npc[projTargetIndex].Center - projectile.velocity * 2f;
				projectile.gfxOffY = Main.npc[projTargetIndex].gfxOffY;
				
			}
			else { 
				projectile.Kill();
			}	
		
		}
    }
}