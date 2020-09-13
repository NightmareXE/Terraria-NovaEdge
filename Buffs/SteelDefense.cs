using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Buffs{
    public class SteelDefense : ModBuff{
        public override void SetDefaults(){
            DisplayName.SetDefault("Steel Defense");
            Description.SetDefault("Gives 50% damage reduction");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player , ref int buffIndex)
        {
            player.endurance += 0.50f;
        }
    }
}