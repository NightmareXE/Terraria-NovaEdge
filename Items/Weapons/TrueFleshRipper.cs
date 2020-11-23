using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;
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
            item.rare = ItemRarityID.Pink;
            item.value = 1200000;
            item.autoReuse = true;
            item.damage = 115;
            item.UseSound = SoundID.Item1;
            item.useTime = 22;
            item.useAnimation = 22;
            item.crit = 4;
            item.knockBack = 5.8f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.scale = 1f;
            //item.shoot = ProjectileType<Projectiles.FleshRipperProj>();
            
            //item.scale = 2f;
        }
        public override void OnHitNPC(Player player , NPC target , int damage , float knockback , bool crit){
            if(Main.rand.NextBool(3)){
                target.AddBuff(BuffType<OpenWounds>() , 240);
            }
            for (int i = 0; i < 6; i++)
            {

                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.

                dust = Main.dust[Terraria.Dust.NewDust(target.Center, 16, 16, 226, Main.rand.NextFloat(-4f, 4f), Main.rand.NextFloat(-4f, 4f), 0, new Color(255, 255, 255), 1f)];
                if (Main.rand.NextBool(5))
                {
                    dust.shader = GameShaders.Armor.GetSecondaryShader(59, Main.LocalPlayer);

                }
                else
                {
                    dust.shader = GameShaders.Armor.GetSecondaryShader(81, Main.LocalPlayer);
                }



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
            recipe.AddIngredient(ItemID.BrokenHeroSword , 1);
            recipe.AddTile(TileID.MythrilAnvil);
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
                item.shoot = ProjectileID.None;
            }
            return base.CanUseItem(player);
        }
    }
}