using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Microsoft.Xna.Framework.Graphics;



namespace NovaEdge.Projectiles
{
    public class GhostSharkcs : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[projectile.type] = 0;
        }
        public override string Texture => "Terraria/Item_" + ItemID.SDMG;
        public override void SetDefaults()
        {
            projectile.ranged = true;
            projectile.friendly = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.timeLeft = 180;
            projectile.width = 60;
            projectile.height = 34;
            projectile.penetrate = -1;
            projectile.alpha = 100;
        }
        public override void AI()
        {
            Lighting.AddLight(projectile.Center, 0.1f, 0.1f, 0.2f);
            Player player = Main.player[projectile.owner];
            Shoot(player, CheckHeldItem(player));
            Hover(player);

            if (player.HeldItem.type != ModContent.ItemType<Items.Weapons.Gigashark>())
            {
                projectile.Kill();
            }
            projectile.alpha += projectile.alpha < 160 ? Main.rand.Next(-15, 31) : -25;
           
            

           

        }

        public override void Kill(int timeLeft)
        {
            for(int i = 0; i < 8; i++)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Main.dust[Terraria.Dust.NewDust(projectile.Center, 16, 16, 226, Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f), 0, new Color(255, 255, 255), 1f)];
                
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Vector2 drawOrigin = new Vector2(Main.projectileTexture[projectile.type].Width * 0.5f, projectile.height * 0.5f);
            for (int k = 0; k < projectile.oldPos.Length; k++)
            {
                Vector2 drawPosition = projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, projectile.gfxOffY);
                Color color = /*.GetAlpha(lightColor)*/ new Color(100 , 100 , 140) * ((float)(projectile.oldPos.Length - k) / (float)projectile.oldPos.Length);
                spriteBatch.Draw(Main.projectileTexture[projectile.type], drawPosition, null, color, projectile.rotation, drawOrigin, projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        private int CheckHeldItem(Player player)
        {
            //bool canShoot = player.HasAmmo(player.inventory[player.selectedItem], canUse: true) && !player.noItems && !player.CCed;

            if (player.HeldItem.ranged && player.HeldItem.useAmmo == AmmoID.Bullet)
            {
                return player.HeldItem.shoot;
                
            }
            else
            {
                return 0;
            }
        }
        private void Shoot(Player player, int type)
        {
            Vector2 vel = Main.MouseWorld - projectile.Center;
            vel.Normalize();
            if (++projectile.ai[0] % (player.HeldItem.useTime + 4) == 0)
            {
                Projectile.NewProjectile(projectile.Center, vel * player.HeldItem.shootSpeed, type, player.GetWeaponDamage(player.HeldItem)/10, 4f, player.whoAmI);
            }
            
           
            projectile.rotation = vel.ToRotation();
        }
        private void Hover(Player player)
        {
            projectile.position.Y = player.Center.Y - 64; 
            if (projectile.position.X + projectile.width / 2 > player.position.X + player.width / 2)
            {
                if (projectile.velocity.X > 0f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.98f;
                }
                projectile.velocity.X = projectile.velocity.X - 0.05f;
                if (projectile.velocity.X > 8f)
                {
                    projectile.velocity.X = 8f;
                }
            }
            if (projectile.position.X + projectile.width / 2 < player.position.X + player.width / 2)
            {
                if (projectile.velocity.X < 0f)
                {
                    projectile.velocity.X = projectile.velocity.X * 0.98f;
                }
                projectile.velocity.X = projectile.velocity.X + 0.05f;
                if (projectile.velocity.X < -8f)
                {
                    projectile.velocity.X = -8f;
                }
            }
        }
    }
}
