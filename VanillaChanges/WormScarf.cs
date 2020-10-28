using Terraria.ID;
using Terraria;

using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using System.Collections.Generic;


namespace NovaEdge.Items.VanillaChanges{
  public class WormScarf : GlobalItem
  {
    /*public override void ModifyTooltip(Item item, List<TooltipLine> tooltips){
      
    }*/
      
    
    public override void UpdateAccessory(Item item , Player player , bool hideVisual)
    {
      if(item.type == ItemID.WormScarf)
      {
        if(player.statLife <= player.statLifeMax/4)
        {
          player.moveSpeed += 0.15f;
          
        }
      }
    }
  }
}
