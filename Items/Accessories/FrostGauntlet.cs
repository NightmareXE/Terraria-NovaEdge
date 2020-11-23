using System;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
 


 namespace NovaEdge.Items.Accessories 
 {
   public class FrostGauntlet : ModItem
   {
     public override void SetStaticDefaults()                                       
     {
       DisplayName.SetDefault("Frost Gauntlet");
       Tooltip.SetDefault("Placeholder");
       
     }
     public override void SetDefaults(){
      
       item.accessory = true;
       item.width = 32;
       item.height = 32;
       
     }
     public override void UpdateAccessory(Player player , bool hideVisual){
       player.meleeDamage += 0.12f;
       player.meleeSpeed += 0.12f; 
       //item.GetGlobalItem<VanillaChanges.Balance>().frostGauntlet = true;
             
     }
    
     public override void AddRecipes(){
       ModRecipe recipe = new ModRecipe(mod);
       recipe.AddIngredient(ItemID.FireGauntlet);
       recipe.AddIngredient(ItemID.FrostCore);
       recipe.AddIngredient(ItemID.MartianConduitPlating , 10);
       recipe.AddTile(TileID.MythrilAnvil);
       recipe.SetResult(this);
       recipe.AddRecipe();
     }
    
    
     
   }
 }
