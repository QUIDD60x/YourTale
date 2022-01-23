using Terraria;
using Terraria.ModLoader;

namespace yourtale.Prefixes
{
	public class Wrathful : ModPrefix
	{
		public virtual float Power => 1f;

		public override PrefixCategory Category => PrefixCategory.Melee;

		public override float RollChance(Item item)
		{
			return 2.5f;
		}

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult *= 1.1f * Power;
			knockbackMult += 0.5f;
			useTimeMult /= 2f;
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 3f + 0.05f * Power;
		}

		public override void Apply(Item item)
		{
			//
		}
	}
}