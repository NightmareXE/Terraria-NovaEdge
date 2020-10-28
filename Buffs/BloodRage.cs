using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using Microsoft.Xna.Framework;

namespace NovaEdge.Buffs
{
    public class Berserk : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Berserk");
            Description.SetDefault("Increases melee speed by 100% for 1secs , then 30% afterwards");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            
        }
        
        public override void Update(Player player, ref int buffIndex)
        {
          
                int index = player.FindBuffIndex(BuffType<Berserk>());
                if (index > -1)
                {
                    int time = player.buffTime[index];
                    if (time < 120)
                    {
                        player.meleeSpeed += 0.3f;
                    }
                    else
                    {
                        player.meleeSpeed += 1;
                    }
                

                }
        }
    }

    
}