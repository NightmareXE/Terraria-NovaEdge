using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace NovaEdge.Projectiles{
    public class EctoFlame : ModProjectile{

        public override void SetDefaults() {
            projectile.width = projectile.height = 8;
            projectile.ranged = true;
            projectile.tileCollide = true;
            projectile.timeLeft = 33;
            
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 6;

            
        }
        public override void AI(){

            for(int i = 0; i < 2; i++)
            {
                EctoDustPerfect(1.3f);
            }
            if (Main.rand.NextBool(4))
            {
                EctoDustPerfect(2f);
            }
            
        }
        public override void OnHitNPC(NPC target , int damage , float knockBack , bool crit){
            if(Main.rand.NextBool(2)){
                target.AddBuff(BuffID.Frostburn , 300);
                if(Main.rand.NextBool(2)){
                    target.AddBuff(153 , 300); //SHADOW FLAME
                }
            }
        }
        private void EctoDustPerfect(float scale)
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            
            dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 8, 8, 226, projectile.velocity.X * 0.4f , projectile.velocity.Y * 0.4f, 0, new Color(255, 255, 255), scale)];
            dust.shader = Main.rand.NextBool(7) ? Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(82, Main.LocalPlayer) : null;
            dust.noGravity = true;

        }
        private void EctoDust(float scale)
        {

            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
           
            dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 8, 8, 92, projectile.velocity.X * 0.4f, projectile.velocity.Y * 0.4f,0 ,  new Color(255, 255, 255), scale)];
            dust.noGravity = true;

        }


    }
}