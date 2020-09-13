using Terraria; //These using directives are used to define certain directories that we want to use files from ,
using Terraria.ID;    //Terraria; and Terraria.ModLoader; are used almost all the time
using Terraria.ModLoader;  //Terraria.ID is used if we want to use a function that can find weapon/buff/item/projectile IDs
using static Terraria.ModLoader.ModContent;  //This one to the right is used add Modded content like projectiles or buffs into our item
using NovaEdge.Buffs;
using Microsoft.Xna.Framework;
namespace NovaEdge.Items.Weapons //The name of the namespace should be the directory where this file is placed ,(Directorys after Mod sources only)
{ //public is used to make a class/method avaliable in any part of the project
    public class Gigashark : ModItem{ /*class name is seperated into 2 parts , the left is the name and the second is the type. The type is extremely important
                                           as it determines what this code will be used to make. */
        public override void SetStaticDefaults(){ /* override is basically a keyword used to overwrite a method , void is a keyword used for methods that don't return values*/
                        //SetStaticDefaults is a method name used to set static values like DisplayName and ToolTip.
            DisplayName.SetDefault("Gigashark"); 
            Tooltip.SetDefault("The even older bro of Megashark"); //sets tooltip

        }
        public override void SetDefaults(){
             //SetDefaults is used to modify almost all things of an object.(I'll refer to items/projectiles/buffs,etc as objects)
            item.scale =  0.5f;
            item.damage = 45; //Sets damage , must be an integer
            item.width = 157; //Width of the sprite hitbox
            item.height = 84; //height of the sprite hitbox
            item.useTime = 5; //How fast an item is in ticks. (1 tick = 1/60 secs)
            item.useAnimation = 5; //The speed of item's animation , also in ticks
            item.noMelee = true; //Makes the sprite of the gun not do damage
            item.value = 500000; //the price can be set by this.Value is in copper coins
            item.rare = 6; //sets she rarity of an item. The numbers are weird so i won't go in depth for now
            item.knockBack = 1.5f; //the knockback of an item , must be a float value.
            item.UseSound = SoundID.Item11; // the sound an item produces on use. Wiki is useful for finding these IDs , Ttem11 is for gun shoot sound
            item.autoReuse = true; //determines if the weapon has autoswing
            item.shootSpeed = 15f; //firing speed for a ranged weapon
            item.ranged = true; //Sets the class of the item as ranged
            item.shoot = 5; //this just exists
            item.useStyle = 5; //There's a lot of different styles , 5 is for guns , bows and staves
            item.useAmmo = AmmoID.Bullet; //used to determine the type of ammo used by an item , used to classify ranged weapons as guns , bows , rocket launchers, etc
            
        }
        public override bool ConsumeAmmo(Player player){
            if(player.altFunctionUse == 2){
                return Main.rand.NextFloat() >= .75f;
            }
            else
            {
                return Main.rand.NextFloat() >= .50f;
            }
        }
        
            
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod); //this line defines a variable called recipe which of the type ModRecipe
            recipe.AddIngredient(ItemID.ChainGun , 1); // A method used to add ingredients to a recipe , the first value is the material and the second is the amount
            recipe.AddIngredient(ItemID.Megashark , 1);
            recipe.AddIngredient(ItemID.BeetleShell , 20);
            recipe.AddTile(134); //Adds a crafting station where this recipe is avaliable
            recipe.SetResult(this); //Sets the output from this recipe to this item
            recipe.AddRecipe(); //Adds the recipe to the game lol
        }

        public override bool AltFunctionUse(Player player){
            return true;
        }
        public override bool CanUseItem(Player player)
        {
            if(player.altFunctionUse == 2){
                player.armorPenetration += 15;
            }

            return base.CanUseItem(player);
       }
       public override bool Shoot(Player player , ref Vector2 position , ref float speedX , ref float speedY , ref int type , ref int damage , ref float knockBack)
        {
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
            return true;
        }
        public override Vector2? HoldoutOffset(){
           return new Vector2(-25 , 0);
        }
       
                
            

            
        
        /* public override void OnHitNPC(Player player , NPC target , int damage , float knockback , bool crit){
             if(player.altFunctionUse == 2){
                 player.AddBuff(BuffType<MalfunctionedShark>() , 180);
            }
             else if(Main.mouseRightRelease){
                    player.AddBuff(BuffType<MalfunctionedShark>() , 180);
            }

             if(player.HasBuff(BuffType<MalfunctionedShark>()))
            {
                damage = (int)(damage * 0.6f);
                item.useTime = 8;
                item.useAnimation = 8;
            }
            else
            {
                item.useTime = 5;
                item.useAnimation = 5;
            }
            
         }*/
        
      
        
    }
}     