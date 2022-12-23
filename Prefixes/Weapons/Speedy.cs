using Terraria;
using Terraria.ModLoader;

namespace YourTale.Prefixes.Weapons
{
    public class Speedy : ModPrefix
    {

        public override PrefixCategory Category => PrefixCategory.Ranged;

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
            shootSpeedMult += 5.5f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult += 25.35f;
        }

        public override void Apply(Item item)
        {
            //
        }
    }
}