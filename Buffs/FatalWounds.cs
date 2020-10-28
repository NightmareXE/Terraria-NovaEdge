using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using NovaEdge.NPCs.GlobalNPCStuff;

namespace NovaEdge.Buffs{

    public class FatalWounds : ModBuff{
        
		
        public override void SetDefaults(){
            DisplayName.SetDefault("Fatal Wounds");
            Description.SetDefault("Does 5dmg per second upto 25dmg per sec");
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            
        }
        public override void Update(NPC npc , ref int buffIndex){
            npc.GetGlobalNPC<NovaEdgeGlobalNPC>().fatalWounds = true;
            
            
        }
    }
}