using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace NovaEdge.Items.BossSummons
{
    public class MechSpiderFang : ModItem{

        public override string Texture => "Terraria/Item_" + ItemID.SpiderFang;
        public override void SetStaticDefaults(){
            Tooltip.SetDefault("Wonder what kinda spider could have this fang?");
			ItemID.Sets.SortingPriorityBossSpawns[item.type] = 13;
        }
        public override void SetDefaults(){
            item.height = 20;
            item.width = 20;
            item.rare = 4;
            item.maxStack = 20;
            item.useTime = 45;
            item.useStyle = 4;
            item.useAnimation = 45;
            item.UseSound = SoundID.Item44;
			item.consumable = true;
        }
        public override bool CanUseItem(Player player){
            return Main.hardMode && player.ZoneSkyHeight && !NPC.AnyNPCs(ModContent.NPCType<NPCs.SpaceSpooder.SpaceSpooder>());

        }
        public override bool UseItem(Player player){
            NPC.NewNPC((int)player.Center.X , (int)(player.Center.Y + 640f) , ModContent.NPCType<NPCs.SpaceSpooder.SpaceSpooder>());
            Main.PlaySound(SoundID.Roar, player.position, 0);
			return true;
        }

        public override void AddRecipes(){
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SoulofNight , 6);
            recipe.AddIngredient(ItemID.SoulofFlight , 12);
            recipe.AddIngredient(ItemID.SpiderFang , 6);
            recipe.AddIngredient(ItemID.IronBar , 5);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}