using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace NovaEdge.Items
{
    public class Dysotopia : ModItem
    {
        public override string Texture => "Terraria/Item_" + ItemID.TheHorsemansBlade;
        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.width = 24;
            item.height = 24;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
            item.melee = true;
            item.melee = true;
            item.shoot = ModContent.ProjectileType<DysotopiaProj>();
            item.useAnimation = 30;
            item.useTime = 30;
            item.shootSpeed = 16f;
            item.damage = 190;
            item.knockBack = 6.5f;
            item.@value = Item.sellPrice(0, 20, 0, 0);
            item.crit = 10;
            item.rare = ItemRarityID.Red;
            item.noUseGraphic = true;
            item.noMelee = true;
        }
        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[item.shoot] < 2;
        }
    }
    
}
