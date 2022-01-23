using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.World.Generation;
using yourtale.Tiles.Furniture;
using static Terraria.ModLoader.ModContent;
using System.IO;
using Terraria.Localization;
using Terraria.ModLoader.IO;

namespace yourtale
{
    public class YourWorld : ModWorld
    {
        public static int StartPositionX = 0;
        public static int StartPositionY = 0;
        public static int Bed = 0;
        public static int Table = 0;
        public static int Wood = TileID.WoodBlock;
        public static int WoodWall = 4;
        public static int StoneWall = 5;
        public static int Brick = 38;
        public static int WoodTile = 106;
        public static int Door = 0;
        public static int Platform = 0;
        public static int Stone = TileID.Stone;
        public static int LivingWoodWall = 78;
        public static int PlankedWall = 27;
        public static int StoneSlab = 273;
        public static int StoneSlabWall = 147;
        public static int Fence = 106;
        public static int Grass = 2;
        public static int Chair = 0;
        private static bool GenerateHouse = false;

              //0=air, 1=dirt/snow/ice, 2=wood, 3=stone brick, 4=stone, 5=platform, 6=stone slab, 7=grass		
        static readonly byte[,] GuideHouse =
        {
			{1,1,4,4,4,1,3,3,3,3,3,3,3,3,3,1,1,1,1,1,1,1,1,1},
			{1,1,4,4,1,1,3,6,6,6,6,6,6,6,3,4,4,4,1,1,4,4,1,1},
            {1,1,1,1,1,1,3,6,0,0,0,0,0,6,3,1,4,4,1,4,4,1,1,4},
            {1,1,1,1,1,4,3,6,0,0,0,0,0,6,3,1,1,1,4,4,1,1,4,4},
            {7,7,7,3,3,3,3,6,0,0,6,6,6,6,3,3,3,3,3,3,3,1,1,4},
            {0,0,0,2,2,2,2,1,0,0,2,2,2,2,2,2,1,1,1,2,2,7,7,7},
            {8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8},
            {8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8},
            {8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8},
            {8,8,8,8,8,8,8,5,5,5,5,8,8,8,8,8,8,8,8,2,8,8,8,8},
            {8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,8,2,8,8,8,8},
            {8,8,8,8,2,2,8,8,8,8,8,8,8,8,8,8,8,8,2,2,8,8,8,8},
            {0,0,0,0,2,2,2,5,5,5,5,2,2,2,2,2,2,2,2,2,3,3,0,0},
			{0,0,0,0,3,2,2,0,0,0,0,0,0,0,0,0,0,2,2,3,3,3,0,0},
			{0,0,0,0,3,3,2,2,0,0,0,0,0,0,0,0,0,0,3,3,3,0,0,0},
			{0,0,0,0,0,3,3,2,2,0,0,0,0,0,0,0,0,0,3,3,0,0,0,0},
			{0,0,0,0,0,3,3,3,2,2,0,0,0,0,2,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,3,3,3,2,2,0,0,2,2,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,3,3,2,2,2,2,3,3,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,3,3,3,2,2,3,3,3,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,3,3,3,3,3,3,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,3,3,3,3,0,0,0,0,0,0,0,0,0,0}
		};

        //0=air, 1=stone wall, 2=wooden wall, 3=living wood wall, 4=planked wall, 5=stone slab wall, 6=fence
        static readonly byte[,] GuideHouseWall =
        {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,5,5,5,5,5,0,0,0,0,0,0,0,0,0,0,0},
			{6,6,6,6,6,0,0,2,5,5,2,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{6,0,6,6,6,2,3,2,2,2,2,0,0,0,0,0,2,3,2,6,6,6,6,6},
			{0,0,6,0,6,0,0,2,2,2,2,0,0,0,2,2,2,3,2,6,0,6,6,0},
			{0,0,6,0,0,0,0,0,2,2,2,2,0,0,2,2,2,3,2,0,0,0,6,0},
			{0,0,0,0,0,0,0,0,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,0,3,2,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,2,3,2,2,2,2,2,3,2,2,2,2,3,2,0,0,0,0,0},
			{0,0,0,0,0,0,4,3,4,4,3,4,4,3,4,4,3,4,0,0,0,0,0,0},
			{0,0,0,0,0,0,4,3,4,4,3,4,4,3,4,4,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,3,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,4,4,4,3,4,4,3,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,4,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,4,3,4,4,3,4,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0}
		};

        public override void Initialize()
        {
            GenerateHouse = false;
        }

        public override TagCompound Save()
        {
            var Generated = new BitsByte();
            Generated[0] = GenerateHouse;
			var Downed = new List<string>();
            return new TagCompound
            {
                {
                    "StartPositionX",
                    (object)StartPositionX
                },
                {
                    "StartPositionY",
                    (object)StartPositionY
                },
                {
                    "Generated",
                    (byte)Generated
                },
				{
                    "Misc",
                    (byte)Generated
                },
                {
                    "Version", 0
                },
				{
                    "Downed", Downed
                }
            };
        }

