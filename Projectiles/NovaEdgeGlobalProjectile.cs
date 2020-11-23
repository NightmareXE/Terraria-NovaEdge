using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Graphics.Shaders;
using Microsoft.Xna.Framework.Graphics;

namespace NovaEdge.Projectiles
{
    public class NovaEdgeGlobalProjectile : GlobalProjectile
    {



        public override bool InstancePerEntity => true;

        public override void SetDefaults(Projectile projectile)
        {
            if (projectile.type == 95)
            {

                projectile.timeLeft = 180;
                projectile.ignoreWater = true;
                projectile.maxPenetrate = -1;
            }
            if (projectile.type == ProjectileID.NightBeam && projectile.type == ProjectileID.LightBeam)
            {
                projectile.tileCollide = false;
            }
            if (projectile.type == ProjectileID.SporeTrap)
            {
                projectile.timeLeft = 180;
            }
            switch (projectile.type)
            {
                case ProjectileID.BloodyMachete:
                    projectile.aiStyle = -1;

                    break;
                case ProjectileID.PirateCaptain:
                case ProjectileID.SoulscourgePirate:
                case ProjectileID.OneEyedPirate:
                    projectile.extraUpdates = 1;
                    break;
                case ProjectileID.Flamarang:
                    projectile.aiStyle = -1;
                    break;
            }

        }
        bool curved = false;
        int chainedCount = 0;
        bool givenExtraUpdate = false;
        public bool shroomDart = false;
        

