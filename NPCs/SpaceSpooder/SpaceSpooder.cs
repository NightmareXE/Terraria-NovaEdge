using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.NPCs.SpaceSpooder{
	    [AutoloadBossHead]

    public class SpaceSpooder : ModNPC{

        public bool StartDash;
        public bool stunned;
        public Vector2 playerPos;
        public Vector2 NPCpos;
        public Vector2 targetPos;
        public Vector2 pos;
        public bool SpawnDashDone;
        public bool SpawnDashDone2;


        
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Void Weaver");
            Main.npcFrameCount[npc.type] = 5;
            
            

        }
        public override void SetDefaults(){
            npc.aiStyle = -1;
            npc.width = 180;
            npc.height = 180;
            //aiType = NPCID.Zombie;
            npc.lifeMax= 15000;
            npc.knockBackResist = 0f;
            npc.damage = 95;
            npc.defense = 35;
            npc.npcSlots = 25f;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit4;
			npc.DeathSound = null;
			npc.alpha = 0;
            npc.noGravity = true;
            //npc.value = 10334f;
            npc.lavaImmune = true;
            npc.noTileCollide = true;

            for(int j = 0; j < npc.buffImmune.Length; j++){
                npc.buffImmune[j] = true;
            }
            music = mod.GetSoundSlot(SoundType.Music , "Sounds/Music/VoidBoiTheme");
			musicPriority = MusicPriority.BossMedium;

        }

        public override void ScaleExpertStats(int numPlayera , float bossLifeScale){
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);
            
            
        }
        
        public override void AI(){  //START DASH Being jank
            npc.TargetClosest();
            npc.netUpdate = true;
            npc.dontTakeDamage = false;
            //Dust.NewDustPerfect(npc.Left , 6 , Vector2.Zero , 0 , Color.Purple , 1f);
            //npc.frameCounter++;
            //if(npc.frameCounter < 6){
            //    npc.frameCounter = 0;
            //}

            //Despawning
            if(npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active){
                npc.TargetClosest(false);
                npc.velocity.Y -= 0.1f;
                npc.rotation = npc.velocity.ToRotation();
                
                if(npc.timeLeft > 60){
                    npc.timeLeft = 60;
                }
            }
            

            if(npc.life > npc.lifeMax/2.5f){
            //(npc.ai[0] == 10f){
               // SpawnDash();
            //}
            

            //if(!SpawnDashDone){
                //SpawnDash();
            //}
            //if(SpawnDashDone){
                
                
            //}
            
           
            
            
            
            npc.ai[0]++;
            /*if(dist > 1600){
                npc.ai[4]++;
                if(npc.ai[4] == 60){
                    npc.position = new Vector2(Main.player[npc.target].Center.X , Main.player[npc.target].Center.Y + 512f);
                }*/
                //npc.position = new Vector(Main.player[npc.target].Center.X , Main.player[npc.target].Center.Y + 512f)           }
            if(npc.ai[0] < 300){
                SpawnDash();
            }
            else if(npc.ai[0] < 555 && npc.ai[0] > 300){
                
                Move();
                if(npc.ai[0] % 45 == 0 && npc.ai[0] > 360 && npc.ai[0] < 525){
                    LaserBurst();
                }
            }
            else if(npc.ai[0] > 555 && npc.ai[0] < 735){
                BurstDash();
                if(npc.ai[1] > 60){
                    npc.ai[1] = 0;
                }
                if(npc.ai[0] == 545 || npc.ai[0] == 625 || npc.ai[0] == 705 ){
                    HoverMine();
                }
                
                
                if(npc.ai[0] > 575 && npc.ai[0] < 595){
                    npc.velocity *= 0.1f;
                }
                if(npc.ai[0] > 655 && npc.ai[0] < 675){
                    npc.velocity *= 0.1f;
                }
                if(npc.ai[0] > 735 && npc.ai[0] < 755){
                    npc.velocity *= 0.1f;
                }
            }
            /*else if(npc.ai[0] >= 755 && npc.ai[0] < 825 && SpawnDashDone){
                Move();
                npc.velocity *= 0.5f;
                for(int u = 0; u < 2;u++){
                Dust dust = Dust.NewDustDirect(npc.position , npc.width , npc.height , 27);
                }
            }
            else if(npc.ai[0] >= 825 && npc.ai[0] < 915 && SpawnDashDone){
               
                  //timer for hoverMine ^ maybe unused
                  if(npc.ai[0] == 835){
                    HoverMine();
                  }
                if(npc.ai[1] > 60){
                    npc.ai[1] = 0;
                }
                  RunAway();
                  else if(npc.ai[0] > 1000){
                      npc.velocity = (npc.Center - Main.player[npc.target].Center) * 9f;
                  }
                 
                
                    
                //npc.velocity *= 0.05f;  
            }*/
            
            
    
            if(npc.ai[0] > 755){
                npc.ai[0] = 301;
            }
            }
            else if(npc.life <= npc.lifeMax/2.5f){
                Lighting.AddLight(npc.Center , 2f , 0f , 2f);
                npc.defense = 25;
                
                
                /*if(!SpawnDashDone2){
                    SpawnDash();
                }
                if(SpawnDashDone){*/
                npc.ai[2]++;
                //}
                if(npc.ai[2] < 300){
                    SpawnDash();
                }
                if(npc.ai[2] < 540 && npc.ai[2] > 300){
                    Move();
                    //npc.velocity *= 1.2f;
                    if(npc.ai[2] % 60 == 0 && npc.ai[2] > 360){
                        LaserCircle();
                    }
                }
                if(npc.ai[2] > 600 && npc.ai[2] < 960){
                    LaserSpin();
                }
                else if(npc.ai[2] > 960 && npc.ai[2] < 1010){
                    if(npc.ai[2] == 980){
                        WeaverSpawn();
                    }
                    npc.velocity *= 0.05f;
                }
                else if(npc.ai[2] > 1010){
                    npc.ai[2] = 301;
                }
            

            }
            
            
            //npc.ai[3] += 1f; //TIMER FOR DASH SUBPHASE
            
        }
        private void LaserSpin(){
             if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                npc.ai[3]++;
                int type = 83;
                int damage = npc.damage/3;
                //int signX = Math.Sign(Main.player[npc.target].velocity.X);
                //int signY = Math.Sign(Main.player[npc.target].velocity.Y);

                 Vector2 targetPos = new  Vector2(Main.player[npc.target].Center.X  , Main.player[npc.target].Center.Y );
                //int sign = Math.Sign(Main.player[npc.target].velocity.X);
               
                //npc.position.X = targetPos.X + (sign * 640f);
                npc.velocity *= 0;
                
                
                Vector2 pos = npc.Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                float rot = direction.ToRotation();
                npc.rotation = rot;
                if(npc.ai[2] > 899){
                    npc.rotation = direction.ToRotation();
                }
                //Vector2 Helix = direction;
                //direction.Y -= 0.2f;
                
                //for(int a = 0; a < 36; a++){
                    if(npc.ai[2] % 12 == 0){
                Vector2 speedA = new Vector2(direction.X , direction.Y);//.RotatedBy(MathHelper.ToRadians(10));
                Projectile.NewProjectile(pos , speedA * 14f  , type , damage/2 , 0f , Main.myPlayer);
                //}
                }
             }
            
        }
        /*private void RunAway(){
             if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                npc.ai[1]++;
                
                if(npc.ai[1] == 1){
                    targetPos = Main.player[npc.target].Center;
                    pos = npc.Center;
                }
                Vector2 direction = pos - targetPos;
                direction.Normalize();
                //npc.aiStyle = 9;
                npc.velocity.X = direction.X * 9;
                npc.velocity.Y = direction.Y * 9;
                
                npc.rotation = npc.velocity.ToRotation();
                //npc.position = Main.player[npc.target].Center + npc.velocity * 320f;
            }
        }*/
        private void HoverMine(){
            
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 targetPos = Main.player[npc.target].Center;
                //int sign = Math.Sign(Main.player[npc.target].velocity.X);
               
                //npc.position.X = targetPos.X + (sign * 640f);
                
                
                Vector2 pos = npc.Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
               
                //npc.velocity = direction * 10f;       
                
                
                //npc.velocity *= 0;
                int type = ProjectileType<HoverMine>();
                int damage = npc.damage/4;
                
                Vector2 speedA = new Vector2(direction.X , direction.Y).RotatedByRandom(MathHelper.ToRadians(30));
                Projectile.NewProjectile(pos , speedA  , type , damage , 0f , Main.myPlayer);
                
                
                
                /*NPC.NewNPC((int)(targetPos.X + 256) , (int)targetPos.Y , ModContent.NPCType<MechEgg>());
                NPC.NewNPC((int)(targetPos.X - 256) , (int)targetPos.Y , ModContent.NPCType<MechEgg>());
                NPC.NewNPC((int)targetPos.X , (int)(targetPos.Y + 256) , ModContent.NPCType<MechEgg>());*/
            }
        

            
        }
        
        private void WeaverSpawn(){
            
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                /*Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                //npc.velocity *= 0;
                int type = ProjectileType<HoverMine>();
                int damage = npc.damage;
                for(int i = 0; i <= 2; i++){
                Vector2 speedA = new Vector2(direction.X , direction.Y).RotatedByRandom(MathHelper.ToRadians(359));
                Projectile.NewProjectile(pos , speedA  , type , damage , 0f , Main.myPlayer);}*/
                //NPC.NewNPC((int)(npc.Center.X + 160) , (int)npc.Center.Y , ModContent.NPCType<MechEggSpooder>());
                NPC.NewNPC((int)(npc.Center.X) , (int)(npc.Center.Y - 160f), ModContent.NPCType<MechEggSpooder>());
                NPC.NewNPC((int)npc.Center.X , (int)(npc.Center.Y + 160f) , ModContent.NPCType<MechEggSpooder>());
            }
        }
        private void Move(){
             if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;
                Vector2 dustPos = new Vector2(targetPos.X , targetPos.Y - 320f);
                float dist =  Vector2.Distance(targetPos , pos);
                if(dist > 1600f){
                    npc.ai[3]++;
                    if(npc.ai[3] < 60){
                        for(int i = 0; i <2 ; i++){
                            Dust.NewDustDirect(dustPos , npc.width , npc.height , 27);
                        }
                    }
                    if(npc.ai[3] == 60){
                         npc.position = dustPos;
                    }
                }
                
                
                //int dustIndex = Dust.NewDustPerfect(Vector2 npc.Left , int type = 6 , Vector2? Velocity = null , int Alpha, Color newColor = Color.Purple , float scale = 1f);
                
                

				
                
                direction.Normalize();
                npc.velocity.X = direction.X * 5;
                npc.velocity.Y = direction.Y * 5;
                float rot = npc.velocity.ToRotation();
                npc.rotation = rot;
             }
            
        }
        private void SpawnDash(){
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 move = targetPos - pos;
                move.Normalize();
                npc.dontTakeDamage = true;
                npc.velocity.X = move.X * 9;
                npc.velocity.Y = move.Y * 9;
                npc.rotation = npc.velocity.ToRotation();
                float dist =  Vector2.Distance(targetPos , pos);
                if(dist < 160f){
                    npc.velocity *= 0.05f;
                    npc.ai[0] = 300;


                }
               

                
            }
        }
        private void BurstDash(){
             if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                npc.ai[1]++;
                
                if(npc.ai[1] == 1){
                    targetPos = Main.player[npc.target].Center;
                    pos = npc.Center;
                }
                //Dust.NewDustPerfect(npc.Left , 6 , Vector2.Zero , 0 , Color.Purple , 1f);
                
                
                
               
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                //npc.aiStyle = 9;
                npc.velocity.X = direction.X * 9;
                npc.velocity.Y = direction.Y * 9;
                
                npc.rotation = npc.velocity.ToRotation();
                //npc.position = Main.player[npc.target].Center + npc.velocity * 320f;
            }

        }
        private void LaserBurst(){
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                
                //if(npc.ai[3] == 1){
                    //playerPos = Main.player[npc.target].Center;
                    //NPCpos = npc.Center;
                //}
                int signX = Math.Sign(Main.player[npc.target].velocity.X);
                int sign = Math.Sign(Main.player[npc.target].velocity.Y);
                
                Vector2 pos = new Vector2(npc.Center.X + 40 , npc.Center.Y);
                Vector2 targetPos = new Vector2(Main.player[npc.target].Center.X + (signX * 64f), Main.player[npc.target].Center.Y + (64f * sign));
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                //npc.velocity *= 0;
                int type = ModContent.ProjectileType<Projectiles.VenomOrb>();
                int damage = npc.damage/3;
                //Vector2 Helix = direction;
                //direction.Y -= 0.2f;
                
                for(int q = 0; q < 2;q++){
                    Vector2 speedA = new Vector2(direction.X , direction.Y).RotatedByRandom(MathHelper.ToRadians(3));

                    Projectile.NewProjectile(pos , speedA * 18f  , type , damage/2 , 0f , Main.myPlayer);
                }
                

            }
        }
        private void LaserCircle(){
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                //npc.velocity *= 0;
                int type = 83;
                int damage = npc.damage/3;
                float count = 5;
                pos += Vector2.Normalize(new Vector2(direction.X, direction.Y)) * 45f;;
                float spread = MathHelper.ToRadians(60);
                //pos += Vector2.Normalize(new Vector2(direction.X, direction.Y)) * 45f;
                //Vector2 speedA = new Vector2(direction.X , direction.Y).RotatedByRandom(MathHelper.ToRadians(359));
                for(int a = 0; a <= count; a++){
                    //position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;ector2 speedA = new Vector2(direction.X , direction.Y).RotatedBy(MathHelper.Lerp(-359 , 359 , a/(5 - 1)));
                    //Vector2 speedA = new Vector2(direction.X , direction.Y).RotatedBy(MathHelper.ToRadians(359));
                    spread += MathHelper.ToRadians(60);
                    Vector2 speedA = new Vector2(direction.X , direction.Y).RotatedBy(spread);
                    
                }

            }
        }
        public override void FindFrame(int frameHeight){
            npc.frameCounter++;
            int index = 0;
            if(npc.frameCounter < 5){    //AMIMATION
                npc.frame.Y = index * frameHeight;
            }
            else if(npc.frameCounter < 10){
                npc.frame.Y = 1 * frameHeight;
            }
             else if(npc.frameCounter < 15){
                npc.frame.Y = 2 * frameHeight;
            }
             else if(npc.frameCounter < 20){
                npc.frame.Y = 3 * frameHeight;
            }
             else if(npc.frameCounter < 25){
                npc.frame.Y = 4 * frameHeight;
            }
            else{
                npc.frameCounter = 0;
            }
        }
        public override void NPCLoot(){
            /*if (!NovaEdgeWorld.downedVoidWeaver) {
				NovaEdgeWorld.downedVoidWeaver = true;
				if (Main.netMode == NetmodeID.Server) {
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}*/ //TEMPLATE FOR DOWNED VARIABLE 












            //DROPS , gonna be done later
        }
        public override void BossLoot(ref string name, ref int potionType){
            potionType = ItemID.GreaterHealingPotion;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position) {
			scale = 1.5f;
			return null;
		}
        //DR for spinny phase
    



    }
}
