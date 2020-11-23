using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using ReLogic.Utilities;
using Terraria.Utilities;
using System;

using System.Linq;
using System.Collections.Generic;




namespace NovaEdge.Items
{
    public class DysotopiaProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 7;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
            
        }
        public override string Texture => "Terraria/Item_" + ItemID.TitaniumTrident;
        public override void SetDefaults()
        {
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.ignoreWater = true;
            projectile.timeLeft = 500;
            projectile.tileCollide = false;
            projectile.width = projectile.height = 32;

        }
        public float GetLerpValue(float from, float to, float t, bool clamped = false)
        {
            if (clamped)
            {
                if (from >= to)
                {
                    if (t < to)
                    {
                        return 1f;
                    }
                    if (t > from)
                    {
                        return 0f;
                    }
                }
                else
                {
                    if (t < from)
                    {
                        return 0f;
                    }
                    if (t > to)
                    {
                        return 1f;
                    }
                }
            }
            return (t - from) / (to - from);
        }

        private const string LightningTexture = "NovaEdge/Projectiles/ElectronClusterChain";

        public override void AI()
        {
            
        }
        /*public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.1f, 0.05f, 0.1f);
            projectile.ai[0]++;
            if(projectile.ai[0] < 60)
            {
                projectile.rotation += MathHelper.ToRadians(10);
            }
            if (projectile.ai[0] > 60 && projectile.ai[0] < 120)
            {
                projectile.rotation -= MathHelper.ToRadians(10);
            }
            if(projectile.ai[0] == 121)
            {
                projectile.ai[0] = 0;
            }
            bool flag2 = false;
            float lerpValue1 = GetLerpValue(0f, 10f, projectile.localAI[0], true); //Start
            Color color1 = Color.Lerp(Color.Transparent, Color.MediumPurple, lerpValue1);
            if (Main.rand.NextBool(12))
            {
                Dust.NewDustDirect(projectile.Center, 0, 0, DustID.Electric, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, Color.MediumPurple);
            }
            if (Main.rand.Next(6) == 0)
            {
                Dust dust1 = Dust.NewDustDirect(projectile.Center, 0, 0, 27, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, color1, 3.5f);
                dust1.noGravity = true;
                dust1.velocity *= 1.4f;
                dust1.velocity += Main.rand.NextVector2Circular(1f, 1f);
                dust1.velocity = dust1.velocity + (projectile.velocity * 0.15f);
            }
            if (Main.rand.Next(12) == 0)
            {
                Dust dust2 = Dust.NewDustDirect(projectile.Center, 0, 0, 27, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, color1, 1.5f);
                dust2.velocity += Main.rand.NextVector2Circular(1f, 1f);
                dust2.velocity = dust2.velocity + (projectile.velocity * 0.15f);
            }
            if (flag2)
            {
                int num13 = Main.rand.Next(2, 5 + (int)(lerpValue1 * 4f));
                for (int j = 0; j < num13; j++)
                {
                    Dust center1 = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 27, 0f, 0f, 100, color1, 1.5f);
                    center1.velocity *= 0.3f;
                    center1.position = projectile.Center;
                    center1.noGravity = true;
                    center1.velocity += Main.rand.NextVector2Circular(0.5f, 0.5f);
                    center1.fadeIn = 2.2f;
                    Dust center2 = center1;
                    center2.position = center2.position + (((center1.position - projectile.Center) * lerpValue1) * 10f);
                }
            }
            Player player = Main.player[projectile.owner];
            Vector2 projToMouse = Main.MouseWorld - projectile.Center;
            projToMouse.Normalize();
            Vector2 projTOPlayer = player.Center - projectile.Center;
            projTOPlayer.Normalize();
            if (Main.mouseLeft)
            {
                projectile.velocity = projToMouse * 24f;
            }
            else if (!Main.mouseLeft)
            {
                projectile.velocity = projTOPlayer * 12f;
            }
            if(projectile.Center == player.Center)
            {
                projectile.Kill();
            }
            
        }*/

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            var player = Main.player[projectile.owner];

            Vector2 mountedCenter = player.MountedCenter;
            Texture2D chainTexture = ModContent.GetTexture(LightningTexture);

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
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPosition = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = /*.GetAlpha(lightColor)*/ new Color(100 , 80 , 100) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPosition, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            for(int i = 0; i < 3; i++)
            {
                Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, DustID.Electric, 0, 0, 0, Color.MediumPurple);
            }
            target.AddBuff(BuffID.Confused, 300);
            target.AddBuff(ModContent.BuffType<Buffs.Electrified>(), 300);
        }
    }
   


}
