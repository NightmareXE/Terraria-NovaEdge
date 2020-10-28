using System;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;


 namespace NovaEdge.Items.VanillaChanges
 {
   public class RecipeHelper
   {
     public static void RecipeEditing(Mod mod)
     {
       RecipeFinder finder = new RecipeFinder();
       finder.AddIngredient(ItemID.MechanicalGlove , 1);
       finder.AddIngredient(ItemID.MagmaStone , 1);
       finder.SetResult(ItemID.FireGauntlet  , 1);
       //.AddTile(TileID.Workshop);
      
       foreach(Recipe recipe in finder.SearchRecipes())

       {
         RecipeEditor editor = new RecipeEditor(recipe);
         editor.AddIngredient(2766 , 15);
         
        } 
     
        RecipeFinder finder2 = new RecipeFinder();
        finder2.AddIngredient(2431 , 14);
        finder2.AddTile(TileID.Anvils);
        finder2.SetResult(ItemID.HornetStaff);
        Recipe exactRecipe2 = finder2.FindExactRecipe();
    
        bool isFound2 = exactRecipe2 != null;
        if(isFound2){
          RecipeEditor editor2 = new RecipeEditor(exactRecipe2);
          editor2.DeleteIngredient(2431);
          editor2.AddIngredient(1134 , 1);
          editor2.AddIngredient(1124 , 20);
          editor2.AddIngredient(209 , 15);
          editor2.SetResult(ItemID.HornetStaff);
          
      }
    
  
    }
   }
 }
