using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Tiles.Ores
{								//TODO: ore generation, make actual tile, debugging.
	public class Athium : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileSolid[Type] = true;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileSpelunker[Type] = true;
			Main.tileShine[Type] = 90;

			DustType = 128;
			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(22, 200, 12), name);
			HitSound = SoundID.Tink;
			MinPick = 110; //will set minimum pick strength
		}
		// Will let you modify the light level and colour, RGB variables are obviously RBG colours.
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 29f;
			g = 159f;
			b = 42f;
		}
		//will let you generate particles for it, don't quite understand this bit yet.
		public override void NumDust(int i, int j, bool fail, ref int num)
		{
			num = fail ? 1 : 4;
		}


		public class AthiumOreSystem : ModSystem
		{
			public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
			{
				int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));

				if (ShiniesIndex != -1)
				{
					tasks.Insert(ShiniesIndex + 1, new AthiumOrePass("Athium Ore", 40.42f));
				}
			}
		}

		public class AthiumOrePass : GenPass
		{
			public AthiumOrePass(string name, float loadWeight) : base(name, loadWeight)
			{
			}

			protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
			{

				progress.Message = "Adding in Athium ore..."; //I love her so much, more than anything else I do and I know she'll never see this but Hi S, I hope you're doing absolutely splentastic and I wish I could tell you how much I love you but I genuinely don't have words to say them, but you mean the world to me and I hope we can happy together forever.

				for (int k = 0; k < (int)(Main.maxTilesX * Main.maxTilesY * 6E-06); k++)
				{
					
					int x = WorldGen.genRand.Next(0, Main.maxTilesX);

					int y = WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, Main.maxTilesY / 2);

					WorldGen.TileRunner(x, y, WorldGen.genRand.Next(6, 11), WorldGen.genRand.Next(6, 12), ModContent.TileType<Athium>());
				}

			}
		}
	}
}