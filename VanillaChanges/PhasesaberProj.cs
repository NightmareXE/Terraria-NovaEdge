using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;


namespace NovaEdge.Items.VanillaChanges
{
    public class PhasesaberProj : ModProjectile
    {

        public override string Texture => "Terraria/Item_3";
        public override void SetDefaults()
        {
            projectile.width = projectile.height = 32;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.melee = true;
            projectile.ownerHitCheck = true;
            projectile.usesLocalNPCImmunity = true;
            projectile.localNPCHitCooldown = 30;
            projectile.friendly = true;
            projectile.penetrate = -1;

        }

        public override bool? CanHitNPC(NPC target)
        {
            return !target.friendly;
        }
        Vector2 spawnPos;
        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            

            if (player.immuneTime < projectile.localNPCHitCooldown)
            {
                player.immune = true;
                player.immuneTime = projectile.localNPCHitCooldown;
            }
        }
        public override bool PreAI()
        {
            //projectile.rotation = MathHelper.ToRadians(90);
            Player player = Main.player[projectile.owner];
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            projectile.localAI[1] = 1;
            bool isChanneling = player.channel && !player.noItems && !player.CCed;

            if (isChanneling)
            {
                if (Main.myPlayer == projectile.owner)
                {
                    float scaleFactor = 1f;
                    if (player.inventory[player.selectedItem].shoot == projectile.type)
                    {
                        projectile.scale = player.inventory[player.selectedItem].scale;
                        projectile.localAI[1] = (30f / (float)player.inventory[player.selectedItem].useTime) / player.meleeSpeed;
                        scaleFactor = player.inventory[player.selectedItem].shootSpeed * projectile.scale;

                    }

                    Vector2 mouseVector = Main.MouseWorld - vector; //Vector between cursor pos and player
                    mouseVector.Normalize();
                    if (mouseVector.HasNaNs())
                    {
                        mouseVector = Vector2.UnitX * (float)player.direction;
                    }
                    mouseVector *= scaleFactor;

                    if (mouseVector.X != projectile.velocity.X || mouseVector.Y != projectile.velocity.Y)
                    {
                        projectile.netUpdate = true;
                    }
                    projectile.velocity = mouseVector;

                }
            }
            else
            {
                projectile.Kill();
            }
            if (projectile.ai[1] == 0)
            {
                projectile.ai[0] = 0;
            }
            if (player.velocity.Y == 0)
            {
                projectile.ai[0] = 1;
            }
            float speed = 12f;
            float accel = (speed * projectile.localAI[1]) / 30f;
            projectile.localNPCHitCooldown = (int)(20f / projectile.localAI[1]);
            projectile.ai[1] = projectile.ai[1] < 30 ? projectile.ai[1] + projectile.localAI[1] : 0;
            bool halt = ((player.controlLeft && player.velocity.X > 0 && projectile.velocity.X > 0) || (player.velocity.X < 0 && projectile.velocity.X < 0 && player.controlRight));
            bool zip = ((player.velocity.X > 0 && projectile.velocity.X > 0 && player.controlRight) || (player.velocity.X < 0 && projectile.velocity.X < 0 && player.controlLeft));
            if (projectile.ai[1] < 10)
            {
                if (!zip)
                {
                    player.velocity.X *= 0.9f;
                }
            }
            else if (projectile.ai[1] < 20)
            {
                if (!zip)
                {
                    player.velocity.X *= 0.9f;
                }

            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    Dust d = Dust.NewDustDirect(player.position, player.width, player.height, 229,
                        player.velocity.X * -0.2f, player.velocity.Y * -0.2f);
                    d.noGravity = true;
                }
                for (int i = 0; i < 5; i++)
                {
                    Dust d = Dust.NewDustPerfect(player.Center, 229);
                    d.position += player.velocity * 3f;
                    d.velocity = 0.2f * player.velocity.RotatedBy(1f + 0.1f * i);
                    d.position += d.velocity * 2f;
                    d.noGravity = true;

                    d = Dust.NewDustPerfect(player.Center, 229);
                    d.position += player.velocity * 3f;
                    d.velocity = 0.2f * player.velocity.RotatedBy(-(1f + 0.1f * i));
                    d.position += d.velocity * 2f;
                    d.noGravity = true;
                }
                player.velocity.Y = ((projectile.ai[0] > 0 && player.velocity.Y > -speed) || projectile.velocity.Y > 0) ? player.velocity.Y + projectile.velocity.Y * accel : player.velocity.Y;
                player.velocity.X = Math.Abs(player.velocity.X) < speed ? player.velocity.X + projectile.velocity.X * accel : player.velocity.X;



            }
            if (halt)
            {
                player.velocity.X *= 0.9f;
            }
            projectile.position = (projectile.velocity + vector) - projectile.Size / 2f;
            projectile.rotation = projectile.velocity.ToRotation() + (projectile.direction == -1 ? 3.14f : 0);
            projectile.spriteDirection = projectile.direction;
            player.ChangeDir(projectile.direction);
            player.heldProj = projectile.whoAmI;
            player.itemTime = 10;
            player.itemAnimation = 10;
            player.itemRotation = (float)Math.Atan2(projectile.velocity.Y * (float)projectile.direction, (double)(projectile.velocity.X * (float)projectile.direction));

            return false;


        }


    }
}
