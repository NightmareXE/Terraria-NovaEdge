using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Graphics.Shaders;
using NovaEdge.Items.SpaceSpooder;
using Microsoft.Xna.Framework.Graphics;

namespace NovaEdge.NPCs.SpaceSpooder
{
    [AutoloadBossHead]

    public class SpaceSpooder : ModNPC
    {


        private Vector2 oldPlayerPos = Vector2.Zero;
        private bool dashing = false;


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Weaver");
            Main.npcFrameCount[npc.type] = 5;
            NPCID.Sets.TrailCacheLength[npc.type] = 10;
            NPCID.Sets.TrailingMode[npc.type] = 0;



        }
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.width = 160;
            npc.height = 160;
           
            //aiType = NPCID.Zombie;
            npc.lifeMax = 15000;
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

            for (int j = 0; j < npc.buffImmune.Length; j++)
            {
                npc.buffImmune[j] = true;
            }
            music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/VoidBoiTheme");
            musicPriority = MusicPriority.BossMedium;

        }

        public override void ScaleExpertStats(int numPlayera, float bossLifeScale)
        {
            npc.lifeMax = (int)(npc.lifeMax * 0.75f * bossLifeScale);
            npc.damage = (int)(npc.damage * 0.65f);


        }
        private bool laserCircle = false;
        private bool spawnDashDone = false;

        public override void AI()
        {  //START DASH Being jank
            spawnDashDone = false;
            laserCircle = false;
            dashing = false;
            npc.TargetClosest();
            
            npc.dontTakeDamage = false;
        
            Player player = Main.player[npc.target];
            //Despawning , 
            BoosterDust();
            


            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || !Main.player[npc.target].active)
            {
                npc.TargetClosest(false);
                npc.velocity.Y -= 0.1f;
                npc.rotation = npc.velocity.ToRotation();

                if (npc.timeLeft > 60)
                {
                    npc.timeLeft = 60;
                }
            }


            if (npc.life > npc.lifeMax / 2.5f)
            {

                npc.ai[0]++;
                  
                if (npc.ai[0] < 300)
                {
                    SpawnDash(player , 9f , 128);
                }
                else if (npc.ai[0] < 555)
                {

                    Move(player , 5);
                    if (npc.ai[0] % 45 == 0 && npc.ai[0] > 360)
                    {
                        PredictionShot(player, 12, ModContent.ProjectileType<Projectiles.VenomOrb>(), npc.damage / 4, 3f, 1);
                        //Shoot(player , new Vector2(npc.Center.X + 32 , npc.Center.Y) , ModContent.ProjectileType<Projectiles.VenomOrb>() , npc.damage/3 , 4);
                    }
                }
                else if (npc.ai[0] < 735)
                {
                    Dash(player, 8, 40, 20);
                }
                else if (npc.ai[0] < 900)
                {
                    CircleMotion(player , 4 , 736);
                    if (npc.ai[0] % 50 == 0)
                    {
                        Shoot(player , npc.Center , ModContent.ProjectileType<HoverMine>() , npc.damage/3 , 3f , 30 , true);
                    }


                }
                
                if (npc.ai[0] > 900)
                {
                    npc.ai[0] = 301;
                    npc.netUpdate = true;

                }
            }
            else if (npc.life <= npc.lifeMax / 2.5f)
            {
                Lighting.AddLight(npc.Center, 2f, 0f, 2f);
                npc.defense = 25;


                /*if(!SpawnDashDone2){
                    SpawnDash();
                }
                if(SpawnDashDone){*/
                npc.ai[2]++;
                //}
                if (npc.ai[2] < 300)
                {
                    SpawnDash(player , 9f , 128);
                }
                if (npc.ai[2] < 540 && npc.ai[2] > 300)
                {
                    Move(player , 5);
                    //npc.velocity *= 1.2f;
                    if (npc.ai[2] % 60 == 0 && npc.ai[2] > 360)
                    {
                        Shoot(player , npc.Center , ProjectileID.EyeBeam , npc.damage/3  , 3f , 40 , false , 8);
                    }
                }
                if (npc.ai[2] > 600 && npc.ai[2] < 960)
                {
                    LaserSpin(player);
                }
                else if (npc.ai[2] > 960 && npc.ai[2] < 1010)
                {
                    if (npc.ai[2] == 980)
                    {
                        WeaverSpawn();
                    }
                    npc.velocity *= 0.05f;
                }
                else if (npc.ai[2] > 1010)
                {
                    npc.ai[2] = 301;
                    npc.netUpdate = true;
                }


            }


            //npc.ai[3] += 1f; //TIMER FOR DASH SUBPHASE

        }
        private void BoosterDust(int amount = 1)
        {
            Vector2 dustPos = npc.Left.RotatedBy(npc.velocity.ToRotation(), npc.Center);
           
            Dust dust;
            for(int i = 0; i < (int)(Math.Abs(npc.velocity.X) +  Math.Abs(npc.velocity.Y))/10 + amount; i++)
            {
                dust = Main.dust[Terraria.Dust.NewDust(new Vector2(dustPos.X, dustPos.Y - 20), 16, 16, 226, -npc.velocity.X, -npc.velocity.Y, 0, new Color(255, 255, 255), 1f)];
                dust.shader = GameShaders.Armor.GetSecondaryShader(38, Main.LocalPlayer);
            }
            Dust dust1;
            for (int i = 0; i < (int)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) / 10 + amount; i++)
            {
                dust1 = Main.dust[Terraria.Dust.NewDust(new Vector2(dustPos.X, dustPos.Y + 20), 16, 16, 226, -npc.velocity.X, -npc.velocity.Y, 0, new Color(255, 255, 255), 1f)];
                dust1.shader = GameShaders.Armor.GetSecondaryShader(38, Main.LocalPlayer);
            }


        }
        private void LaserSpin(Player player)
        {
            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                laserCircle = true;
                npc.ai[3]++;
                int type = 83;
                int damage = npc.damage / 3;
                npc.velocity *= 0;
                npc.position = npc.oldPosition;


                Vector2 direction = player.Center - npc.Center;
                direction.Normalize();
               
                npc.rotation = direction.ToRotation();
                if (npc.ai[2] > 899)
                {
                    npc.rotation = direction.ToRotation();
                }
                //Vector2 Helix = direction;
                //direction.Y -= 0.2f;

                //for(int a = 0; a < 36; a++){
                if (npc.ai[2] % 12 == 0)
                {
                    Vector2 speedA = new Vector2(direction.X, direction.Y);//.RotatedBy(MathHelper.ToRadians(10));
                    Projectile.NewProjectile(npc.Center, speedA * 14f, type, damage / 2, 0f, Main.myPlayer);
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
        private void Shoot(Player player, Vector2 spawnPos, int type, int damage, float knockBack, int spread = 0, bool randomSpread = true, int projNum = 1)
        {

            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {

                Vector2 direction = player.Center - npc.Center;
                direction.Normalize();
                Vector2 speedA = new Vector2(direction.X, direction.Y);
                if (spread > 0)
                {
                    if (!randomSpread)
                    {
                        speedA = new Vector2(direction.X, direction.Y).RotatedBy(spread);

                    }
                    if (randomSpread)
                    {
                        speedA = new Vector2(direction.X, direction.Y).RotatedByRandom(spread);

                    }

                }


                for (int i = 0; i < projNum; i++)
                {
                    if (spread > 0)
                    {
                        if (!randomSpread)
                        {
                            speedA = new Vector2(direction.X, direction.Y).RotatedBy(spread);

                        }
                        if (randomSpread)
                        {
                            speedA = new Vector2(direction.X, direction.Y).RotatedByRandom(spread);

                        }

                    }
                    Projectile.NewProjectile(npc.Center, speedA, type, damage, 0f, Main.myPlayer);

                }



                /*NPC.NewNPC((int)(targetPos.X + 256) , (int)targetPos.Y , ModContent.NPCType<MechEgg>());
                NPC.NewNPC((int)(targetPos.X - 256) , (int)targetPos.Y , ModContent.NPCType<MechEgg>());
                NPC.NewNPC((int)targetPos.X , (int)(targetPos.Y + 256) , ModContent.NPCType<MechEgg>());*/
            }



        }

        private void WeaverSpawn()
        {

            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
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
                NPC.NewNPC((int)(npc.Center.X), (int)(npc.Center.Y - 160f), ModContent.NPCType<MechEggSpooder>());
                NPC.NewNPC((int)npc.Center.X, (int)(npc.Center.Y + 160f), ModContent.NPCType<MechEggSpooder>());
            }
        }
        private void Move(Player player, float velMult)
        {
            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {

                Vector2 direction = player.Center - npc.Center;
                Vector2 dustPos = new Vector2(player.Center.X, player.Center.Y - 320f);
                float dist = Vector2.Distance(player.Center, npc.Center);

                //Teleportation
                if (dist > 1600f)
                {
                    npc.ai[3]++;
                    if (npc.ai[3] < 60)
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            Dust.NewDustDirect(dustPos, npc.width, npc.height, 27);
                        }
                    }
                    if (npc.ai[3] == 60)
                    {
                        npc.position = dustPos;
                    }
                }
                direction.Normalize();
                npc.velocity = direction * velMult;
                float rot = npc.velocity.ToRotation();
                npc.rotation = rot;
            }

        }
        private void SpawnDash(Player player, float velMult, float stopDist)
        {
            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {

                Vector2 move = player.Center - npc.Center;
                move.Normalize();
                npc.dontTakeDamage = true;
                npc.velocity = move * velMult;
                npc.rotation = npc.velocity.ToRotation();
                float dist = Vector2.Distance(player.Center, npc.Center);
                if (dist < stopDist)
                {
                    npc.velocity *= 0f;
                    npc.position = npc.oldPosition;
                    npc.ai[0] = 300;


                }



            }
        }
        Vector2 playerPos = Vector2.Zero;

        //736
        private void CircleMotion(Player player, float speed , float startAINum)
        {
            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                if(npc.ai[0] == startAINum)
                {
                    playerPos = player.Center;
                }
                npc.ai[3] += MathHelper.ToRadians(speed);
                Vector2 circle = playerPos + new Vector2(0, 208).RotatedBy(npc.ai[3]);
                //npc.Center = circle;
                Vector2 vel = circle - npc.Center;
                vel.Normalize();
                npc.velocity = vel * 12f;
                //Vector2 direction = player.Center - npc.Center;
                //direction.Normalize();
//float rot = direction.ToRotation();
                npc.rotation = npc.velocity.ToRotation();



            }

        }
        private void Dash(Player player, int velMultiplier, int delay, int cooldownTime )
        {
            dashing = true;
            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (npc.ai[2] % delay == 0)
                {
                    oldPlayerPos = player.Center;
                }
                npc.ai[2]++;

                if (npc.ai[2] < delay)
                {
                    Vector2 dashVel = oldPlayerPos - npc.Center;
                    dashVel.Normalize();
                    npc.velocity = dashVel * velMultiplier;
                    npc.rotation = npc.velocity.ToRotation();
                    



                }
                if (npc.ai[2] > delay)
                {
                    npc.velocity *= 0;
                    npc.position = npc.oldPosition;
                }

                if (npc.ai[2] > delay + cooldownTime)
                {
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                }

            }
        }
        
        private void PredictionShot(Player player, float velMult, int type, int damage, float knockBack, int projNum, int spread = 3)
        {
            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {

                //if(npc.ai[3] == 1){
                //playerPos = Main.player[npc.target].Center;
                //NPCpos = npc.Center;
                //}
                int signX = Math.Sign(player.velocity.X);
                int signY = Math.Sign(player.velocity.Y);

                Vector2 pos = new Vector2(npc.Center.X + 40, npc.Center.Y);
                Vector2 targetPos = new Vector2(player.Center.X + (signX * Math.Abs(player.velocity.X) * 64), player.Center.Y + (Math.Abs(player.velocity.Y) * 64 * signY));
                Vector2 direction = targetPos - pos;
                direction.Normalize();
                //npc.velocity *= 0;

                //Vector2 Helix = direction;
                //direction.Y -= 0.2f;
                for (int q = 0; q < projNum; q++)
                {
                    Vector2 speedA = new Vector2(direction.X, direction.Y).RotatedByRandom(MathHelper.ToRadians(spread));

                    Projectile.NewProjectile(pos, speedA * velMult, type, damage, 0f, Main.myPlayer);
                }


            }
        }
        int index = 0;

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter++;
            if (npc.frameCounter % 10 == 0)
            {
                index++;
            }
            npc.frame.Y = frameHeight * index;

            if (npc.frameCounter > 50)
            {
                npc.frameCounter = 0;
            }

            if (index > 4)
            {
                index = 0;
            }
        }
        public override void NPCLoot()
        {
            /*if (!NovaEdgeWorld.downedVoidWeaver) {
				NovaEdgeWorld.downedVoidWeaver = true;
				if (Main.netMode == NetmodeID.Server) {
					NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
				}
			}*/ //TEMPLATE FOR DOWNED VARIABLE 
            if (Main.expertMode)
            {
                npc.DropBossBags();
            }
            else
            {
                int choice = Main.rand.Next(1, 5);

                switch (choice)
                {
                    case 1:
                        Item.NewItem(npc.getRect(), ItemType<BoosterBlade>());
                        break;
                    case 2:
                        Item.NewItem(npc.getRect(), ItemType<HoloSpider>());
                        break;
                    case 3:
                        Item.NewItem(npc.getRect(), ItemType<MechEggStaff>());
                        break;
                    case 4:
                        Item.NewItem(npc.getRect(), ItemType<RepurposedLegs>());
                        break;


                }
            }

            //DROPS , gonna be done later
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }
        public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            if (laserCircle)
            {
                damage = (int)(damage * 0.6f);
            }
        }
        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (laserCircle)
            {
                damage = (int)(damage * 0.6f);

            }
        }
       /*public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (dashing)
            {
                Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width * 0.5f, npc.height * 0.5f);
                for (int k = 0; k < npc.oldPos.Length; k++)
                {
                    Vector2 drawPosition = npc.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
                    Color color = /*.GetAlpha(lightColor) new Color(100, 80, 100) * ((float)(npc.oldPos.Length - k) / (float)npc.oldPos.Length);
                    spriteBatch.Draw(Main.npcFr, drawPosition, null, color, npc.rotation, drawOrigin, npc.scale, SpriteEffects.None, 0f);
                }
            }
            return true;
        } */
        
        
        //DR for spinny phase




    }
}
