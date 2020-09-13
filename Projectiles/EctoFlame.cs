using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NovaEdge.Projectiles{
    public class EctoFlame : ModProjectile{

        public override void SetDefaults(){
            projectile.width = projectile.height = 8;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 44;
            projectile.friendly = true;
            projectile.penetrate = -1;

            
        }
        public override void AI(){

            for(int i = 0; i < 1; i++){
            Dust dust = Dust.NewDustDirect(projectile.position , projectile.width , projectile.height , 229);
            }
            Dust dust1 = Dust.NewDustDirect(projectile.position , projectile.width , projectile.height , 229);
            dust1.scale = 1.5f;
            Dust dust2 = Dust.NewDustDirect(projectile.position , projectile.width , projectile.height , 176);
        }
        public override void OnHitNPC(NPC target , int damage , float knockBack , bool crit){
            if(Main.rand.NextBool(2)){
                target.AddBuff(BuffID.Frostburn , 300);
                if(Main.rand.NextBool(2)){
                    target.AddBuff(153 , 300); //SHADOW FLAME
                }
            }
        }
    }
}