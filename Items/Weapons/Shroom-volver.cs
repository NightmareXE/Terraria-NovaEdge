using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
//using NovaEdge.Items.Ammo;
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
        int shootNum = 0;
        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            shootNum++;
            Vector2 speed = new Vector2(speedX, speedY);
            position = player.Center + new Vector2(16, 0).RotatedBy(speed.ToRotation());
            int proj = Projectile.NewProjectile(position, speed, type, damage, knockBack, player.whoAmI);
            Projectile projectile = Main.projectile[proj];
            if(shootNum % 6 == 0)
            {
                projectile.GetGlobalProjectile<NovaEdgeGlobalProjectile>().shroomDart = true;
                for(int i = 0; i < 5; i++)
                {
                    ShroomDartFireDust(position, new Vector2(speedX, speedY));
                }

            }


            return false;
        }   //ADD SHROOMS
        
        private void ShroomDartFireDust(Vector2 pos , Vector2 velocity)
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            dust = Main.dust[Terraria.Dust.NewDust(pos, 0, 0, 226, velocity.X , velocity.Y, 0, new Color(255, 255, 255), 1f)];
            dust.shader = Terraria.Graphics.Shaders.GameShaders.Armor.GetSecondaryShader(62, Main.LocalPlayer);
            dust.noGravity = true;

        }
    }
}