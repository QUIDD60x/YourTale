using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace yourtale.Rarities
{
	public class Black2Green : ModRarity
	{
		public override Color RarityColor => new Color(Main.DiscoR / 100, (byte)(Main.DiscoG / 1), (byte)(Main.DiscoB / 100));

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			if (offset < 0)
			{
				return ModContent.RarityType<Black>();
			}

			return Type;
		}
	}
}