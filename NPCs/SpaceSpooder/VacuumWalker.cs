using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using System;



namespace NovaEdge.NPCs.SpaceSpooder{
    public class VacuumWalker : ModNPC{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Vacuum Walker");
            Main.npcFrameCount[npc.type] = 4;
        }

        //public override string Texture => "Terraria/NPC_" + NPCID.BlackRecluse;
        public override void SetDefaults(){
            npc.aiStyle = -1;
            npc.lifeMax = 450;
            npc.width = 35;
            npc.height = 35;
            //drawOffsetX = -20;
            npc.knockBackResist = 1f;
            npc.HitSound = SoundID.NPCHit1;
			npc.DeathSound = null;
			npc.alpha = 0;
            npc.noGravity = true;
            npc.damage = 50;
            npc.lavaImmune = true;
            npc.noTileCollide = true;
            npc.defense = 10;
            npc.scale = 2f;
        }
        int count = 0;
        public override void AI(){
            
            npc.TargetClosest();
            npc.ai[0]++;
            if(npc.ai[0] == 1){
                for(int a = 0; a < 200; a++){
                if(Main.npc[a].type == ModContent.NPCType<VacuumWalker>() && Main.npc[a].active){
                    
                    count++;
                     
                }
            }
            }
            
            if(count <= 2){
                Formation();
            }
            else{
                Move();
            }
            
           
            if(npc.ai[0] < 300){
                //Move();
                if(npc.ai[0] == 150){
                    LeShootFast();
                }
            }
            else if(npc.ai[0] > 300 && npc.ai[0] < 600){
                //Charge();
                if(npc.ai[0] == 500){
                    LeShoot();
                }
                
            }
            
            if(npc.ai[0] > 600){
                npc.ai[0] = 3;
            }
            

        }
        
        
        private void Formation(){
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 npcPos = npc.Center;
                Vector2 weaverPos = Vector2.Zero;
                Vector2 direction = Main.player[npc.target].Center - npcPos;
                direction.Normalize();
                npc.rotation = direction.ToRotation();

                for(int i = 0;i < 200;i++){
                    if(Main.npc[i].type == ModContent.NPCType<SpaceSpooder>() && Main.npc[i].active){
                        weaverPos = Main.npc[i].Center;
                        
                        switch(count){
                            case 1:
                            npc.velocity = new Vector2(weaverPos.X , weaverPos.Y + 160f) - npcPos;
                            break;
                            case 2:
                            npc.velocity = new Vector2(weaverPos.X , weaverPos.Y - 160f) - npcPos;
                            break;
                            /*case 3:
                            npc.velocity = new Vector2(weaverPos.X  + 160f , weaverPos.Y) - npcPos;
                            break;*/
                        }
                        
                    } 
                }
                
            }
        }
        private void LeShootFast(){
        
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                
                //if(npc.ai[3] == 1){
                    //playerPos = Main.player[npc.target].Center;
                    //NPCpos = npc.Center;
                //}
                
                Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                //npc.velocity *= 0;
                int type = ModContent.ProjectileType<Projectiles.VenomOrb>();
                int damage = npc.damage/3;
                //Vector2 Helix = direction;
                //direction.Y -= 0.2f;
                
                
                    //Vector2 speedA = new Vector2(direction.X , direction.Y).RotatedByRandom(MathHelper.ToRadians(3));

                    Projectile.NewProjectile(pos , direction * 20f  , type , damage , 0f , Main.myPlayer);
            } 
        } 
        private void LeShoot(){
        
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                
                //if(npc.ai[3] == 1){
                    //playerPos = Main.player[npc.target].Center;
                    //NPCpos = npc.Center;
                //}
                
                Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                //npc.velocity *= 0;
                int type = ModContent.ProjectileType<Projectiles.VenomOrb>();
                int damage = npc.damage/3;
                //Vector2 Helix = direction;
                //direction.Y -= 0.2f;
                
                
                    //Vector2 speedA = new Vector2(direction.X , direction.Y).RotatedByRandom(MathHelper.ToRadians(3));
                    Projectile.NewProjectile(pos , direction * 12f  , type , damage , 0f , Main.myPlayer);
            }  
        }
        
        private void Move(){
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 pos = npc.Center;
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                npc.velocity.X = direction.X * 6;
                npc.velocity.Y = direction.Y * 6;
                npc.rotation = npc.velocity.ToRotation();
            }
        }
        private void Charge(){
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient){
                Vector2 pos = npc.Center;
                Lighting.AddLight(npc.Center , 1f , 0 , 1f);
                Vector2 targetPos = Main.player[npc.target].Center;
                Vector2 direction = targetPos - pos;

                Vector2 direction2 = targetPos - pos;
                direction2.Normalize();

                direction.Normalize();
                npc.velocity.X = direction.X * 12;
                npc.velocity.Y = direction.Y * 12;
                npc.rotation = npc.velocity.ToRotation();
                float dist = Vector2.Distance(targetPos , pos);
                float distLock = 320f;

                float distLock2 = 512f; //Kinda needed this to prevent the spooder from bugging out
                if(dist <= distLock2){
                    npc.velocity *= 0.5f;
                }
                if(dist <= distLock){
                    npc.velocity *= 0.1f;
                }
                
            }
        }
        public override void ScaleExpertStats(int numPlayera , float bossLifeScale){
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);
            
        }
        public override void FindFrame(int frameHeight){
            npc.frameCounter++;
            
            if(npc.frameCounter < 5){    //AMIMATION
                npc.frame.Y = 0 * frameHeight;
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
            else{
                npc.frameCounter = 0;
            }
        }
    }
}