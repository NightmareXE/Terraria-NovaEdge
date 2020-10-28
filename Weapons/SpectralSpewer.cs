using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace NovaEdge.Items.Weapons{
    public class SpectralSpewer : ModItem{
        //public override string Texture => "Terraria/Item_311";

        public override void SetDefaults(){
            item.width = item.height = 30;
            item.ranged = true;
            item.damage = 52;
            item.useTime = 5;
            item.useAnimation = 25;
            item.scale = 0.5f;
            item.reuseDelay = 5;
            item.knockBack = 0.4f;
            item.useAmmo = 23;
            item.shoot = ModContent.ProjectileType<Projectiles.EctoFlame>();
            item.shootSpeed = 9f;
            item.rare = ItemRarityID.LightPurple;
            item.value = 1000000;
            item.noMelee = true;
            item.autoReuse = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
        }
        //public override bool Shoot(Player player , ref Vector2 position , ref float speedX , ref float speedY , ref int type , ref int damage , ref float knockBack){
            
        //}
        public override Vector2? HoldoutOffset(){
           return new Vector2(-30 , 0);
       }
    }
}