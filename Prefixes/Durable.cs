/*using Terraria;
using Terraria.ModLoader;

namespace NovaEdge.Prefixes{
    public class Durable : ModPrefix{
        private readonly byte _durability;

        public override float RollChance(Item item)
            => 10f;

         
        public override bool CanRoll(Item item)
			=> true;
        public override PrefixCategory Category
            => PrefixCategory.Accessory;

        public DurablePrefix(){

        }
        public DurablePrefix(byte durability){
            _durability = durability;
        }
        public override void Apply(Item item) 
			=> item.GetGlobalItem<EdgeGlobalItem>().durable = _durability;

		public override void ModifyValue(ref float valueMult) {
			float multiplier = 1f + 0.05f * _durability;
			valueMult *= multiplier;}
    }
}*/