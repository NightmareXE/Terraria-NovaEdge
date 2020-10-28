using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using System;
using Terraria;
using Terraria.Enums;
using Terraria.ModLoader;

namespace NovaEdge.NPCs.GlobalNPCStuff
{
    public class GolemSunBeam : ModProjectile
    {
        public float Distance
        {
            get => projectile.ai[0];
            set => projectile.ai[0] = value;
        }
        public override void SetDefaults()
        {
            projectile.width = 10;
            projectile.height = 10;
            projectile.hostile = true;
            projectile.penetrate = -1;
            //projectile.alpha = 0;
            projectile.tileCollide = false;
            //projectile.magic = true;
            projectile.hide = true;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            DrawLaser(spriteBatch, Main.projectileTexture[projectile.type], Main.player[projectile.owner].Center,
                projectile.velocity, 10, projectile.damage, -1.57f, 1f, 1000f, Color.White, 60);

            return false;
        }
        private void DrawLaser(SpriteBatch spriteBatch, Texture2D texture, Vector2 start, Vector2 unit, float step, int damage, float rotation = 0f, float scale = 1f, float maxDist = 2000f, Color color = default, int transDist = 50)
        {
            float rot = unit.ToRotation() + rotation;

            //Laser Body
            for (float i = transDist; i <= Distance; i += step)
            {
                Color color2 = Color.White;
                var origin = start + i * unit;
                spriteBatch.Draw(texture, origin - Main.screenPosition,
                    new Rectangle(0, 26, 28, 26), i < transDist ? Color.White : color2, rot,
                    new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);
            }
            //Head
            spriteBatch.Draw(texture, start + unit * (transDist - step) - Main.screenPosition,
                new Rectangle(0, 0, 28, 26), Color.White, rot, new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);

            //Tail
            spriteBatch.Draw(texture, start + (Distance + step) * unit - Main.screenPosition,
                new Rectangle(0, 52, 28, 26), Color.White, rot, new Vector2(28 * .5f, 26 * .5f), scale, 0, 0);

        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.immuneTime += 30;
        }

        public override void AI()
        {

            if (NPC.golemBoss > 0)
            {
                NPC npc = Main.npc[NPC.golemBoss];
                Player player = Main.player[projectile.owner];
                projectile.position = npc.Center + projectile.velocity * 60;
                projectile.timeLeft = 2;

                UpdateLaser(player, npc);
                CastLights();
                SetLaserPosition(player, npc);

            }



        }
        private void UpdateLaser(Player player, NPC npc)
        {
            // Multiplayer support here
            if (projectile.owner == Main.myPlayer)
            {
                Vector2 diff = player.Center - npc.Center;
                diff.Normalize();
                projectile.velocity = diff;
                projectile.direction = Main.MouseWorld.X > player.position.X ? 1 : -1;
                projectile.netUpdate = true;
            }
        }
        private void CastLights()
        {
            // Cast a light along the line of the laser
            DelegateMethods.v3_1 = new Vector3(0.8f, 0.8f, 1f);
            Utils.PlotTileLine(projectile.Center, projectile.Center + projectile.velocity * (Distance - 60), 26, DelegateMethods.CastLight);
        }
        private void SetLaserPosition(Player player, NPC npc)
        {
            for (Distance = 60; Distance <= 2200f; Distance += 5f)
            {
                var start = npc.Center + projectile.velocity * Distance;
                if (!Collision.CanHit(npc.Center, 1, 1, start, 1, 1))
                {
                    Distance -= 5f;
                    break;
                }
            }
        }
    }

}