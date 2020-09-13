using Terraria;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.ID;
using Microsoft.Xna.Framework;
namespace NovaEdge.Items.Weapons{
    public class SixShooter : ModItem{
        public override void SetDefaults(){
            item.damage = 57;
            item.rare = 4;
            item.width = 28;
            item.height = 26;
            item.value = 6000000;
            item.useTime = 33;
            item.useAnimation = 33;
            item.useStyle = 5;
            item.knockBack = 5.9f;
            item.crit = 8;
            item.UseSound =  SoundID.Item11;
            item.useAmmo = AmmoID.Bullet;
            item.ranged = true;
            item.shoot = 10;
            item.shootSpeed = 9f;
            item.noMelee = true;

        }
       
        public override bool CanUseItem(Player player){
            if(player.altFunctionUse != 2){
                item.useTime = 24;
                item.useAnimation = 24;
            }
            else if(player.altFunctionUse == 2){
                item.useTime = 4;
                item.damage = 44;
                item.useAnimation = 24;
                item.reuseDelay = 44;
            }
            return base.CanUseItem(player);
        }

        /*public override bool Shoot(Player player , ref Vector2 position , ref float speedX , ref float speedY , ref int type , ref int damage , ref float knockBack){

            int Spread = 20;
            Vector2 Speed = new Vector2(speedX , speedY).RotatedByRandom(MathHelper.ToRadians(Spread));
            Projectile.NewProjectile(position.X , position.Y , Speed.X , Speed.Y , type , damage , knockBack , player.whoAmI);

        }*/
        public override bool ConsumeAmmo(Player player){
            return !(player.itemAnimation < item.useAnimation - 2);
        }

        public override bool AltFunctionUse(Player player){
            return true;
        }
    }
}