        public override void AI(Projectile projectile)
        {
            if (shroomDart)
            {
                
                if(++projectile.localAI[0] % 20 == 0)
                {
                    Projectile.NewProjectile(projectile.Center, Vector2.Zero, ProjectileID.Mushroom, projectile.damage, projectile.knockBack, projectile.owner);
                }
            }
            Player player = Main.player[projectile.owner];
            if (projectile.aiStyle == 3)
            {
                if (projectile.ai[0] != 0 && !givenExtraUpdate)
                {
                    projectile.extraUpdates = projectile.extraUpdates + 1;
                    givenExtraUpdate = true;
                }
            }
            switch (projectile.type)
            {
                case ProjectileID.CursedFlameFriendly:
                    projectile.velocity.Y -= .12f;
                    break;
                case ProjectileID.BloodyMachete:
                    Lighting.AddLight(projectile.Center, 0.2f, 0.1f, 0.1f);
                    BloodDust(projectile.Center, -projectile.velocity * 0.4f, new Vector2(projectile.width, projectile.height), 0.45f, 226, 1, true);
                    projectile.rotation += MathHelper.ToRadians(13);

                    if (projectile.localAI[1] == 0)
                    {

                    }
                    projectile.localAI[1]++;
                    if (projectile.localAI[1] > 5 && projectile.localAI[1] < 30 && !curved)
                    {
                        if (FindTargetPos(projectile, 160) != null)
                        {
                            bool isInRange = Vector2.Distance((Vector2)FindTargetPos(projectile, 160), projectile.Center) < 160f;

                            if (isInRange)
                            {
                                Vector2 vel = (Vector2)(FindTargetPos(projectile, 160) - projectile.Center);
                                vel.Normalize();
                                projectile.velocity = 14 * vel;
                                BloodDust(projectile.Center, new Vector2(Main.rand.NextFloat(-4, 4)), new Vector2(projectile.width, projectile.height), 1, 226, 3);
                                curved = true;
                            }

                        }
                    }
                    if (projectile.localAI[1] > 45)
                    {
                        Vector2 vel = player.Center - projectile.Center;
                        vel.Normalize();
                        projectile.velocity = vel * 14;
                        projectile.extraUpdates = 1;
                        if (Vector2.Distance(projectile.Center, player.Center) < 16) projectile.Kill();
                    }




                    break;
                case ProjectileID.Fireball when !player.ZoneJungle && NovaEdgeWorld.experimentalMode:
                    Vector2 move = Vector2.Zero;
                    float Distance = 384f;
                    bool LockOn = false;
                    for (int i = 0; i < 200; i++)
                    {
                        if (Main.player[i].active && !Main.npc[i].dontTakeDamage)
                        {
                            Vector2 newMove = Main.player[i].Center - projectile.Center;
                            float DistanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                            if (Distance > DistanceTo)
                            {
                                move = newMove;
                                Distance = DistanceTo;
                                LockOn = true;
                            }

                        }
                    }
                    if (LockOn)
                    {
                        AdjustMagnitude(ref move);
                        projectile.velocity = (10 * projectile.velocity + move) / 40f;
                        AdjustMagnitude(ref projectile.velocity);

                    }

                    break;
                case ProjectileID.Flamarang:
                    projectile.rotation += MathHelper.ToRadians(13);
                    for(int i = 0; i < 4;i++)
                    {
                        Dust.NewDust(projectile.Center, projectile.width, projectile.height, DustID.Fire, projectile.velocity.X * -0.3f, projectile.velocity.X * -0.3f);
                    }
                    projectile.localAI[1]++;
                    if (projectile.localAI[1] > 50)
                    {
                        Vector2 vel = player.Center - projectile.Center;
                        vel.Normalize();
                        projectile.velocity = vel * 14;
                        projectile.extraUpdates = 1;
                        if (Vector2.Distance(projectile.Center, player.Center) < 16) projectile.Kill();
                    }
                    break;
            }
        }

        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {

            
            switch (projectile.type)
            {
                case ProjectileID.Flamarang:
                case ProjectileID.BloodyMachete:
                    projectile.localAI[1] = 91;
                    return false;
                
                    
                    
                default:
                    return base.OnTileCollide(projectile, oldVelocity);
            }
            
            

        }
        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude < 6f)
            {
                vector *= 6f / magnitude;
            }
        }
        private Vector2? FindTargetPos(Projectile projectile, float targetDist , NPC makeExceptionForThis = null)
        {
            bool target = false;
            for (int i = 0; i < 200; i++)
            {
               if(Main.npc[i] != makeExceptionForThis && Main.npc[i].active)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy(this, false))
                    {
                        float distance = Vector2.Distance(npc.Center, projectile.Center);
                        if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                        {
                            targetDist = distance;
                            target = true;
                            return npc.Center;
                        }
                    }
                }

                
   

            }
            return null;

        }
        
        NPC oldTarget = null;
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (shroomDart && crit)
            {
                for(int i = 0; i < Main.rand.Next(3, 6); i++)
                {
                    Vector2 spawnPos = projectile.Center + new Vector2(Main.rand.Next(-64, 65), Main.rand.Next(-64, 65));
                    Vector2 vel = target.Center - spawnPos;
                    vel.Normalize();
                    Projectile.NewProjectile(spawnPos, vel * Main.rand.NextFloat(4, 7), ProjectileID.Mushroom, damage, knockback, projectile.owner);
                }
            }
            switch (projectile.type)
            {
                case ProjectileID.MeteorShot:
                    target.AddBuff(BuffID.OnFire, 240);
                    projectile.maxPenetrate = 3;
                    break;
                case 5:
                    int pierceCount = 0;
                    pierceCount++;
                    projectile.damage -= (int)((pierceCount * 0.1) * damage);
                    if (pierceCount < 8)
                    {
                        pierceCount = 8;
                    }
                    break;
                case 704:
                    int pierceCount1 = 0;
                    pierceCount1++;
                    projectile.damage -= (int)((pierceCount1 * 0.1) * damage);
                    if (pierceCount1 < 8)
                    {
                        pierceCount1 = 8;
                    }
                    break;
                case ProjectileID.BloodyMachete:
                    BloodDust(projectile.Center, new Vector2(Main.rand.NextFloat(-4, 4)), new Vector2(projectile.width, projectile.height), 1, 226, 6);
                    projectile.localAI[1] = 91;
                    break;
                case ProjectileID.Flamarang:
                    if (FindTargetPos(projectile, 256 , target) != null)
                    {
                        bool isInRange = Vector2.Distance((Vector2)FindTargetPos(projectile, 256 , target), projectile.Center) < 256f;

                        if (isInRange && chainedCount < 5)
                        {
                            Vector2 vel = (Vector2)(FindTargetPos(projectile, 256 , target) - projectile.Center);
                            vel.Normalize();
                            projectile.velocity = 14 * vel;
                            //BloodDust(projectile.Center, new Vector2(Main.rand.NextFloat(-4, 4)), new Vector2(projectile.width, projectile.height), 1, 226, 3);
                            chainedCount += 1;
                            //projectile.localAI[1] = 0;
                        }


                    }
                    else projectile.localAI[1] = 90;
                   
                    BloodDust(projectile.Center, new Vector2(Main.rand.NextFloat(-4, 4)), new Vector2(projectile.width, projectile.height), 1, 6, 6);


                    break;


            }
           
        }

        //Dusts
        private void BloodDust(Vector2 pos, Vector2 vel, Vector2 dimensions, float spawnRate = 1f, int type = 226, int amount = 1, bool white = false)
        {
            for (int i = 0; i < amount; i++)
            {
                if (Main.rand.NextFloat() < spawnRate)
                {
                    Dust dust;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                    dust = Main.dust[Terraria.Dust.NewDust(pos, (int)dimensions.X, (int)dimensions.Y, type, vel.X, vel.Y, 0, new Color(255, 255, 255), 1f)];
                    if (white && Main.rand.NextBool(9))
                    {
                        dust.shader = GameShaders.Armor.GetSecondaryShader(15, Main.LocalPlayer);

                    }
                    else dust.shader = GameShaders.Armor.GetSecondaryShader(59, Main.LocalPlayer);

                }

            }


        }

    }
}