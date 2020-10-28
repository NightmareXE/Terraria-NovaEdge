using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace NovaEdge.Items.SpaceSpooder{
    public class MechEggStaff : ModItem{
        public  override string Texture => "Terraria/Item_" + ItemID.SpiderStaff;

        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Mechanical Egg Staff");
            Tooltip.SetDefault("idk for now");
        }
        public override void SetDefaults(){
            item.summon = true;
            item.mana = 20;
            item.damage = 30;
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(0, 10, 0, 0);
            item.knockBack = 2f;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAnimation = item.useTime = 30;
            item.shootSpeed = 24f;
            item.width = item.height = 44;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.shoot = ModContent.ProjectileType<VacuumWalkerSummon>();
            item.UseSound = SoundID.Item44;
            item.noMelee = true;
            item.autoReuse = true;
            item.buffType = ModContent.BuffType<Buffs.VacuumSummon>();
            item.buffTime = 3600;
        }
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) {
			player.AddBuff(item.buffType, 2);
			position = Main.MouseWorld;
			return true;
        }
        
    
    }
}