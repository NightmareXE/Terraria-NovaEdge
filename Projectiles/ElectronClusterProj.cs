using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.Graphics;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;

namespace NovaEdge.Projectiles
{
    // Shader 59 is spicy red , Shader 25 looks kinda nice , 85 maybe , Shader 70 is awesome cursed flames

    public class ElectronClusterProj : ModProjectile
    {
        private const string ChainTexture = "NovaEdge/Projectiles/ElectronClusterChain";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Electron Cluster");
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 25;

        }
        public override void SetDefaults()
        {
            projectile.width = 40;
            projectile.height = 40;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.melee = true;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.1f, 0.1f, 0.15f);
            if (Main.rand.NextBool(2))
            {
                

            }
            var player = Main.player[projectile.owner];
            //Checks if player is dead
            if (player.dead)
            {
                projectile.Kill();
                return;

            }
            player.itemAnimation = 10;
            player.itemTime = 10;

            //position based Turning
            int direction = projectile.Center.X > player.Center.X ? 1 : -1;
            player.ChangeDir(direction);
            projectile.direction = direction;

            var VectorToPlayer = player.MountedCenter - projectile.Center;
            float currentChainLength = VectorToPlayer.Length();

            //ai[0] == 0 means that it just got thrown , hasnt reached max length and hasnt hit a tile
            //ai[0] == 1 means it hit a tile or reached max length
            //ai[1] == 1 means its forced to retract

            if(projectile.ai[0] == 0)
            {
                float chainLengthMax = 320f;
                projectile.tileCollide = true;

                if (currentChainLength > chainLengthMax)
                {
                    projectile.ai[0] = 1f;
                    projectile.netUpdate = true;
                }
                else if (!player.channel)
                {

                    
                    projectile.velocity.X *= 0.95f;

                }
            }
            else if(projectile.ai[0] == 1f)
            {
                float elasticFactor1 = 14f / player.meleeSpeed;
                float elasticFactor2 = 0.9f / player.meleeSpeed;
                float maxStretchLength = 300f;  //Pixels it can move before needing to retract
                if (projectile.ai[1] == 1f)
                {
                    projectile.tileCollide = false;
                }
                //Deals with situations where it should be forced to retract
                if(!player.channel || currentChainLength > maxStretchLength || !projectile.tileCollide)
                {
                    projectile.ai[1] = 1f;

                    if (projectile.tileCollide)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.tileCollide = false;

                    if (currentChainLength < 20f)
                        projectile.Kill();

                }
                if (!projectile.tileCollide)
                {
                    elasticFactor2 *= 2f;

                }
                int restingChainLength = 60;

                //If there is tension or the projectile is forced to retract , give it some velocity towards the player
                if(currentChainLength > restingChainLength || !projectile.tileCollide)
                {
                    
                    var elasticAcceleration = VectorToPlayer * elasticFactor1 / currentChainLength - projectile.velocity;
                    elasticAcceleration *= elasticFactor2 / elasticAcceleration.Length();
                    projectile.velocity *= 0.98f;
                    projectile.velocity += elasticAcceleration;
                    
                }
                
                /*else
                {
                    //Let  friction/gravity let it rest
                    if(Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y) < 6f)
                    {

                    }
                }*/

            }
            projectile.rotation = VectorToPlayer.ToRotation() - projectile.velocity.X * 0.1f;
            ElectricDust(projectile.Center);




        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            Vector2 spawnPos = new Vector2(target.Center.X, target.Center.Y - 160f);
            Vector2 vel = target.Center - spawnPos;
            vel.Normalize();
            Projectile.NewProjectile(spawnPos, vel * 7, ProjectileID.VortexVortexLightning , damage, 4f ,player.whoAmI);
            
            for(int i = 0; i < 6; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 40, 40, 226, Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f), 0, new Color(255, 255, 255), 1f)];
                dust.shader = GameShaders.Armor.GetSecondaryShader(25, Main.LocalPlayer);

            }

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.ai[0] = 1f; //important for ai
            //Collision.HitTiles(projectile.position, projectile.velocity, projectile.width, projectile.height);
            //ElectricDust(0, -6.3f);
            Main.PlaySound(SoundID.Dig, (int)projectile.position.X, (int)projectile.position.Y);
            for (int i = 0; i < 4; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 40, 40, 226, oldVelocity.X * 0.2f , oldVelocity.Y * 0.2f, 0, new Color(255, 255, 255), 1f)];
                dust.shader = GameShaders.Armor.GetSecondaryShader(25, Main.LocalPlayer);

            }
            return false;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var player = Main.player[projectile.owner];

            Vector2 mountedCenter = player.MountedCenter;
            Texture2D chainTexture = ModContent.GetTexture(ChainTexture);

            var drawPos = projectile.Center;
            var remainingVector2ToPlayer = mountedCenter - drawPos;

            float rotation = remainingVector2ToPlayer.ToRotation() - MathHelper.PiOver2;

            if (projectile.alpha == 0)
            {
                int direction = -1;

                if (projectile.Center.X < mountedCenter.X)
                {
                    direction = 1;
                }
                player.itemRotation = (float)Math.Atan2(remainingVector2ToPlayer.Y * direction, remainingVector2ToPlayer.X * direction);

                
                while (true)
                {
                    float length = remainingVector2ToPlayer.Length();

                    //if length is small enough , we break the loop
                    if (length < 25f || float.IsNaN(length))
                    {
                        break;
                    }

                    drawPos += remainingVector2ToPlayer * 12 / length;
                    remainingVector2ToPlayer = mountedCenter - drawPos;


                    Color color = Lighting.GetColor((int)drawPos.X / 16, (int)(drawPos.Y / 16f));
                    spriteBatch.Draw(chainTexture, drawPos - Main.screenPosition, null, color, rotation, chainTexture.Size() * 0.5f, 1f, SpriteEffects.None, 0f);

                }




            }
            return true;
        }

        
        private void ElectricDust(Vector2 spawnPos)
        {
            if(Main.rand.NextFloat() < 0.7f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Main.dust[Terraria.Dust.NewDust(spawnPos, 40, 40, 226, projectile.velocity.X * -0.3f, projectile.velocity.Y * -0.3f, 0, new Color(255, 255, 255), 1f)];
                dust.shader = GameShaders.Armor.GetSecondaryShader(25, Main.LocalPlayer);
            }
          


        }
    }
    
    
}
