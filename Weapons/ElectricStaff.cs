using Terraria;
using NovaEdge.Projectiles;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Weapons
{
    public class ElectricStaff : ModItem 
    {
        public override void SetStaticDefaults()
        {

            Item.staff[item.type] = true; //important
        }
        public override void SetDefaults()
        {
            item.width = 40;
            item.height = 40;
            item.summon = true;
            item.mana = 10;
            item.damage = 35;
            item.knockBack = 2.3f;
            item.useTime = 15;
            item.noMelee = true;
            item.useStyle = ItemUseStyleID.SwingThrow;  //5 is for staves
            item.autoReuse = false;
            item.UseSound = SoundID.Item20;
            item.useAnimation = 15;
            item.rare = ItemRarityID.LightRed;
            item.shoot = ProjectileType<NPCs.GrumpyStumpy.ThornProj>(); //plz replace
            item.shootSpeed = 15f;
        }
    }
}