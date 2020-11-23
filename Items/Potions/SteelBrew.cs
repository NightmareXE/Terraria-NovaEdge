using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;


namespace NovaEdge.Items.Potions{
    public class SteelBrew : ModItem{

        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Steel Brew");
            Tooltip.SetDefault("Gives 50% DR , just for testing rn");
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
            item.buffType = BuffType<Buffs.SteelDefense>();
            item.buffTime = 600;


        }

    }
}