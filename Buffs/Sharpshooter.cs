using Terraria;
using Terraria.ModLoader;
using NovaEdge.NPCs;

namespace NovaEdge.Buffs
{
    public class Sharpshooter : ModBuff
    {
        
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Sharpshooter Potion");
            Description.SetDefault("Increase falloff range \nIncreases bullet velocity");
            Main.debuff[Type] = false;
            
        }
        public override void Update(NPC npc , ref int buffIndex){
            npc.GetGlobalNPC<NovaEdgeGlobalNPC>().sharpshooter = true;
            
            
        }
    }
}