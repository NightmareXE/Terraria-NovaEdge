using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using NovaEdge.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons{
    public class DreadedLeechers : ModItem
    {
        public override void SetDefaults(){
            item.damage =  110;
            item.useTime = 24;
            item.useAnimation = 24;
            item.rare = ItemRarityID.LightPurple;
            item.knockBack = 0f;
            item.shoot = ProjectileType<Leech>();
            item.shootSpeed = 16f;
            item.noMelee = true;
            item.melee = true;
            item.noUseGraphic = true;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.width = 16;
            item.UseSound = SoundID.Item1;
            item.height = 16;


        }
        public override bool Shoot(Player player , ref Vector2 position , ref float speedX , ref float speedY , ref int type , ref int damage , ref float knockBack){
            float count = 3+ Main.rand.Next(2);
            float spread = MathHelper.ToRadians(13);
            position += Vector2.Normalize(new Vector2(speedX, speedY)) * 45f;
            for(int i = 0;i < count; i++){
                Vector2 speedPert = new Vector2(speedX , speedY).RotatedBy(MathHelper.Lerp(-spread , spread , i/(count - 1)));
                Projectile.NewProjectile(position.X, position.Y, speedPert.X , speedPert.Y, type, damage, knockBack, player.whoAmI);
            }
            return true;

        }
    }
}