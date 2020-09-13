using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Buffs{
    public class LihzardianSecret : ModBuff{
        public override void SetDefaults(){
            DisplayName.SetDefault("Lihzardian Secret");
            Description.SetDefault("A forgotten power , first cultivated by the Lihzardian People for their idol \nGives 50% Damage Reduction");
            Main.debuff[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player , ref int buffIndex)
        {
            player.endurance += 0.50f;
        }
    }
}