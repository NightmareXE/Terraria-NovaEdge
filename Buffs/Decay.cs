using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using NovaEdge.NPCs;

namespace NovaEdge.Buffs{
    public class Decay : ModBuff{
        public override void SetDefaults(){
            DisplayName.SetDefault("Decayed");
            Description.SetDefault("T");
        }
        public override void Update(NPC npc , ref int buffIndex){
            npc.GetGlobalNPC<NovaEdgeGlobalNPC>().decay = true;
        }
    }
}