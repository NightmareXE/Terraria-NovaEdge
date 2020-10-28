using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace NovaEdge.Items.Weapons
{
    public class Peacekeeper : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Peacekeeper");
            Tooltip.SetDefault("Right-Click to fire a shot with reduced spread \nRight and Left-Click at once for even tighter spread ");

        }
        public override void SetDefaults(){
            
            item.scale = 0.5f;
            item.damage = 47;
            item.useTime = 45;
            item.useAnimation = 45;
            item.width = 121;
            item.height = 57;
            item.rare = ItemRarityID.Yellow; //will change later
            item.shoot = ProjectileID.PurificationPowder;
            item.shootSpeed = 24f;
            item.ranged = true;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.UseSound =  SoundID.Item11;
            item.useAmmo = AmmoID.Bullet;
            item.knockBack = 3.5f; //might change later
            item.value = 2706000;
            item.autoReuse = true;
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.MartianConduitPlating , 100);
            recipe.AddIngredient(ItemID.Shotgun , 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        
       
        }
        public override bool CanUseItem(Player player) {
            if(player.altFunctionUse == 2){
               item.reuseDelay = 20;
                
            }
            else if(player.altFunctionUse != 2){
                item.useTime = 45;
                item.useAnimation= 45;
                
               
                
            }
            return base.CanUseItem(player);
        }
			
            
        
        public override bool Shoot(Player player , ref Vector2 position , ref float speedX , ref float speedY , ref int type , ref int damage , ref float knockBack)
        {
           if(type == ProjectileID.Bullet){
               type = 440;
               if(player.altFunctionUse == 2){
                   type = 459;
               }
           }
           
           int j = 0;
           int Spread = 16;
           int BulletCount = 11;
           int Spread1 = 8;
            if(Main.mouseRight  && Main.mouseLeft){
                Spread = Spread1;
            }
            
            
                for (int i = 0; i < BulletCount; i++){
                    if(player.altFunctionUse == 2){
                        Spread = 2;
                        speedX *= 2f;
                        speedY *= 2f;
                    }
                    Vector2 Speed = new Vector2(speedX , speedY).RotatedByRandom(MathHelper.ToRadians(Spread));
                    Projectile.NewProjectile(position.X , position.Y , Speed.X , Speed.Y , type , damage , knockBack , player.whoAmI);
            }
            
           
            Vector2 muzzleOffset = Vector2.Normalize(new Vector2(speedX, speedY)) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
			{
				position += muzzleOffset;
			}
            
           return false;   
        }
       public override bool AltFunctionUse(Player player){
           return true;
       }
       public override Vector2? HoldoutOffset(){
           return new Vector2(-20 , 0);
       }

    }
}