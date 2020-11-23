using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace NovaEdge.Items.BossSummons
{
    public class HornySkull : ModItem{

        public override void SetStaticDefaults(){
            Tooltip.SetDefault("What is this?");
        }
        public override void SetDefaults() {
            item.height = 20;
            item.width = 20;
            item.rare = ItemRarityID.LightRed;
            item.maxStack = 20;
            item.useTime = 45;
            item.useStyle = ItemUseStyleID.HoldingUp;
            item.useAnimation = 45;
            item.UseSound = SoundID.Item44;
            item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            return !NPC.AnyNPCs(mod.NPCType("EmblazedKeeper"));
            
        }
        public override bool UseItem(Player player)
        {
            Main.PlaySound(SoundID.Roar, player.position);
                
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("EmblazedKeeper"));
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("EmblazedSpirit"));
            }
            return true;
        }

        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight , 6);
            recipe.AddIngredient(ItemID.SoulofFlight , 12);
            recipe.AddIngredient(ItemID.ObsidianSkull , 6);
            recipe.AddIngredient(ItemID.CrimtaneBar , 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}