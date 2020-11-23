using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using NovaEdge.Buffs;
using Terraria.ID;

namespace NovaEdge.Items{
    public class POG : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("Prismatic Ornamental Garlic");
            Tooltip.SetDefault("PogChamp lol \n Gives buffs to some stats");
        }
        public override void SetDefaults(){
            item.width = item.height = 30;
            item.rare = ItemRarityID.Yellow;
            item.useTime = 30;
            item.useAnimation = 30;
            item.useStyle = ItemUseStyleID.EatingUsing;
            item.consumable = true;
            item.maxStack = 30;
            item.UseSound = SoundID.Item11;
            item.useTurn = true;
            item.buffType = BuffType<Poggers>();
            item.buffTime = 3600*60;
        }
        

    }
}