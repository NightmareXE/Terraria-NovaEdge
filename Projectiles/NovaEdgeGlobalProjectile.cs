using Terraria;
using Microsoft.Xna.Framework;
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
           
        }
        public override void AI(Projectile projectile){
            if(projectile.type == 95){
                projectile.velocity.Y -= 0.12f;
                
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
        public override void ModifyHitNPC(Projectile projectile , NPC target , ref int damage  , ref float knockback , ref bool crit , ref int hitDirection){
            switch (projectile.type)
            {
                 case 5:
                    
                    
                   
                    break;
                
            }
        }
       
    }
}