using Terraria;

using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;

namespace NovaEdge.Items
{
    public class ExperimentalModeItem : ModItem
    {
        public override string Texture => "Terraria/Item_5";

        public override void SetDefaults()
        {
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.noMelee = true;
        }
        public override bool UseItem(Player player)
        {
            NovaEdgeWorld.experimentalMode = true;
            if (!NovaEdgeWorld.experimentalMode)
            {
                SendMessage("Experimental Mode has been enabled");
                NovaEdgeWorld.experimentalMode = true;
                Dust.NewDustDirect(player.Center, player.width, player.height, DustID.Fire);

                if (Main.netMode == NetmodeID.Server)
                {
                    NetMessage.SendData(MessageID.WorldData); // Immediately inform clients of new world state.
                }
            }
    
            return true;
        }
        private void SendMessage(string message)
        {
            
            Main.NewText(message, 150, 250, 150);
          
        }
    }
}
