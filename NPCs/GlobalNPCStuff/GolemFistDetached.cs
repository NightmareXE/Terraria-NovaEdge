using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NovaEdge.NPCs.GlobalNPCStuff
{
    public class GolemFistDetachedLeft : ModNPC
    {
        public override string Texture => "Terraria/NPC_" + NPCID.GolemFistLeft;
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

        }
    }
    public class GolemFistDetachedRight : ModNPC
    {
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

            if (NPC.golemBoss < 0)
            {
                //npc.StrikeNPC(9999, 0f, 0, false, false);
                npc.life = 0;

            }
            Dust.NewDustPerfect(npc.Right, DustID.Fire);

            npc.ai[0]++;
            npc.TargetClosest(true);
            Player player = Main.player[npc.target];
            if (npc.ai[0] < 600)
            {
                npc.damage = 0;
                npc.Center = new Vector2(player.Center.X + 160, player.Center.Y);
                if (npc.ai[0] > 540)
                {
                    //Dust.NewDustDirect(npc.Center, npc.width, npc.height, DustID.Fire);
                    Dust.NewDustPerfect(npc.Right, DustID.Fire);



                }
            }
            else if (npc.ai[0] > 600 && npc.ai[0] < 640)
            {
                npc.damage = 70;
                int sign = Math.Sign((player.Center.X + 64) - npc.Center.X);
                npc.velocity.X = sign * 8f;
                Dust.NewDustPerfect(npc.Right, DustID.Fire);


            }
            if (npc.ai[0] > 640)
            {
                npc.ai[0] = 0;
            }

        }
    }
}
