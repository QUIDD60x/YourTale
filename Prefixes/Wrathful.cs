using Terraria;
using Terraria.ModLoader;

namespace YourTale.Prefixes.Weapons
{
    public class Wrathful : ModPrefix
    {

        public override PrefixCategory Category => PrefixCategory.Melee;

        public override float RollChance(Item item)
        {
            return 1.25f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult *= 1.12f;
            knockbackMult += 0.5f;
            scaleMult *= 1.08f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 0.90f;
        }
    }
}