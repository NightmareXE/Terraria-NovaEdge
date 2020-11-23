using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Drawing.Drawing2D;

namespace NovaEdge.NPCs.GlobalNPCStuff
{
    public class GolemFistDetachedRight : ModNPC
    {
        public override string Texture => "Terraria/NPC_" + NPCID.GolemFistLeft;
        public bool dash = false;
        Vector2 oldPlayerPos;
        public override void SetDefaults()
        {
            npc.dontTakeDamage = true;
            npc.knockBackResist = 0;
            npc.lifeMax = 10;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.friendly = false;
            npc.width = 48;
            npc.height = 48;
            npc.DeathSound = null;
            npc.damage = 70;
        }
        public override void AI()
        {
            npc.TargetClosest();
            Player player = Main.player[npc.target];
            Vector2 destination = new Vector2(player.Center.X + 128, player.Center.Y);

            if (NPC.golemBoss < 0)
            {
                //npc.StrikeNPC(9999, 0f, 0, false, false);
                npc.life = 0;

            }

            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<GolemFistDetachedLeft>())
                {
                    npc.ai[0] = Main.npc[i].ai[0];
                    npc.ai[1] = Main.npc[i].ai[1];

                }
            }

            bool reached = Vector2.Distance(destination, npc.Center) < 32;
            if (!reached && !dash)
            {
                TryReachPos(player, 12, destination);
                FlameDust();
            }
            else if (reached)
            {
                dash = true;
            }

