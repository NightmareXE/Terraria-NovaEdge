using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using NovaEdge.Items.Ammo;
using Microsoft.Xna.Framework;
using NovaEdge.Projectiles;

namespace NovaEdge.Items.Weapons{
    public class DartlingGun : ModItem{
        public bool Hit;
        public override void SetDefaults(){
            item.scale = 0.4f;
            item.damage = 13;
            item.useTime = 10;
            item.useAnimation = 10;
            item.width = 185;
            item.height = 90;
            item.noMelee = true;
            item.ranged = true;
            item.useStyle = 5;
            item.rare = 4;
            item.value = 1400000;
            item.UseSound =  SoundID.Item11;
            item.autoReuse = true;
            item.knockBack = 2f;
            item.shoot = 10;
            item.useAmmo = 283;
            item.shootSpeed = 13f;
            
        }
       

        
          public override Vector2? HoldoutOffset(){
           return new Vector2(-35 , 0);
       }
       public override bool Shoot(Player player , ref Vector2 position , ref float speedX , ref float speedY , ref int type , ref int damage , ref float knockBack){
           if(type == ProjectileID.PoisonDart){
               type = ProjectileType<SporeDartProjectile>();
           }
           return true;
       }
    }
}