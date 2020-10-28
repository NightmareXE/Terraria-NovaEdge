using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using NovaEdge.Items.Ammo;
using Microsoft.Xna.Framework;
using NovaEdge.Projectiles;
using NovaEdge.NPCs.SpaceSpooder;

namespace NovaEdge.Items.Weapons{
    public class Shroomvolver : ModItem
    {
        public int i = 0;
        public override void SetDefaults(){
            item.scale = 0.5f;
            
            item.damage = 48;
            item.useTime = 18;
            item.useAnimation = 18;
            item.width = 32;
            item.height = 32;
            item.noMelee = true;
            item.ranged = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.rare = ItemRarityID.LightRed;
            item.value = 1400000;
            item.UseSound =  SoundID.Item11;
            item.autoReuse = true;
            item.knockBack = 2f;
            item.shoot = ProjectileID.PurificationPowder;
            item.useAmmo = AmmoID.Dart;
            item.shootSpeed = 12f;
            
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DartPistol , 1);
            recipe.AddIngredient(ItemID.ShroomiteBar , 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
        
        public override bool Shoot(Player player , ref Vector2 position , ref float speedX , ref float speedY , ref int type , ref int damage , ref float knockBack)
        {
            
            i++;
            
            if(i > 6){
                type = ProjectileType<ShroomDart>();
              
                 i = 0;
            }
            return true;
        }   //ADD SHROOMS
    }
}