            if (dash)
            {
                Dash(player, 600, destination, 7);
            }
        }
        private void TryReachPos(Player player, int velMult, Vector2 destination)
        {

            npc.damage = 0;
            Vector2 velocity = destination - npc.Center;
            velocity.Normalize();
            npc.velocity = velocity * ((++npc.ai[1] == 120) ? velMult * 2 : velMult);
            npc.rotation = npc.velocity.ToRotation();
        }
        private void Dash(Player player, int time, Vector2 destination, float velMult)
        {
            npc.direction = 1;
            if (npc.ai[0] == time)
            {

                oldPlayerPos = new Vector2(player.Center.X - 128, player.Center.Y);

                Vector2 vel = oldPlayerPos - npc.Center;
                vel.Normalize();
                npc.velocity = vel * velMult;
                npc.rotation = npc.velocity.ToRotation();
                for (int i = 0; i < 3; i++)
                {
                    FlameDust();
                }
            }
            else
            {
                npc.rotation = 0;
                npc.Center = destination;
                npc.ai[0]++;
                FlameDust();
            }

            if (Vector2.Distance(oldPlayerPos, npc.Center) < 16)
            {
                npc.ai[0] = 0;
                npc.netUpdate = true;
                dash = false;
            }
        }
        private void FlameDust()
        {

            Vector2 dustPos = npc.Right.RotatedBy(npc.velocity.ToRotation(), npc.Center);
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

            dust = Main.dust[Terraria.Dust.NewDust(dustPos, 8, 8, 226, !dash ? npc.velocity.X * -0.3f : 4, !dash ? npc.velocity.Y * -0.3f : 0, 0, new Color(255, 255, 255), 1f)];
            if (Main.rand.NextBool(6))
            {
                dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(83, Main.LocalPlayer);

            }
            else dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(87, Main.LocalPlayer);



        }
        /*public override void AI()
        {
            if (NPC.golemBoss < 0)
            {
                //npc.StrikeNPC(9999, 0f, 0, false, false);
                npc.life = 0;
                
            }
            npc.ai[0]++;
            Dust.NewDustPerfect(npc.Left, DustID.Fire);

            for (int i = 0; i < 200; i++)
            {
                if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<GolemFistDetachedRight>())
                {
                    npc.ai[0] = Main.npc[i].ai[0];
                }
            }
            
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if(npc.ai[0] < 600)
            {
                npc.damage = 0;
                npc.Center = new Vector2(player.Center.X - 160, player.Center.Y);
                if(npc.ai[0] > 540)
                {
                    Dust.NewDustPerfect(npc.Left, DustID.Fire);



                }
            }
            else if(npc.ai[0] > 600 && npc.ai[0] < 640)
            {
                npc.damage = 70;
                int sign = Math.Sign(player.Center.X - npc.Center.X);
                npc.velocity.X = sign * 8f;
                Dust.NewDustPerfect(npc.Left, DustID.Fire);


            }
            if (npc.ai[0] > 640)
            {
                npc.ai[0] = 0;
            }

        }*/
    }
    public class GolemFistDetachedLeft : ModNPC
    {
        public bool dash = false;
        Vector2 oldPlayerPos;
        public override string Texture => "Terraria/NPC_" + NPCID.GolemFistRight;
        public override void SetDefaults()
        {
            npc.dontTakeDamage = true;
            npc.knockBackResist = 0;
            npc.lifeMax = 10;
            npc.noTileCollide = true;
            npc.noGravity = true;
            npc.lavaImmune = true;
            npc.friendly = false;
            npc.width = 48;
            npc.height = 48;
            npc.DeathSound = null;
            npc.damage = 70;
            npc.rotation = MathHelper.ToRadians(180f);
        }
        public override void AI()
        {
            npc.damage = 70;
            npc.TargetClosest();
            Player player = Main.player[npc.target];
            Vector2 destination = new Vector2(player.Center.X - 128, player.Center.Y);

            if (NPC.golemBoss < 0 || NPC.CountNPCS(ModContent.NPCType<GolemFistDetachedLeft>()) > 1)
            {
                //npc.StrikeNPC(9999, 0f, 0, false, false);
                npc.life = 0;

            }

            for(int i = 0; i < 200; i++)
            {
                if(Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<GolemFistDetachedRight>())
                {
                    npc.ai[0] = Main.npc[i].ai[0];

                }
            }

            bool reached = Vector2.Distance(destination, npc.Center) < 32;
            if (!reached && !dash)
            {
                TryReachPos(player, 13, destination);
                FlameDust();
            }

            else if (reached)
            {
                dash = true;
            }



            if (dash)
            {
                Dash(player, 600, destination, 6);
            }

        }
        private void TryReachPos(Player player, int velMult, Vector2 destination)
        {
            npc.ai[1]++;
            npc.damage = 0;
            Vector2 velocity = destination - npc.Center;
            velocity.Normalize();
            npc.velocity = velocity * ((npc.ai[1] > 120) ? velMult * 2 : velMult);
            npc.rotation = npc.velocity.ToRotation();
        }
        private void Dash(Player player, int time, Vector2 destination, float velMult)
        {
            npc.direction = -1;
            if (npc.ai[0] == time)
            {

                oldPlayerPos = new Vector2(player.Center.X + 128, player.Center.Y);

                Vector2 vel = oldPlayerPos - npc.Center;
                vel.Normalize();
                npc.velocity = vel * velMult;
                npc.rotation = npc.velocity.ToRotation();
                FlameDust();

            }
            else
            {
                npc.rotation = 0;
                npc.Center = destination;
                npc.ai[0]++;
                if (Main.rand.NextBool(6))
                {
                    FlameDust();

                }
            }

            if (Vector2.Distance(oldPlayerPos, npc.Center) < 16)
            {
                npc.ai[0] = 0;
                npc.netUpdate = true;
                dash = false;
            }
        }
        private void FlameDust()
        {

            Vector2 dustPos = npc.Left.RotatedBy(npc.velocity.ToRotation(), npc.Center);
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

            dust = Main.dust[Terraria.Dust.NewDust(dustPos, 8, 8, 226, npc.direction == 1 ? 5 : -5, npc.direction == 1 ? 5 : -5, 0, new Color(255, 255, 255), 1f)];
            if (Main.rand.NextBool(6))
            {
                dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(83, Main.LocalPlayer);

            }
            else dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(87, Main.LocalPlayer);



        }
    }
}
