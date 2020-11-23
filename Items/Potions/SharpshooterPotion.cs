using Terraria;
using Terraria.ModLoader;
using NovaEdge.Buffs;
using Terraria.ID;

namespace NovaEdge.Items.Potions{
    public class SharpshooterPotion : ModItem
    {
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("Increases falloff distance by 10tiles \nIncreases bullet velocity by 15% \n3 minute duration");
        }
        public override void SetDefaults(){
            item.width = 18;
            item.height = 26;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.useAnimation = 15;
            item.useTime = 15;
            item.useTurn = true;
            item.UseSound = SoundID.Item3;
            item.maxStack = 30;
            item.rare = ItemRarityID.LightRed;
            item.consumable = true;
            item.buffType = ModContent.BuffType<Sharpshooter>();
            item.buffTime = 3600*3;

        }
    }
}