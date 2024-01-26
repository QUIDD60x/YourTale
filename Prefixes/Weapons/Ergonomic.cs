using Terraria;
using Terraria.ModLoader;

namespace YourTale.Prefixes.Weapons
{
    public class Ergonomic : ModPrefix
    {

        public override PrefixCategory Category => PrefixCategory.Melee;

        public override float RollChance(Item item)
        {
            return 5.2f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            useTimeMult *= 1.8f;
            dmageMult *= 1.22f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult *= 1.08f;
        }

        public override void Apply(Item item)
        {
            //
        }
    }
}
