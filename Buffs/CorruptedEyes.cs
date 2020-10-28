using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace NovaEdge.Buffs
{
    public class CorruptedEyes : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Corrupted Eyes");
            Description.SetDefault("Blocks some damage on the next hit depending on damage taken");
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<NovaEdgePlayer>().capeOfEyes = true;
            
        }
    }
}
