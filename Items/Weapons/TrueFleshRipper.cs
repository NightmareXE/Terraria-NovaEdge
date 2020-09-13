using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using NovaEdge.Buffs;

namespace NovaEdge.Items.Weapons {
    public class TrueFleshRipper : ModItem{
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("A mutated chunk of the crimson \nInflicts Open Wounds.");

        }
        public override void SetDefaults(){
            item.melee = true;
            item.width = 33;
            item.height = 38;
            item.rare = 5;
            item.value = 1200000;
            item.autoReuse = true;
            item.damage = 115;
            item.UseSound = SoundID.Item1;
            item.useTime = 22;
            item.useAnimation = 22;
            item.crit = 4;
            item.knockBack = 5.8f;
            item.useStyle = 1;
            //item.shoot = ProjectileType<Projectiles.FleshRipperProj>();
            
            item.scale = 2f;
        }
        public override void OnHitNPC(Player player , NPC target , int damage , float knockback , bool crit){
            if(Main.rand.NextBool(3)){
                target.AddBuff(BuffType<OpenWounds>() , 240);
            }


            
            
        }
        public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(2)) {
				
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
			}
		}

        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemType<FleshRipper>());
            recipe.AddIngredient(1570 , 1);
            recipe.AddTile(134);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
        public override bool AltFunctionUse(Player player){
            return true;
        }
        public override bool CanUseItem(Player player){
            if(player.altFunctionUse == 2){
                item.shoot = ProjectileType<Projectiles.FleshRipperProj>();
                item.useTime = 27;
                item.useAnimation = 27;
                item.damage = 90;
                item.shootSpeed = 13f;
            }
            else if(player.altFunctionUse != 2){
                item.useTime = 22;
                item.useAnimation = 22;
                item.damage = 115;
                item.shoot = 0;
            }
            return base.CanUseItem(player);
        }
    }
}