        public override void Load(TagCompound tag)
        {
            var Generated = (BitsByte)tag.GetByte("Generated");
            GenerateHouse = Generated[0];
            StartPositionX = tag.GetInt("StartPositionX");
            StartPositionY = tag.GetInt("StartPositionY");
            var Downed = tag.GetList<string>("Downed");
        }

        public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            if (loadVersion == 0)
            {
                BitsByte Flags1 = reader.ReadByte();
                StartPositionX = reader.ReadInt32();
                StartPositionY = reader.ReadInt32();
            }
        }

        public override void NetSend(BinaryWriter writer)
        {
            BitsByte Flags1 = new BitsByte();
			BitsByte Flags2 = new BitsByte();
            Flags1[0] = GenerateHouse;
            writer.Write(Flags1);
			writer.Write(Flags2);
            writer.Write(StartPositionX);
            writer.Write(StartPositionY);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte Flags1 = reader.ReadByte();
            BitsByte Flags2 = reader.ReadByte();
            GenerateHouse = Flags1[0];
            StartPositionX = reader.ReadInt32();
            StartPositionY = reader.ReadInt32();
        }

        //0=none, 1=bottom-left, 2=bottom-right, 3=top-left, 4=top-right, 5=half
        static readonly byte[,] GuideHouseSlopes =
        {
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
            {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,5,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,3,0,0,0,0,0,0,0,0,0,0,0,0,4,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
			{0,0,2,0,0,0,3,0,0,0,0,0,0,0,0,0,0,4,0,0,0,1,0,0},
			{0,0,0,2,0,0,0,3,0,0,0,0,0,0,0,0,4,0,0,0,1,0,0,0},
			{0,0,0,0,2,0,0,0,3,0,0,0,0,0,0,4,0,0,0,1,0,0,0,0},
			{0,0,0,0,0,2,0,0,0,3,0,0,0,0,4,0,0,0,1,0,0,0,0,0},
			{0,0,0,0,0,0,2,0,0,0,3,0,0,4,0,0,0,1,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,2,0,0,0,3,4,0,0,0,1,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,2,0,0,0,0,1,0,0,0,0,0,0,0,0,0},
			{0,0,0,0,0,0,0,0,0,0,2,0,0,1,0,0,0,0,0,0,0,0,0,0}
		};

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight) //each task has a different name/stage,
        {
            int shiniesIndex = tasks.FindIndex(x => x.Name.Equals("Shinies"));
            if (shiniesIndex != -1)
            {
                tasks.Insert(shiniesIndex + 1, new PassLegacy("yourtale ore generation", OreGeneration));
            }
            int buriedChestIndex = tasks.FindIndex(x => x.Name.Equals("TestChest"));
            if (buriedChestIndex != -1)
            {
                tasks.Insert(buriedChestIndex + 1, new PassLegacy("yourtale chest generation", ChestGeneration));
            }
        }

        public void AddGuideHouse(GenerationProgress progress = null)
        {
            if (GenerateHouse)
            {
                return;
            }
            try
            {
                bool Success = do_MakeGuideHouse(progress);
                if (Success)
                {
                    GenerateHouse = true;
                }
            }
            catch (Exception exception)
            {
                Main.NewText("If you're seeing this error message then something went wrong! check error log for more info. -Quidd");
                ErrorLogger.Log(exception);
            }
        }

