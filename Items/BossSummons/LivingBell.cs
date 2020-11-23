using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Reflection;

namespace NovaEdge.Items.BossSummons
{
    public class LivingBell : ModItem{

        public override void SetStaticDefaults(){
            Tooltip.SetDefault("GAURD'S, ATTACK!!!!");
        }
        public override void SetDefaults() {
            item.height = 20;
            item.width = 20;
            item.rare = ItemRarityID.LightRed;
            item.maxStack = 20;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 45;
            item.UseSound = SoundID.Item35;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("GrumpyStumpy"));

        }
        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position);
                
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("GrumpyStumpy"));
                }
            return true;
        }

        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood , 30);
            recipe.AddIngredient(ItemID.Acorn , 5);
            recipe.AddIngredient(ItemID.Vine , 6);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}