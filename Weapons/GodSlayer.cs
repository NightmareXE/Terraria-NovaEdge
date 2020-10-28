using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Items.Weapons{
    public class GodSlayer : ModItem{

        public override void SetDefaults(){
            item.damage = 99999999;
            item.melee = true;
            item.useStyle = ItemUseStyleID.Stabbing;
            item.useTime = 24;
            item.useAnimation = 24;
            item.knockBack = 6f;
            item.value = 1;
            item.rare = ItemRarityID.Blue;
            item.crit = 10;
            item.UseSound = SoundID.Item1;
            item.width = 16;
            item.height = 16;    
        }
    }
}