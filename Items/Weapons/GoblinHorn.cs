using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using NovaEdge.Projectiles;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons{
    public class GoblinHorn : ModItem{
        
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Goblin's Warcry");
            Tooltip.SetDefault("Perfect to bust someone's eardrums");

        }
        public override void SetDefaults(){
            item.summon = true;
            item.useTime = 5;
            item.useStyle = 5;
            item.useAnimation = 15;
            item.width = 32;
            item.height = 32;
            item.noMelee = true;
            item.value = 14000;
            item.reuseDelay = 10;
            item.rare = 2;
            item.shoot = ProjectileType<GoblinRing>();
            item.shootSpeed = 11f;
            item.knockBack = 4.2f;
            item.damage = 12;
        }
         public override Vector2? HoldoutOffset(){
           return new Vector2(-8 , 0);
       }
    }
}