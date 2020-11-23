using Terraria;
using Terraria.ModLoader;
using Terraria.ID;


namespace NovaEdge.Items.Armors
{
        [AutoloadEquip(EquipType.Head)]

    public class MonsoonFacemask : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Monsoon Facemask");
            Tooltip.SetDefault("War is a cruel parent but an effective teacher.\n+7% increased melee damage and critical strike chance\n+5% melee speed");
        }
        public override void SetDefaults()
        {
            item.rare = ItemRarityID.Lime;
            item.value = Item.sellPrice(gold: 24);
            item.width = item.height = 40;
            item.defense = 24;
        }
        public override void UpdateEquip(Player player)
        {

            player.meleeDamage += 0.07f;
            player.meleeCrit += 7;
            player.meleeSpeed += 0.05f;
        }
        
    }
}
