using Terraria;
using Terraria.ModLoader;

namespace yourtale.Prefixes.Accessories
{
	public class Weighted : ModPrefix
	{
		public virtual float Power => 1f;

		public override PrefixCategory Category => PrefixCategory.Accessory;

		public override float RollChance(Item item)
		{
			return 5f;
		}

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			useTimeMult /= 1f + 100f * Power;
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1f + 0.05f * Power;
		}

		public override void Apply(Item item)
		{
			//
		}
	}
}