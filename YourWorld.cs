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
using Terraria.WorldBuilding;
using yourtale.Tiles.Furniture;
using static Terraria.ModLoader.ModContent;
using System.IO;
using Terraria.Localization;
using Terraria.ModLoader.IO;
using yourtale.Tiles.Ores;
using yourtale.NPCs.Evil.Boss;

namespace yourtale
{
    public class YourWorld : ModSystem
    {
        public static bool downedCryolisis;

        public override void OnWorldLoad()/* tModPorter Suggestion: Also override OnWorldUnload, and mirror your worldgen-sensitive data initialization in PreWorldGen */
        {
            downedCryolisis = false;
        }
       
        public override void LoadWorldData(TagCompound tag)
        {
            var downed = tag.GetList<string>("downed");
            downedCryolisis = downed.Contains("Cryolisis");
        }

        /*public override TagCompound Save()
        {
			var Downed = new List<string>();
            /*if (downedCryolisis) { downed.Add("Cryolisis"); }
            
            return new TagCompound
            {
                ["downed"] = downed,
            };
        }*/

        

        /*public override void LoadLegacy(BinaryReader reader)
        {
            int loadVersion = reader.ReadInt32();
            
            if (loadVersion == 0)
            {
                BitsByte Flags1 = reader.ReadByte();
                downedCryolisis = flags[0];
                //BitsByte flags2 = reader.ReadByte();
                //BitsByte flags3 = reader.ReadByte();
                //BitsByte flags4 = reader.ReadByte();
                //BitsByte flags5 = reader.ReadByte();
            }

            /*else
            {
                mod.Logger.WarnFormat("yourtale: Unknown loadVersion: {0}", loadVersion);
            }
        }*/

        public override void NetSend(BinaryWriter writer)
        {
            var flags = new BitsByte();
            flags[0] = downedCryolisis;
            writer.Write(flags);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags = reader.ReadByte();
            downedCryolisis = flags[0];
        }

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

        private void OreGeneration(GenerationProgress progress)
        {   //code running message
            progress.Message = "adding in Your Tale ores";
            // 6E-05 = 0.00006
            // So (Main.maxTilesX * Main.maxTilesY) * 0.00006
            // (4200 * 1200) * 0.00006 = 302.4
            for (int i = 0; i < (int)((Main.maxTilesX * Main.maxTilesY) * 9E-05); i++)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)WorldGen.worldSurfaceLow, Main.maxTilesY);

                //Higher numbers mean more, for some reason overlapping TileIDs will cause a lower chance ore to just not spawn, idk why atm. 
                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.HasTile && (tile.TileType == TileID.Sand || tile.TileType == TileID.Dirt || tile.TileType == TileID.Mud))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(18, 35), WorldGen.genRand.Next(45, 80), TileType<Tiles.Ores.FlintDeposit>()); //worldgen numbers can and should be messed with untill you are happy
                }
                if (tile.HasTile && (tile.TileType == TileID.SnowBlock || tile.TileType == TileID.IceBlock))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(12, 24), WorldGen.genRand.Next(8, 45), TileType<Tiles.Ores.Cryolite>());
                }
                if (tile.HasTile && (tile.TileType == TileID.Stone || tile.TileType == TileID.ClayBlock || tile.TileType == TileID.Iron))
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 15), WorldGen.genRand.Next(15, 40), TileType<Tiles.Ores.Dolomite>());
                }
                if (tile.TileType == TileID.Emerald || tile.TileType == TileID.Amethyst || tile.TileType == TileID.Diamond || tile.TileType == TileID.Sapphire || tile.TileType == TileID.Topaz || tile.TileType == TileID.Ruby || tile.TileType == TileID.Gold || tile.TileType == TileID.Platinum || tile.TileType == TileID.Lead)
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(80, 100), WorldGen.genRand.Next(80, 100), TileType<Tiles.Ores.Vigore>());
                }
                if (tile.TileType == TileID.RichMahogany)
                {
                    WorldGen.TileRunner(x, y, WorldGen.genRand.Next(5, 90), WorldGen.genRand.Next(6, 99), TileType<Tiles.Ores.Vigore>());
                }
            }
        }

        private void ChestGeneration(GenerationProgress progress)
        {
            progress.Message = "Adding YourTale loot into chests";
            for (int i = 0; i < 0; i++)
            {
                bool placeSuccessful = true;
                ushort tileToPlace = (ushort)TileType<Tiles.Furniture.TestChest>();
                int oldChestId = -1;
                int chestId = -1;
                while (!placeSuccessful)
                {
                    int x = WorldGen.genRand.Next(1, Main.maxTilesX);
                    int y = WorldGen.genRand.Next(1, Main.maxTilesY);
                    oldChestId = chestId;
                    chestId = WorldGen.PlaceChest(x, y, tileToPlace, true, 1);
                    if (chestId != -1)
                    {
                        progress.Message = chestId.ToString();
                        Chest chest = Main.chest[chestId];
                        chest.item[1].SetDefaults(ItemType<Items.flint>());
                        chest.item[1].stack = WorldGen.genRand.Next(1, 1);
                        chest.item[2].SetDefaults(ItemType<Items.Weapons.Melee.THESWORD>());
                        chest.item[2].stack = WorldGen.genRand.Next(1, 1);
                        int index = 3;
                        switch (i)
                        {
                            case 0:
                                chest.item[3].SetDefaults(ItemID.BandofRegeneration);
                                break;
                            case 1:
                                chest.item[4].SetDefaults(ItemID.HermesBoots);
                                break;
                            default:
                                chest.item[5].SetDefaults(ItemID.MagicMirror);
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