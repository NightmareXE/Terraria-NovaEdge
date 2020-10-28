using NovaEdge.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons{
    public class Blossom : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Blossom");
            Tooltip.SetDefault("It hosts the fury of the jungle...");

            ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 32;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
        }
        public override void SetDefaults(){
            item.width = 58;
            item.height = 53;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.rare= ItemRarityID.Yellow;
            
            item.value = 51232255;
            item.channel = true;
            item.useTime = 25;
            item.useAnimation = 25;
            item.shootSpeed = 15;
            item.knockBack = 3f;
            item.damage = 100;
            item.melee = true;
            item.noUseGraphic = true;
            item.UseSound = SoundID.Item1;
            item.shoot = ProjectileType<BlossomProjectile>();
            
            //567 is spore
            
        }

    }
}