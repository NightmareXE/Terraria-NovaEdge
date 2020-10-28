using Terraria;
using Microsoft.Xna.Framework;
using System;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Projectiles{
    public class NovaEdgeGlobalProjectile : GlobalProjectile{
        
        


       
        public override void SetDefaults(Projectile projectile){
            if(projectile.type == 95){
               
                projectile.timeLeft = 180;
                projectile.ignoreWater = true;
                projectile.maxPenetrate = -1;
            }
            if(projectile.type == ProjectileID.NightBeam && projectile.type == ProjectileID.LightBeam)
            {
                projectile.tileCollide = false;
            }
            if(projectile.type == ProjectileID.SporeTrap)
            {
                projectile.timeLeft = 180;
            }
           
        }
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            if (projectile.type == 95)
            {
                projectile.velocity.Y -= 0.12f;

            }
            switch (projectile.type)
            {
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

        public override void OnHitNPC(Projectile projectile , NPC target , int damage  , float knockback , bool crit){
            switch (projectile.type)
            {
                case ProjectileID.MeteorShot:
                    target.AddBuff(BuffID.OnFire , 240);
                    projectile.maxPenetrate = 3;
                    break;
                case 5:
                    int pierceCount = 0;
                    pierceCount++;
                    projectile.damage -= (int)((pierceCount*0.1) * damage);
                    if(pierceCount <8){
                        pierceCount = 8;
                    }
                    break;
                case 704:
                    int pierceCount1 = 0;
                    pierceCount1++;
                    projectile.damage -= (int)((pierceCount1*0.1) * damage);
                    if(pierceCount1 <8){
                        pierceCount1 = 8;
                    }
                    break;
               
                    
            }   
        }
        
       
    }
}