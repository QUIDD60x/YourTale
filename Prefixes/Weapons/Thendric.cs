using Terraria;
using Terraria.ModLoader;

namespace yourtale.Prefixes.Weapons
{
	public class Thendric : ModPrefix // This isn't really achievable in-game, but it's a learning experience?
	{

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
			damageMult *= 1.3f;
			knockbackMult /= 2;
			useTimeMult -= 5;
			shootSpeedMult -= 5;
		}

		public override void ModifyValue(ref float valueMult)
		{
			valueMult *= 30f;
		}

		public override void Apply(Item item)
		{
			item.shoot = Mod.Find<ModProjectile>("LahatCherebProj").Type;
			item.shootSpeed = 10;
		}
	}
}