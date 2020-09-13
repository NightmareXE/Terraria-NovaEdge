using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using NovaEdge.Projectiles;

namespace NovaEdge.Items.Ammo{
    public class Darts : ModItem{
        public override void SetDefaults(){
            item.damage = 8;
            item.shoot = 10;
            item.shootSpeed = 10f;
            item.ranged = true;
            item.rare = 3;
            item.value = 10000;
            item.maxStack = 999;
            item.ammo = item.type;
            item.consumable = true;
            item.knockBack = 2f;
            item.width = 16;
            item.height = 16;

        }
    }
}