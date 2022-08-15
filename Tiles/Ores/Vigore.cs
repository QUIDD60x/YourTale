﻿using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Tiles.Ores
{
    public class Vigore : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true; 
            Main.tileMergeDirt[Type] = true; 
            Main.tileBlockLight[Type] = true; 
            Main.tileLavaDeath[Type] = true;
            Main.tileShine[Type] = 95;

            ItemDrop = ItemType<Items.LifeShard>(); //drop = Item.itemhere for vanilla drops

            
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Vigore");
            AddMapEntry(new Color(13, 195, 4), name); 
            MinPick = 65; 
        }
        // Will let you modify the light level and colour, RGB variables are obviously RBG colours.
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 13f;
            g = 195f;
            b = 4f;
        }
        //will let you generate particles for it, don't quite understand this bit yet.
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public class VigoreOreSystem : ModSystem
        {
            public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
            {
                int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

                if (ShiniesIndex != -1)
                {
                    tasks.Insert(ShiniesIndex + 1, new VigoreOrePass("Vigore Ore", 237.4298f));
                }
            }
        }

        public class VigoreOrePass : GenPass
        {
            public VigoreOrePass(string name, float loadWeight) : base(name, loadWeight)
            {
            }

            protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
            {

                progress.Message = "Adding in Vigore...";

                for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-09); k++)
                {
                    int x = WorldGen.genRand.Next(0, Main.maxTilesX);


                    int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);

                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<Vigore>());
                }

            }
        }
    }
}