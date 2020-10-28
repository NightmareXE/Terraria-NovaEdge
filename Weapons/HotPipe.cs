using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using NovaEdge.Projectiles.Warhorn;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons{
    public class HotPipe : ModItem{
        public override string Texture => "Terraria/Item_" + ItemID.TopazStaff;
        public override void SetStaticDefaults(){
           
            Tooltip.SetDefault("Who in the hell set this beautiful thing on fire?");

        }
        public override void SetDefaults(){
            item.summon = true;
            item.useTime = 5;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 15;
            item.width = 32;
            item.height = 32;
            item.noMelee = true;
            item.value = 14000;
            item.reuseDelay = 10;
            item.rare = ItemRarityID.Green;
            item.shoot = ProjectileType<HellRing>();
            item.shootSpeed = 11f;
            item.knockBack = 2.4f;
            item.damage = 14;
        }
    }
}