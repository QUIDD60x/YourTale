using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace YourTale.Rarities
{
	public class AncientPurple : ModRarity
	{
		public override Color RarityColor => new Color(203, 100, 94);

		public override int GetPrefixedRarity(int offset, float valueMult)
		{
			if (offset > 0)
			{ // If the offset is 1 or 2 (a positive modifier).
				return ModContent.RarityType<Black2Blue>(); // Make the rarity of items that have this rarity with a positive modifier the higher tier one.
			}

			return Type; // no 'lower' tier to go to, so return the type of this rarity.
		}
	}
}