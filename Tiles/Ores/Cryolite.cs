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
				// progress.Message is the message shown to the user while the following code is running.
				// Try to make your message clear. You can be a little bit clever, but make sure it is descriptive enough for troubleshooting purposes.
				progress.Message = "Adding in Cryolite...";

				// Ores are quite simple, we simply use a for loop and the WorldGen.TileRunner to place splotches of the specified Tile in the world.
				// "6E-05" is "scientific notation". It simply means 0.00006 but in some ways is easier to read.
				for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-07); k++)
				{
					
					// The inside of this for loop corresponds to one single splotch of our Ore.
					// First, we randomly choose any coordinate in the world by choosing a random x and y value.
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);

					// WorldGen.worldSurfaceLow is actually the highest surface tile. In practice you might want to use WorldGen.rockLayer or other WorldGen values.
					int y = WorldGen.genRand.Next((int)WorldGen.rockLayer, Main.maxTilesY);

					// Then, we call WorldGen.TileRunner with random "strength" and random "steps", as well as the Tile we wish to place.
					// Feel free to experiment with strength and step to see the shape they generate.
					//WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<Cryolite>());

					// Alternately, we could check the tile already present in the coordinate we are interested.
					// Wrapping WorldGen.TileRunner in the following condition would make the ore only generate in Snow.
					 /*Tile tile = Framing.GetTileSafely(x, y);
					 if (tile.active() && tile.type == TileID.SnowBlock)
					 {
					 	WorldGen.TileRunner(x, y, WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), ModContent.TileType<Cryolite>());
					 }*/
				}

			}
		}
	}
}