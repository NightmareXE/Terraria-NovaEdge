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


namespace NovaEdge
{
    public class NovaEdgeWorld : ModWorld
    {
        public static bool experimentalMode;
        public static bool downedSpaceSpooder;

        public override void Initialize()
        {
            downedSpaceSpooder = false;
            experimentalMode = false;
        }
        public override TagCompound Save()
        {
            var stuff = new List<string>();
            if (experimentalMode)
            {
                stuff.Add("experimentalMode");
            }
            if (downedSpaceSpooder)
            {
                stuff.Add("downedSpaceSpooder");
            }
            return new TagCompound { ["stuff"] = stuff };

        }
        public override void Load(TagCompound tag)
        {
            var stuff = tag.GetList<string>("downed");
            downedSpaceSpooder = stuff.Contains("downedSpaceSpooder");
            experimentalMode = stuff.Contains("experimentalMode");

        }
        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte flags = reader.ReadByte();
                experimentalMode = flags[0];
                downedSpaceSpooder = flags[1];

            }
            else
            {
                mod.Logger.WarnFormat("NovaEdge: Unknown loadVersion: {0}", loadVersion);
            }
        }
        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = experimentalMode;
            flags[1] = downedSpaceSpooder;

            writer.Write(flags);

        }
        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            experimentalMode = flags[0];
            downedSpaceSpooder = flags[1];
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex != -1)
            {
                // Next, we insert our step directly after the original "Shinies" step. 
                
                tasks.Insert(ShiniesIndex + 1, new PassLegacy("Magentized Ores", MagnetizedOre));
            }
        }
        private void MagnetizedOre(GenerationProgress progress)
        {
            progress.Message = "Spawning Magnetized Ore!";
            for (int k = 0; k < (int)((Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);
                WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileID.LeafBlock);
            }

        }
    }
}