using Terraria;
using Terraria.ID;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Items.Vanity {
    [AutoloadEquip(EquipType.Body)]
    public class ElectroManiacsSweater : ModItem{
        public override void SetStaticDefaults(){
            DisplayName.SetDefault("ElectroManiac's Sweater");
            Tooltip.SetDefault("Great for drawing!");
        }
        public override void SetDefaults(){
            item.vanity = true;
            item.rare = ItemRarityID.Blue;
            item.width = 40;
            item.height = 40;
            item.value = 1200;
        }
    }
}