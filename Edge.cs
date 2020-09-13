using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;

namespace NovaEdge
{
	public class Edge : Mod
	{
		 public override void AddRecipeGroups(){
                RecipeGroup group = new RecipeGroup(() => Language.GetTextValue("LegacyMisc.37") + " Iron Ore" , new int[]{
                  
                    ItemID.IronOre,
                    ItemID.LeadOre
                }
                );
                RecipeGroup.RegisterGroup("NovaEdge:FerrumOre" , group);
            }
	 
	}

    
}
