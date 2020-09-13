using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace NovaEdge.Items.Weapons{
    public class PhantomEdge : ModItem{

        public override string Texture => "Terraria/Item_" + ItemID.TrueExcalibur;
        public override void SetDefaults(){
            item.damage = 145;
            item.melee = true;
            item.useStyle = 3;
            item.useTime = 24;
            item.useAnimation = 24;
            item.knockBack = 6f;
            item.value = 100000;
            item.rare = 6;
            item.crit = 10;
            item.UseSound = SoundID.Item1;
            item.width = 16;
            item.height = 16;

        }
        public override bool AltFunctionUse(Player player){
            return true;
        }
        public override bool CanUseItem(Player player){
           if(player.altFunctionUse != 2){
               item.damage = 145;
               item.useStyle = 3;
           }
           else if(player.altFunctionUse == 2){
               item.damage *= 3;
               item.useStyle = 1;
               item.CloneDefaults(ItemID.RodofDiscord);

           }
             return base.CanUseItem(player);
        
        }
    }
}