using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Reflection;

namespace NovaEdge.Items.GrumpyStumpy
{
    public class GrumpyStumpyBossTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("SpaceSpooder");
       

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("'EEE a spider!' <right> to open");
        }
        public override void SetDefaults()
        { //ADD DETAILS LATER
            item.rare = ItemRarityID.Cyan;
            item.width = 36;
            item.height = 32;
            item.maxStack = 999;
            item.consumable = true;
            item.expert = true;


        }
        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ItemID.GoldCoin, 10);
            player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ItemID.ManaPotion, 5);
            if(Main.rand.Next(7) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("MechSpiderFang"));
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("RepurposedBow"));
            }
            if (Main.rand.Next(2) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("HoloSpider"));
            }
            if (Main.rand.Next(100) == 0)
            {
                player.QuickSpawnItem(mod.ItemType("GrumpyStumpyBossTreasureBag"));
            }
        }
    }
}