        bool do_MakeGuideHouse(GenerationProgress progress)
        {
			string GuideHouseGen = Language.GetTextValue("Mods.Antiaris.GuideHouseGen");
            if (progress != null)
            {
                progress.Message = GuideHouseGen;
                progress.Set(0.1f);
            }
            StartPositionX = WorldGen.genRand.Next(Main.maxTilesX / 2 + 5, Main.spawnTileX + 50);
            for (var Attempts = 0; Attempts < 10000; Attempts++)
            {
                for (var i = 0; i < 25; i++)
                {
                    StartPositionY = 190;
                    do
                    {
                        StartPositionY++;
                    }
                    while ((!Main.tile[StartPositionX + i, StartPositionY].active() && StartPositionY < Main.worldSurface) || Main.tile[StartPositionX + i, StartPositionY].type == TileID.Trees || Main.tile[StartPositionX + i, StartPositionY].type == 27);
                    if (!Main.tile[StartPositionX, StartPositionY].active() || Main.tile[StartPositionX, StartPositionY].liquid > 0)
                    {
                        StartPositionX++;
                    }
                    if (Main.tile[StartPositionX + i, StartPositionY].active())
                    {
						if (Main.tile[StartPositionX, StartPositionY].liquid > 0)
							StartPositionX = WorldGen.genRand.Next(Main.maxTilesX / 2 + 5, Main.spawnTileX + 50);
                        goto GenerateBuild;
                    }
                }
            }
            return false;

            GenerateBuild:
            for (var t = 0; t < 6; t++)
            {
                if (Main.tile[StartPositionX, StartPositionY + t].type == TileID.SnowBlock)
                {
                    Bed = 24;
                    Wood = 321;
                    WoodWall = 149;
                    StoneWall = 84;
                    Brick = 206;
                    WoodTile = 150;
                    Table = 28;
                    Door = 30;
                    Platform = 19;
                    Chair = 60;
                    Stone = TileID.IceBlock;
                    Grass = TileID.SnowBlock;
                    Fence = WallID.BorealWoodFence;
                }
                if (Main.tile[StartPositionX, StartPositionY + t].type == TileID.Dirt)
                {
                    Bed = 0;
                    Wood = TileID.WoodBlock;
                    WoodWall = 4;
                    StoneWall = 5;
                    Brick = 38;
                    WoodTile = 106;
                    Door = 0;
                    Table = 0;
                    Platform = 0;
                    Chair = 0;
                    Stone = TileID.Stone;
                    Grass = 2;
                    Fence = 106;
                }
                if (Main.tile[StartPositionX, StartPositionY + t].type == TileID.IceBlock)
                {
                    Bed = 24;
                    Wood = 321;
                    WoodWall = 149;
                    StoneWall = 84;
                    Brick = 206;
                    WoodTile = 150;
                    Table = 28;
                    Door = 60;
                    Platform = 19;
                    Chair = 30;
                    Stone = TileID.IceBlock;
                    Grass = TileID.SnowBlock;
                    Fence = WallID.BorealWoodFence;
                }
            }
            StartPositionY += 3;
            for (var X = 0; X < GuideHouse.GetLength(1); X++)
            {
                for (var Y = 0; Y < GuideHouse.GetLength(0); Y++)
                {
                    var tile = Framing.GetTileSafely(StartPositionX + X, StartPositionY - Y);
                    switch (GuideHouse[Y, X])
                    {
                        case 0:
                            break;
                        case 2:
                            tile.type = (ushort)Wood;
                            tile.active(true);
                            break;
                        case 3:
                            tile.type = (ushort)Brick;
                            tile.active(true);
                            break;
                        case 4:
                            tile.type = (ushort)Stone;
                            tile.active(true);
                            break;
						case 5:
							WorldGen.PlaceTile(StartPositionX + X, StartPositionY - Y, TileID.Platforms, true, true, -1, Platform);
							break;
						case 6:
                            tile.type = (ushort)StoneSlab;
                            tile.active(true);
                            break;
						case 7:
                            tile.type = (ushort)Grass;
                            tile.active(true);
                            break;
                        case 8:
                            WorldGen.KillTile(StartPositionX + X, StartPositionY - Y, false, false, false);
                            break;
                    }
                    switch (GuideHouseWall[Y, X])
                    {
                        case 0:
                            tile.wall = 0;
                            break;
                        case 1:
                            tile.wall = (ushort)StoneWall;
                            break;
                        case 2:
                            tile.wall = (ushort)WoodWall;
                            break;
                        case 3:
                            tile.wall = (ushort)LivingWoodWall;
                            break;
						case 4:
							tile.wall = (ushort)PlankedWall;
							break;
						case 5:
							tile.wall = (ushort)StoneSlabWall;
							break;
						case 6:
							tile.wall = (ushort)Fence;
							break;
                    }
                    if (GuideHouseSlopes[Y, X] == 5)
                    {
                        tile.halfBrick(true);
                    }
                    else
                    {
                        tile.halfBrick(false);
                        tile.slope(GuideHouseSlopes[Y, X]);
                    }
					WorldGen.PlaceObject(StartPositionX + 11, StartPositionY - 13, 79, true, Bed);
					var ChestIndex2 = Chest.FindChest(StartPositionX + 14, StartPositionY - 14);
					WorldGen.PlaceObject(StartPositionX + 11, StartPositionY - 11, 42, true, 3);
					WorldGen.PlaceObject(StartPositionX + 14, StartPositionY - 15, 78, true);
					WorldGen.PlaceObject(StartPositionX + 8, StartPositionY - 5, 387, true);
					WorldGen.PlaceObject(StartPositionX + 11, StartPositionY - 6, 14, true, Table);
					WorldGen.PlaceObject(StartPositionX + 11, StartPositionY - 8, 103, true);
					WorldGen.PlaceObject(StartPositionX + 8, StartPositionY - 10, 50, true);
					WorldGen.PlaceObject(StartPositionX + 9, StartPositionY - 10, 13, true, 1);
					WorldGen.PlaceObject(StartPositionX + 15, StartPositionY - 10, 246, true, 3);
					WorldGen.PlaceObject(StartPositionX + 19, StartPositionY - 6, 10, true, Door);
                    WorldGen.KillTile(StartPositionX + 11, StartPositionY - 2, false, false, true);
                    WorldGen.KillTile(StartPositionX + 12, StartPositionY - 2, false, false, true);
                    WorldGen.KillTile(StartPositionX + 11, StartPositionY - 3, false, false, true);
                    WorldGen.KillTile(StartPositionX + 12, StartPositionY - 3, false, false, true);
                    WorldGen.KillTile(StartPositionX + 10, StartPositionY - 2, false, false, true);
                    WorldGen.KillTile(StartPositionX + 9, StartPositionY - 2, false, false, true);
                    WorldGen.KillTile(StartPositionX + 10, StartPositionY - 3, false, false, true);
                    WorldGen.KillTile(StartPositionX + 9, StartPositionY - 3, false, false, true);
                    WorldGen.KillTile(StartPositionX + 8, StartPositionY - 2, false, false, true);
                    WorldGen.KillTile(StartPositionX + 8, StartPositionY - 3, false, false, true);
                    WorldGen.PlaceChest(StartPositionX + 11, StartPositionY - 2, 21, true, 28);
					var ChestIndex1 = Chest.FindChest(StartPositionX + 11, StartPositionY - 3);
                }
            }
            return true;
        }

