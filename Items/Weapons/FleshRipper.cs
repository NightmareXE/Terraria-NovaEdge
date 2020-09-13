using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using NovaEdge.Buffs;

namespace NovaEdge.Items.Weapons {
    public class FleshRipper : ModItem{
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("A mutated chunk of the crimson \nInflicts Open Wounds.");

        }
        public override void SetDefaults(){
            item.melee = true;
            item.width = 60;
            item.height = 60;
            item.rare = 3;
            item.UseSound = SoundID.Item1;
            item.value = 120000;
            item.autoReuse = true;
            item.damage = 79;
            item.useTime = 27;
            item.useAnimation = 27;
            item.crit = 6;
            item.knockBack = 4.2f;
            item.useStyle = 1;
            
            
        }
         public override void MeleeEffects(Player player, Rectangle hitbox) {
			if (Main.rand.NextBool(2)) {
				
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, 60);
			}
         }
        public override void OnHitNPC(Player player , NPC target , int damage , float knockback , bool crit){
            if(Main.rand.NextBool(6)){
                target.AddBuff(BuffType<OpenWounds>() , 240);
            }

            
            
        }
        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BloodButcherer , 1);
            recipe.AddIngredient(ItemID.Muramasa , 1);
            recipe.AddIngredient(ItemID.FieryGreatsword , 1);
            recipe.AddIngredient(190 , 1);
            recipe.AddTile(26);
            recipe.SetResult(this);
            recipe.AddRecipe();

        }
         public override Vector2? HoldoutOffset(){
           return new Vector2(-8 , 0);
        }
    }
}