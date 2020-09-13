using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace NovaEdge.Items.AssassinClass{
    public abstract class AssassinItem : ModItem{

        public virtual void SafeSetDefaults() { //Override this to SetDefaults
		}

        public sealed override void SetDefaults(){
            SafeSetDefaults();
            item.melee = false;
            item.ranged = false;
            item.summon = false;
            item.magic = false;
            item.thrown = false;
        }
        public sealed override void ModifyWeaponDamage(Player player , ref float add , ref float mult , ref float flat){
            add += AssassinPlayer.ModPlayer(player).assassinDamageAdd;
            mult *= AssassinPlayer.ModPlayer(player).assassinDamageMult;
        }
        public sealed override void GetWeaponCrit(Player player , ref int crit){
            crit += AssassinPlayer.ModPlayer(player).assassinCrit;
        }
        public sealed override void GetWeaponKnockback(Player player , ref float knockback){
            knockback += AssassinPlayer.ModPlayer(player).assassinKnockback;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips ) { //Used to display the damage type ingame
            TooltipLine dmg = tooltips.FirstOrDefault(x => x.Name == "Damage" && x.mod == "Terraria");
            string[] split= dmg.text.Split(' ');
            string damageWord = split.Last();
            string damageValue = split.First();
            dmg.text = damageValue + " silent " + damageWord;
        }
        /*public int timer = 0;
         public int maxStealth = 100;
        public int stealth = 0;
        public void Stealth(Player player){
           
            
            if(timer <= 180){
                stealth += (int)(stealth + 1.8);
                if(stealth >= 10){
                    player.alpha -= 20;
                    if(stealth >= 20){
                        player.alpha -= 20;
                    }
                }
                if(stealth >= 100){
                    stealth = 100;
                    
                }
            }

        }*/


    }
}