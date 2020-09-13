using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.World.Generation;
using static Terraria.ModLoader.ModContent;


namespace NovaEdge{
    public class NovaEdgeWorld : ModWorld{
        public static bool downedSpaceSpooder;

        public override void Initialize(){
            downedSpaceSpooder = false;
            
        }
    }
}