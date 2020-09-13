using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;
using NovaEdge.NPCs;


namespace NovaEdge.Buffs{
    public class Manipulate : ModBuff{
        public override void SetDefaults(){
            Description.SetDefault("COMMAND");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(NPC npc , ref int buffIndex){
            npc.GetGlobalNPC<NovaEdgeGlobalNPC>().Manipulated = true;

        }
    }
}