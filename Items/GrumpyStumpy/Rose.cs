using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace NovaEdge.Items.GrumpyStumpy
{
    public class Rose : ModItem
    {
        public override string Texture => "Terraria/Item_4";
        public override void SetDefaults()
        {
            item.summon = true;
            item.mana = 20;
            item.damage = 18;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(0, 4, 0, 0);
            item.knockBack = 2f;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = item.useTime = 30;
            item.shootSpeed = 24f;
            item.width = item.height = 44;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<RoseSummon>();
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.autoReuse = true;
            item.buffType = ModContent.BuffType<Buffs.VacuumSummon>();
            item.buffTime = 3600;

        }
        
    }
    public class RoseSummon : ModProjectile
    {
        public override string Texture => "Terraria/Item_4";
        
        public override void SetDefaults()
        {
            //projectile.summon = true;
            projectile.minion = true;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.friendly = true;
            projectile.minionSlots = 1;
        }
        int slotsTaken = 0;
        public override void AI()
        {
            Player player = Main.player[projectile.owner];
            projectile.minionSlots = player.maxMinions - player.numMinions;
            slotsTaken = (int)projectile.minionSlots;
            

            projectile.position = new Vector2(player.Center.X, player.Center.Y - 64f);

            Shoot(player, 6, 0, 4f, slotsTaken, slotsTaken > 3 ? true : false);


        }
        bool target = false;
        Vector2 vel = Vector2.Zero;
        Vector2 targetPos = Vector2.Zero;
        Vector2 playerPos = Vector2.Zero;

        private void Shoot(Player player, float velMult, int type, float KB, int slotsTaken ,  bool posPredict = false)
        {
            float targetDist = 640 + slotsTaken * 16;
            if (player.HasMinionAttackTargetNPC)
            {
                NPC npc = Main.npc[player.MinionAttackTargetNPC];
                if (Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                {
                    targetDist = Vector2.Distance(projectile.Center, targetPos);
                    target = true;
                    targetPos = npc.Center;
                }

            }
            else
            {
                for (int i = 0; i < 200; i++)
                {
                    NPC npc = Main.npc[i];
                    if (npc.CanBeChasedBy(this, false))
                    {
                        float distance = Vector2.Distance(npc.Center, projectile.Center);
                        if ((distance < targetDist || !target) && Collision.CanHitLine(projectile.position, projectile.width, projectile.height, npc.position, npc.width, npc.height))
                        {
                            targetDist = distance;
                            target = true;
                            targetPos = posPredict ? new Vector2(npc.Center.X + 16 * npc.velocity.X, npc.velocity.Y * 16 + npc.Center.X) : npc.Center;

                        }
                    }
                }
            }


            int dmg = slotsTaken < 3 ? projectile.damage * slotsTaken : (int)(projectile.damage * 0.75f) * slotsTaken;
            if (target)
            {
                
                vel = targetPos - projectile.Center;
                vel.Normalize();

                Projectile.NewProjectile(projectile.Center, vel * velMult *(float) Math.Pow(1.25f , slotsTaken), ProjectileID.LaserMachinegunLaser, dmg, 0f, Main.myPlayer);
            }
        }
    }
}
