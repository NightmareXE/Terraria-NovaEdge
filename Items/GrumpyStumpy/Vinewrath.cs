using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NovaEdge.Items.GrumpyStumpy
{
    public class Vinewrath : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 18;
            item.useTime = item.useAnimation = 20;
            item.rare = ItemRarityID.Blue;
            item.melee = true;
            item.knockBack = 5f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundID.Item1;
            item.useTurn = true;
            item.autoReuse = true;
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust.NewDustDirect(player.Center, hitbox.X, hitbox.Y, DustID.GrassBlades);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if (Main.rand.NextBool(2))
            {
                Vector2 vel = Main.MouseWorld - player.Center;
                vel.Normalize();
                Projectile.NewProjectile(player.Center, vel * 8, ProjectileID.VilethornTip, damage, 4f, player.whoAmI);
            }
        }
    }
}
