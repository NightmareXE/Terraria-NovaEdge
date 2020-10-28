using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Threading.Tasks;

namespace NovaEdge.Items.Weapons
{
    public class ElectronCluster : ModItem
    {
        public override void SetDefaults()
        {
            item.width = item.height = 22;
            item.value = Item.sellPrice(gold: 14);
            item.rare = ItemRarityID.Lime;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = 24;
            item.useTime = 24;
            item.noUseGraphic = true;
            item.shoot = ModContent.ProjectileType<Projectiles.ElectronClusterProj>();
            item.shootSpeed = 21f;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.channel = true;
            item.damage = 145;
            item.knockBack = 8f;
        }
    }
}
