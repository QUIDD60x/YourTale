using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace YourTale.Rarities
{
	public class Black2Blue : ModRarity
	{
		public override Color RarityColor => new Color(Main.DiscoR / 100, (byte)(Main.DiscoG / 100), (byte)(Main.DiscoB / 1));

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			if (offset < 0)
			{
				return ModContent.RarityType<AncientPurple>();
			}

			return Type;
		}
	}
}