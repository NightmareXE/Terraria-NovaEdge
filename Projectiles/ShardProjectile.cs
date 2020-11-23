using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NovaEdge.Dusts;
using Terraria.Graphics.Shaders;
using System;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;
//using Microsoft.Win32;

namespace NovaEdge.Projectiles
{
    
    public class ShardProjectile : ModProjectile
    {
        Vector2 targetPos = Vector2.Zero;
        bool target = false;
        Vector2 vel = Vector2.Zero;
        public override void SetStaticDefaults()
        {
            //ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] = -1;
            ProjectileID.Sets.YoyosMaximumRange[projectile.type] = 280f;
            ProjectileID.Sets.YoyosTopSpeed[projectile.type] = 30f;
        }

        public override void SetDefaults()
        {
            projectile.extraUpdates = 0;
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
            projectile.scale = 1f;
            projectile.aiStyle = 99;
        }


        public override void AI()
        {
            /*projectile.ai[0]++;
            if(projectile.ai[0] % 20 == 0)
            {
                ShootBolt(256f, 1f);
            }*/
            /*if(timer % 20 == 0){
                NPC npc = Main.npc[i].active ? Main.npc[i] : null;
            float dist = Vector2.Distance(npc.Center, projectile.Center);
            if(dist < 256)
            {
                Vector2 vel = npc.Center - projectile.Center;
                vel.Normalize();
                Projectile.NewProjectile(projectile.Center, vel, ProjectileID.MagnetSphereBolt, projectile.damage, 5f, projectile.owner);
            }
            }*/

            //projectile.localAI[1] += 1f;
            /*if (projectile.localAI[1] >= 6f)
            {
                float num3 = 400f;
                Vector2 velocity = projectile.velocity;
                Vector2 vector = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                vector.Normalize();
                vector *= (float)Main.rand.Next(10, 41) * 0.1f;
                if (Main.rand.Next(3) == 0)
                {
                    vector *= 2f;
                }
                velocity *= 0.25f;
                velocity += vector;
                for (int j = 0; j < 200; j++)
                {
                    if (Main.npc[j].CanBeChasedBy(this))
                    {
                        float num4 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                        float num5 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                        float num6 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num4) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num5);
                        if (num6 < num3 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[j].position, Main.npc[j].width, Main.npc[j].height))
                        {
                            num3 = num6;
                            velocity.X = num4;
                            velocity.Y = num5;
                            velocity -= projectile.Center;
                            velocity.Normalize();
                            velocity *= 8f;
                        }
                    }
                }
                velocity *= 0.8f;
                Projectile.NewProjectile(projectile.Center.X - velocity.X, projectile.Center.Y - velocity.Y, velocity.X, velocity.Y, 604, 60, 5, projectile.owner);
                projectile.localAI[1] = 0f;

            }*/
            ShootBolt(256 , 7);
        }
        private void ShootBolt(float distance , float velMult)
        {
            projectile.localAI[1]++;
            if(projectile.localAI[1] % 20 == 0){
                for (int i = 0; i < 200; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy(this, false))
                    {
                        float targetDist = Vector2.Distance(npc.Center, projectile.Center);
                        if ((targetDist < distance || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                        {
                            targetDist = distance;
                            target = true;
                            targetPos = npc.Center;
                        }
                    }
                }
                if (target)
                {
                    vel = targetPos - projectile.Center;
                    vel.Normalize();
                    Projectile.NewProjectile(projectile.Center, vel * velMult, ProjectileID.ShadowBeamFriendly, projectile.damage, 0f, Main.myPlayer);
                }
            }
            
        }
    }
}