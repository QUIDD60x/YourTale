﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Prefixes.Weapons
{
    // This class serves as an example for declaring item 'prefixes', or 'modifiers' in other words.
    public class HighQuality : ModPrefix // This used to be an all-weapons modifier, now it's for ranged weapons only.
    {
        // We declare a custom *virtual* property here, so that another type, ExampleDerivedPrefix, could override it and change the effective power for itself.

        // Change your category this way, defaults to PrefixCategory.Custom. Affects which items can get this prefix.
        public override PrefixCategory Category => PrefixCategory.Ranged;

        // See documentation for vanilla weights and more information.
        // In case of multiple prefixes with similar functions this can be used with a switch/case to provide different chances for different prefixes
        // Note: a weight of 0f might still be rolled. See CanRoll to exclude prefixes.
        // Note: if you use PrefixCategory.Custom, actually use ModItem.ChoosePrefix instead.
        public override float RollChance(Item item)
        {
            return 1.45f;
        }

        // Determines if it can roll at all.
        // Use this to control if a prefix can be rolled or not.
        public override bool CanRoll(Item item)
        {
            return true;
        }

        // Use this function to modify these stats for items which have this prefix:
        // Damage Multiplier, Knockback Multiplier, Use Time Multiplier, Scale Multiplier (Size), Shoot Speed Multiplier, Mana Multiplier (Mana cost), Crit Bonus.
        public override void SetStats(ref float damageMult, ref float knockbackMult, ref float useTimeMult, ref float scaleMult, ref float shootSpeedMult, ref float manaMult, ref int critBonus)
        {
            damageMult *= 1.35f;
            knockbackMult *= 0.85f;
        }

        // Modify the cost of items with this modifier with this function.
        public override void ModifyValue(ref float valueMult)
        {
            valueMult += 0.4f;
        }

        // This is used to modify most other stats of items which have this modifier.
        public override void Apply(Item item)
        {
            item.autoReuse = true;
        }
    }
}