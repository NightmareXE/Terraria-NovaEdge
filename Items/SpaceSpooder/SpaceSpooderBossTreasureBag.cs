using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using System.Reflection;
using NovaEdge.Items.SpaceSpooder;

namespace NovaEdge.Items.SpaceSpooder
{
    public class SpaceSpooderBossTreasureBag : ModItem
    {
        public override int BossBagNPC => mod.NPCType("SpaceSpooder");
       

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Treasure Bag");
            Tooltip.SetDefault("Right-Click to open");
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
        public override bool CanRightClick()
        {
            return true;
        }
        public override void OpenBossBag(Player player)
        {
            player.QuickSpawnItem(ItemID.GoldCoin, 10);
            player.QuickSpawnItem(ItemID.GreaterHealingPotion, Main.rand.Next(5, 10));
            player.QuickSpawnItem(ItemID.ManaPotion, 5);
            int random = Main.rand.Next(1, 5); //Randomizes a number between 1 and 4 for drops
            switch (random)
            {
                case 1:
                    player.QuickSpawnItem(ModContent.ItemType<HoloSpider>());
                    break;
                case 2:
                    player.QuickSpawnItem(ModContent.ItemType<MechEggStaff>());
                    break;
                case 3:
                    player.QuickSpawnItem(ModContent.ItemType<BoosterBlade>());
                    break;
                case 4:
                    player.QuickSpawnItem(ModContent.ItemType<RepurposedLegs>());
                    break;
            }
        }
    }
}