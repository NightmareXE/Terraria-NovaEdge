using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Items.SpaceSpooder{
    public class HoloSpider : ModItem{
        public override string Texture => "Terraria/Item_" + ItemID.SpiderStaff;

        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Holo-Spider");
            Tooltip.SetDefault("Shoots a spider that shoots lasers when near enemies");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults(){
            item.damage = 50;
            item.knockBack = 3f;
            item.shootSpeed = 7f;
            item.shoot = ModContent.ProjectileType<HoloSpiderProj>();
            item.useTime = 30;
            item.useAnimation = 30;
            item.magic = true;
            item.useStyle = 5;
            item.UseSound = SoundID.Item20;
            item.mana = 14;
            item.rare = 3;
            
        }
    }
}

