using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using NovaEdge.Buffs;
using Terraria.ID;


namespace NovaEdge.Items.Weapons {
    public class Stick : ModItem{
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("A SHHTICK! \n Has right click functionality");
        }
        public override void SetDefaults(){
            item.damage = 12;
            item.useTime = 15;
            item.useAnimation = 15;
            item.value = 4000;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.melee = true;
            item.useStyle = 1;
            item.autoReuse = true;
            item.useTurn = true;
            item.knockBack = 4.7f;
        }
        public override bool AltFunctionUse(Player player){
            return true;
        }
        public override bool CanUseItem(Player player){
            if(player.altFunctionUse != 2){
                item.useStyle = 1;
                item.useTime = 10;
                item.useAnimation = 10;
                item.damage = 12;
               
            }
            else if(player.altFunctionUse == 2){
                item.useTime = 2;
                item.useAnimation = 2;
                item.damage = 210000000;
                
                item.useStyle = 3;

            }
            return base.CanUseItem(player);
        }
        public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood , 20);
			
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

    }
}