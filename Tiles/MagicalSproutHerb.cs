using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;



namespace NovaEdge.Tiles{
    public class MagicalSproutHerb : ModTile{
        
        public override void SetDefaults(){
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
			Main.tileNoFail[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
			TileObjectData.newTile.AnchorValidTiles = new[]{
                2, //TileID.Grass
				109, // TileId.HallowedGrass
				
            };
            TileObjectData.addTile(Type);
            
           



        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects) {
			if (i % 2 == 1) {
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
        }
        public override bool Drop(int i , int j){
			int phase = Main.tile[i, j].frameX / 18;
            if (phase == 2) {
				Item.NewItem(i * 16, j * 16, 0, 0, ItemType<Items.Materials.MagicalSprout>());
			}
			return false;


        }
        public override void RandomUpdate(int i, int j) {
			if (Main.tile[i, j].frameX == 0) {
				Main.tile[i, j].frameX += 18;
			}
			else if (Main.tile[i, j].frameX == 18) {
				Main.tile[i, j].frameX += 18;
			}
		}

    }
}