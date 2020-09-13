using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace NovaEdge.Buffs{
    public class OpenWounds : ModBuff{
        public override void SetDefaults(){
            Description.SetDefault("Deals DoT and gives life steal from affected target");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            
        }
        public override void Update(NPC npc, ref int BuffIndex){
            npc.lifeRegen = -8; //Life Steal has to be added manually with OnHitNPC
        }
    }
}