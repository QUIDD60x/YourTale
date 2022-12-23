using Terraria;
using Terraria.ModLoader;

namespace yourtale.Prefixes
{
	public class Quidds : ModPrefix // This prefix cannot be achieved in-game.
	{
		public virtual float Power => 100f;

		public override PrefixCategory Category => PrefixCategory.Melee;

		public override float RollChance(Item item)
		{
			return 0.001f;
		}

		public override bool CanRoll(Item item)
		{
			return true;
		}

		public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
		{
			damageMult *= 10000f * Power;
			knockbackMult *= 10000f * Power;
			useTimeMult /= 10000f * Power;
			scaleMult *= 10f;
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 1000f + 0.05f * Power;
		}

		public override void Apply(Item item)
		{
			//
		}
	}
}