        private void OreGeneration(GenerationProgress progress)
        {   //code running message
            progress.Message = "adding in YourTale ores...";
            // 6E-05 = 0.00006
            // So (Main.maxTilesX * Main.maxTilesY) * 0.00006
            // (4200 * 1200) * 0.00006 = 302.4
            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 9E-05); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.active() && (tile.type == TileID.Sand || tile.type == TileID.Dirt || tile.type == TileID.Mud))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(18, 35), WorldGen.genRand.Next(45, 80), TileType<Tiles.Ores.FlintDeposit>()); //worldgen numbers can and should be messed with untill you are happy
                }
                if (tile.active() && (tile.type == TileID.SnowBlock || tile.type == TileID.IceBlock))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(12, 24), WorldGen.genRand.Next(8, 45), TileType<Tiles.Ores.Cryolite>());
                }
                if (tile.active() && (tile.type == TileID.Stone || tile.type == TileID.ClayBlock || tile.type == TileID.Iron))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 15), WorldGen.genRand.Next(15, 40), TileType<Tiles.Ores.Dolomite>());
                }
            }
        }

        private void ChestGeneration(GenerationProgress progress)
        {
            progress.Message = "Adding YourTale loot into chests";
            for (int i = 0; i < 3; i++)
            {
                bool placeSuccessful = true;
                ushort tileToPlace = (ushort)TileType<Tiles.Furniture.TestChest>();
                int oldChestId = -1;
                int chestId = -1;
                while (!placeSuccessful)
                {
                    int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                    int y = WorldGen.genRand.Next(0, Main.maxTilesY);
                    oldChestId = chestId;
                    chestId = WorldGen.PlaceChest(x, y, tileToPlace, true, 1);
                    if (chestId != -1)
                    {
                        progress.Message = chestId.ToString();
                        Chest chest = Main.chest[chestId];
                        chest.item[1].SetDefaults(ItemType<Items.flint>());
                        chest.item[1].stack = WorldGen.genRand.Next(1, 1);
                        chest.item[1].SetDefaults(ItemType<Items.Weapons.Melee.THESWORD>());
                        chest.item[1].stack = WorldGen.genRand.Next(1, 1);
                        int index = 3;
                        switch (i)
                        {
                            case 0:
                                chest.item[2].SetDefaults(ItemID.BandofRegeneration);
                                break;
                            case 1:
                                chest.item[2].SetDefaults(ItemID.HermesBoots);
                                break;
                            default:
                                chest.item[2].SetDefaults(ItemID.MagicMirror);
                                break;
                        }

                        if (WorldGen.genRand.Next(3) == 0)
                        {
                            chest.item[index].SetDefaults(ItemID.Bomb);
                            chest.item[index].stack = WorldGen.genRand.Next(10, 20);
                            index++;
                        }
                        if (WorldGen.genRand.Next(2) == 0)
                        {
                            chest.item[index].SetDefaults(ItemID.Shuriken);
                            chest.item[index].stack = WorldGen.genRand.Next(30, 50);
                            index++;
                        }
                        yourtaleUtils.Log("Chest at {0}, {1}", x, y);
                        placeSuccessful = true;
                    }
                }
            }

        }
    }
}