/*using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace NovaEdge.Buffs{
    public class TestMinion : ModBuff{
        public override void SetDefaults(){
            DisplayName.SetDefault("TEST");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player , ref int bufIndex){
            NovaEdgePlayer ModPlayer = player.GetModPlayer<NovaEdgePlayer>();
            if(player.ownedProjectileCounts[ProjectileType<TestMinion>()]){
                ModPlayer.testMinion = true;
            }
            if(!player.ModPlayer){
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else{
                player.buffTime[buffIndex] = 300000;
            }
        }
    }
}*/