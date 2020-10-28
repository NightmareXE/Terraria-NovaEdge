using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NovaEdge.NPCs.Chillax
{
    [AutoloadBossHead]

    public class Chillax : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 24; //first 4 are flying , rest are freeze attack
            NPCID.Sets.TrailCacheLength[npc.type] = 10;
            NPCID.Sets.TrailingMode[npc.type] = 0;

        }
        //public override string Texture => "Terraria/NPC_" + NPCID.SkeletronHead;
        public override void SetDefaults()
        {
            npc.aiStyle = -1;
            npc.alpha = 0;
            npc.width = npc.height = 80;
            npc.damage = 40;
            npc.lifeMax = 5000;
            npc.knockBackResist = 0;
            npc.lavaImmune = true;
            npc.npcSlots = 5;
            npc.boss = true;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = null;
            npc.noGravity = true;
            npc.noTileCollide = true;
        }
        private Vector2 oldPlayerPos = Vector2.Zero;
        private bool freezing = false;
        private bool dashing = false;
        private float P1Timer
        {
            get => npc.ai[0];
            set => npc.ai[0] = value;
        }
        private bool P1 = false;
        private bool frozen = false;

        public override void AI()
        {
            npc.noTileCollide = true;

            dashing = false;
            freezing = false;
            frozen = false;
            npc.TargetClosest();
            Player player = Main.player[npc.target];

            if (npc.target < 0 || npc.target == 255 || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                npc.velocity.Y -= 0.1f;
                npc.rotation = npc.velocity.ToRotation();

                if (npc.timeLeft > 60)
                {
                    npc.timeLeft = 60;
                }
            }
            int sign = Math.Sign(player.Center.X - npc.Center.X);
            npc.direction = npc.spriteDirection = sign;


            if (npc.life > npc.lifeMax / 5 * 3) //60% hp
            {
                P1Timer++;
                P1 = true;
                if(P1Timer < 420) //7 Seconds
                {
                    Hover(player);
                    if(P1Timer % 60 == 0)
                    {
                        Shoot(npc.Center, ProjectileID.FrostBlastHostile, 6, npc.damage / 2, 4f, player);
                    }
                }
                else if(P1Timer < 720) // + 5 secs
                {
                    FallDown(player , 5 , 180);
                }
                else if(P1Timer < 900)
                {
                    Dash(player, 7, 40, 20 , false);
                }

                if(P1Timer == 901)
                {
                    P1Timer = 0;
                    npc.netUpdate = true;
                }

            }
            else if(npc.life < npc.lifeMax/5 * 3)
            {
                npc.ai[3]++;
                if(npc.ai[3] < 300)
                {
                    if(npc.ai[3] % 30 == 0)
                    {
                        Shoot(npc.Center, ProjectileID.FrostBlastHostile, 6, npc.damage / 2, 4f, player);

                    }
                }
                else if(npc.ai[3] < 600)
                {
                    Dash(player, 7, 40, 20 , true);
                }
                else if(npc.ai[3] < 900)
                {
                    FallDown(player, 5, 180);
                }

                if(npc.ai[3] == 901)
                {
                    npc.ai[3] = 0;
                    npc.netUpdate = true;
                }

            }
            else if(npc.life < npc.lifeMax / 5)
            {
                npc.ai[4]++;
                if(npc.ai[4] < 420)
                {
                    Dash(player, 7, 40, 20 , true);

                }
                else if(npc.ai[4] < 540)
                {
                    FallDown(player, 5, 120);
                }
                else if(npc.ai[4] < 690)
                {
                    Hover(player);
                    if(npc.ai[4] % 45 == 0)
                    {
                        Shoot(npc.Center, ProjectileID.FrostBlastHostile, 6, npc.damage / 2, 4f, player);
                    }
                }
                if(npc.ai[4] == 541)
                {
                    npc.ai[4] = 0;
                    npc.netUpdate = true;
                }
            }
        }

        private void Hover(Player player)
        {
            if (npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {

                if (npc.position.Y > player.position.Y - 250f)
                {
                    if (npc.velocity.Y > 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                    }
                    npc.velocity.Y = npc.velocity.Y - 0.02f;
                    if (npc.velocity.Y > 2f)
                    {
                        npc.velocity.Y = 2f;
                    }
                }

                if (npc.position.Y < player.position.Y - 250f)
                {
                    if (npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y = npc.velocity.Y * 0.98f;
                    }
                    npc.velocity.Y = npc.velocity.Y + 0.02f;
                    if (npc.velocity.Y < -2f)
                    {
                        npc.velocity.Y = -2f;
                    }
                }

                if (npc.position.X + npc.width / 2 > player.position.X + player.width / 2)
                {
                    if (npc.velocity.X > 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.98f;
                    }
                    npc.velocity.X = npc.velocity.X - 0.05f;
                    if (npc.velocity.X > 8f)
                    {
                        npc.velocity.X = 8f;
                    }
                }
                if (npc.position.X + npc.width / 2 < player.position.X + player.width / 2)
                {
                    if (npc.velocity.X < 0f)
                    {
                        npc.velocity.X = npc.velocity.X * 0.98f;
                    }
                    npc.velocity.X = npc.velocity.X + 0.05f;
                    if (npc.velocity.X < -8f)
                    {
                        npc.velocity.X = -8f;
                    }
                }

            }


        }

        //Hostile projectiles do double damage
        private void Shoot(Vector2 spawnPos, int type, int velMultiplier, int damage, float knockBack, Player player)
        {
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 vel = player.Center - spawnPos;
                vel.Normalize();
                Projectile.NewProjectile(spawnPos, vel * velMultiplier, type, damage, knockBack, Main.myPlayer);
            }
            

        }

        private void FallDown(Player player , float Yvel , int freezeTime)
        {

            npc.noTileCollide = false;
            npc.ai[1]++;
            if(npc.ai[1] < freezeTime)
            {
                freezing = true;

                npc.velocity.X = 0;
                npc.velocity.Y = Yvel;
                
            }
            if(npc.ai[1] < freezeTime + 120)
            {
                frozen = true;
            }

            if(npc.ai[1] == freezeTime + 120)
            {
                npc.ai[1] = 0;
                npc.netUpdate = true;
            }
        }
        private int timer = 0;
        private void Dash(Player player, int velMultiplier, int delay, int cooldownTime, bool iceTrail)
        {
            dashing = true;
            if(npc.HasValidTarget && Main.netMode != NetmodeID.MultiplayerClient)
            {
                npc.ai[2]++;
                if(npc.ai[2] % delay == 0)
                {
                    oldPlayerPos = player.Center;
                }

                if(npc.ai[2] < delay)
                {
                    Vector2 dashVel = oldPlayerPos - npc.Center;
                    dashVel.Normalize();
                    npc.velocity.X = dashVel.X * velMultiplier;
                    npc.velocity.Y = dashVel.Y * velMultiplier;
                    npc.rotation = npc.velocity.ToRotation();



                }
                if (npc.ai[2] > delay)
                {
                    npc.velocity *= 0;
                    npc.position = npc.oldPosition;
                }

                if(npc.ai[2] > delay + cooldownTime)
                {
                    npc.ai[2] = 0;
                    npc.netUpdate = true;
                }
                if (iceTrail)
                {
                    timer++;
                    if(timer % 20 == 0)
                    {
                        int proj = Projectile.NewProjectile(npc.Center, Vector2.Zero, ProjectileID.FrostBlastHostile, npc.damage / 2, 4f, Main.myPlayer);
                        Main.projectile[proj].timeLeft = 15;
                    }
                    for (int i = 0;i < 4;i++)
                    {
                        Vector2 spawnPos = new Vector2(Main.rand.NextBool(2) ? npc.Center.X - 16 : npc.Center.X + 16, Main.rand.NextBool(2) ? npc.Center.Y - 16 : npc.Center.Y + 16);
                        Dust.NewDustPerfect(spawnPos, 176);

                    }


                }
                npc.rotation = npc.velocity.ToRotation();
            }
        }
        public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {

            if (freezing)
            {
                damage = 1;

                if (projectile.penetrate == 1 || projectile.penetrate == 0)
                {
                    projectile.velocity = projectile.velocity * -1; //THis should flip direction
                }

            }

        }
        int frameNumHover = 0;
        int frameNumFreezing = 9;
        int frameNumFrozen = 23;
        public override void FindFrame(int frameHeight)
        {
            if (!freezing)
            {
                npc.frameCounter++;
                if(npc.frameCounter % 10 == 0)
                {
                    frameNumHover++;
                }
                npc.frame.Y = frameHeight * frameNumHover;

                if(frameNumHover > 9)
                {
                    frameNumHover = 0;
                }

                if(npc.frameCounter > 30)
                {
                    npc.frameCounter = 0;
                }
            }
            else if (freezing)
            {
                npc.frameCounter++;
                if (npc.frameCounter % 10 == 0)
                {
                    frameNumFreezing++;
                }
                npc.frame.Y = frameHeight * frameNumFreezing;

                if (frameNumFreezing > 23)
                {
                    frameNumFreezing = 23;
                }

                
            }
            else if (frozen)
            {
                npc.frame.Y = frameHeight * frameNumFrozen;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (dashing)
            {
                Vector2 drawOrigin = new Vector2(Main.npcTexture[npc.type].Width * 0.5f, npc.height * 0.5f);
                for (int k = 0; k < npc.oldPos.Length; k++)
                {
                    Vector2 drawPosition = npc.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, npc.gfxOffY);
                    Color color = /*.GetAlpha(lightColor)*/ new Color(50 , 50 , 100) * ((float)(npc.oldPos.Length - k) / (float)npc.oldPos.Length);
                    spriteBatch.Draw(Main.npcTexture[npc.type], drawPosition, null, color, npc.rotation, drawOrigin, npc.scale, SpriteEffects.None, 0f);
                }
            }
            return true;

        }
        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            scale = 1.5f;
            return null;
        }



    }

}
