using System;
using yourtale.Tiles.Ores;
using Terraria.ModLoader;

namespace yourtale.Biomes
{
	public class BiomeTileCount : ModSystem
	{
		public int exampleBlockCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
			exampleBlockCount = tileCounts[ModContent.TileType<Dolomite>()];
		}
	}
}