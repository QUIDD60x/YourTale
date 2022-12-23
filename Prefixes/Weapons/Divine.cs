using IL.Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace YourTale.Prefixes.Weapons
{
    public class Divine : ModPrefix
    {
        public override PrefixCategory Category => PrefixCategory.Magic;

        public override float RollChance(Item item)
        {
            return 1.21f;
        }

        public override bool CanRoll(Item item)
        {
            return true;
        }

        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult *= 1.65f;
            knockbackMult *= 1.65f;
            manaMult /= 1.25f;
        }

        public override void ModifyValue(ref float valueMult)
        {
            valueMult /= 2f;
        }

        public override void Apply(Item item)
        {
            item.autoReuse = true;
        }
    }
}