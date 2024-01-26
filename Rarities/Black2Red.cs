using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace YourTale.Rarities
{
	public class Black2Red : ModRarity
	{
		public override Color RarityColor => new Color(Main.DiscoR / 1, (byte)(Main.DiscoG / 100), (byte)(Main.DiscoB / 100));

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			if (offset < 0)
			{ // If the offset is -1 or -2 (a negative modifier).
				return ModContent.RarityType<Gold>(); // Make the rarity of items that have this rarity with a negative modifier the lower tier one.
			}

			return Type; // no 'higher' tier to go to, so return the type of this rarity.
		}
	}
}