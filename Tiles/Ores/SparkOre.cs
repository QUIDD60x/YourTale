using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Tiles.Ores
{
    public class SparkOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileSpelunker[Type] = true;
            Main.tileShine[Type] = 110;

            ItemDrop = ItemType<Items.Placeables.SparkPowder>();

            DustType = 84;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Sparking Ore");
            AddMapEntry(new Color(255, 265, 0), name);
            HitSound = SoundID.Tink;
            MinPick = 5;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 255f;
            g = 165f;
            b = 0;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 6 : 8;
        }


        public class SparkOreSystem : ModSystem
        {
            public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
            {
                // Because world generation is like layering several images ontop of each other, we need to do some steps between the original world generation steps.

                // The first step is an Ore. Most vanilla ores are generated in a step called "Shinies", so for maximum compatibility, we will also do this.
                // First, we find out which step "Shinies" is.
                int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

                if (ShiniesIndex != -1)
                {
                    // Next, we insert our pass directly after the original "Shinies" pass.
                    // ExampleOrePass is a class seen bellow
                    tasks.Insert(ShiniesIndex + 1, new SparkOrePass("Sparking Ore", 237.4298f));
                }
            }
        }

        public class SparkOrePass : GenPass
        {
            public SparkOrePass(string name, float loadWeight) : base(name, loadWeight)
            {
            }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {

                progress.Message = "Adding in Sparking Ore..."; //asdfghjkl

                for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
                {

                    int x = WorldGen.genRand.Next(0, Main.maxTilesX);

                    int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);
                    Tile tile = Framing.GetTileSafely(x, y);
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(2, 4), ModContent.TileType<SparkOre>());
                }

            }
        }
    }
}