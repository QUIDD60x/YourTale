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
	public class Cryolite : ModTile
	{
		public override void SetStaticDefaults()
		{ //these are all important and should be specified.
			Main.tileSolid[Type] = true;  //will make it a solid block.
			Main.tileMergeDirt[Type] = true;  //will merge with dirt, probably the most important.
			Main.tileBlockLight[Type] = true; //will produce random light spurts, like chlorphylite.
			Main.tileLavaDeath[Type] = true; //will "die" (be destroyed) if connected to lava
			Main.tileSpelunker[Type] = true; //will trigger the spelunker potion as an ore.
			Main.tileShine[Type] = 80; //amount of light produced as a integer.

			ItemDrop = ItemType<Items.Placeables.Cryolite>(); //drop = Item.itemhere for vanilla drops

			DustType = 84; //dustType = DustID.Platinum for vanilla, dustType = mod.dustType.Platinum for modded
			ModTranslation name = CreateMapEntryName(); //adds a map entry so it will be pointed out on a map.
			name.SetDefault("Cryolite");
			AddMapEntry(new Color(129, 159, 242), name); //or AddMapEntry(Color.Red) or any other colour in the color class
			HitSound = SoundID.Tink;
			MinPick = 35; //will set minimum pick strength
		}
		// Will let you modify the light level and colour, RGB variables are obviously RBG colours.
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 129f;
			g = 159f;
			b = 242f;
		}
		//will let you generate particles for it, don't quite understand this bit yet.
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 3;
		}


		public class CryoliteOreSystem : ModSystem
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
					tasks.Insert(ShiniesIndex + 1, new CryoliteOrePass("Cryolite Ore", 237.4298f));
				}
			}
		}

		public class CryoliteOrePass : GenPass
		{
			public CryoliteOrePass(string name, float loadWeight) : base(name, loadWeight)
			{
			}

			protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
			{

				progress.Message = "Adding in Cryolite...";

				for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-05); k++)
				{
					
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);

					int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);

					//WorldGen.TileRunner(x, y, WorldGen.genRand.Next(2, 4), WorldGen.genRand.Next(2, 4), ModContent.TileType<Cryolite>());

					 Tile tile = Framing.GetTileSafely(x, y);
					 if (tile.HasTile && tile.TileType == TileID.SnowBlock || tile.HasTile && tile.TileType == TileID.IceBlock)
					 {
					 	WorldGen.TileRunner(x, y, WorldGen.genRand.Next(4, 7), WorldGen.genRand.Next(3, 7), ModContent.TileType<Cryolite>());
					 }
				}

			}
		}
	}
}