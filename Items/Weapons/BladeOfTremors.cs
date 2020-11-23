using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace NovaEdge.Items.Weapons
{
    public class BladeOfTremors : ModItem

    {
        //public override string Texture => "Terraria/Item_" + ItemID.TrueExcalibur;
        public override void SetDefaults()
        {
            item.melee = true;
            item.knockBack = 20f;
            item.damage = 350;
            item.crit = 24;
            item.useTime = 60;
            item.useAnimation = 60;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.useTurn = true;
            item.autoReuse = true;
            item.scale = 2f;
            item.UseSound = SoundID.Item1;
            item.width = item.height = 60;
            
        }
        public override bool CanUseItem(Player player)
        {
            if(player.altFunctionUse != 2)
            {
                item.useTime = 60;
                item.damage = 350;
                item.useAnimation = 60;
                item.scale = 2f;
            }
            else if (player.altFunctionUse == 2)
            {
                item.useTime = 120;
                item.damage = 455;
                item.useAnimation = 120;
                item.scale = 6f;
                item.alpha = 150;
            }
            return base.CanUseItem(player);
        }
        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            if(target.knockBackResist < 1 && !target.boss && player.altFunctionUse != 2)
            {
                target.knockBackResist += 0.02f;
            }
        }
        public override bool AltFunctionUse(Player player)
        {
            return true;
        }


    }
}
