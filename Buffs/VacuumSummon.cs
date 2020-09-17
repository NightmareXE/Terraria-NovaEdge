using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Buffs
{
	public class VacuumSummon : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Vacuum Walker");
			Description.SetDefault("The Vacuum Walker will fight for you");
			Main.buffNoSave[Type] = true;
			Main.buffNoTimeDisplay[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			NovaEdgePlayer modPlayer = player.GetModPlayer<NovaEdgePlayer>();
			if (player.ownedProjectileCounts[ProjectileType<Items.SpaceSpooder.VacuumWalkerSummon>()] > 0) {
				modPlayer.walkerMinion = true;
			}
			if (!modPlayer.walkerMinion) {
				player.DelBuff(buffIndex);
				buffIndex--;
			}
			else {
				player.buffTime[buffIndex] = 18000;
			}
		}
	}
}