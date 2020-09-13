using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace NovaEdge.Items.Weapons{
    public class IceCandle : ModItem{
        public override void SetDefaults(){
            item.width = 30;
            item.height = 30;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = 2;
            item.magic = true;
            item.damage = 68;
            item.knockBack = 3f;
            item.crit = 7;
            item.useTime = 20;
            item.useAnimation = 20;
            item.channel = true;
            item.shootSpeed = 9f;
            item.shoot = ModContent.ProjectileType<Projectiles.IceCandleProj>();
        }
    }
}