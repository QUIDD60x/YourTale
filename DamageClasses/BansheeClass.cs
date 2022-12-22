using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace yourtale.DamageClasses
{
    public class BansheeClass : DamageClass
    {
        // This is an example damage class designed to demonstrate all the current functionality of the feature and explain how to create one of your own, should you need one.
        // For information about how to apply stat bonuses to specific damage classes, please instead refer to ExampleMod/Content/Items/Accessories/ExampleStatBonusAccessory.
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
            // This method lets you make your damage class benefit from other classes' stat bonuses by default, as well as universal stat bonuses.
            // To briefly summarize the two nonstandard damage class names used by DamageClass:
            // Default is, you guessed it, the default damage class. It doesn't scale off of any class-specific stat bonuses or universal stat bonuses.
            // There are a number of items and projectiles that use this, such as thrown waters and the Bone Glove's bones.
            // Generic, on the other hand, scales off of all universal stat bonuses and nothing else; it's the base damage class upon which all others that aren't Default are built.
            if (damageClass == DamageClass.Melee) // This can be shortened to just the class name (as show below) but I'm keeping it as-is so you know.
                

            return new StatInheritanceData(
                damageInheritance: 2.25f,
                critChanceInheritance: 0.5f,
                attackSpeedInheritance: 2.2f,
                armorPenInheritance: 1.15f,
                knockbackInheritance: -1f
            );
            if (damageClass == Ranged)


                return new StatInheritanceData(
                    damageInheritance: 0f,
                    critChanceInheritance: 0f,
                    attackSpeedInheritance: 0f,
                    armorPenInheritance: 0f,
                    knockbackInheritance: 0f
                );
            if (damageClass == Throwing)


                return new StatInheritanceData( // These last two are an 
                    damageInheritance: 0f, critChanceInheritance: 0f,
                    attackSpeedInheritance: 0f, armorPenInheritance: 0f, knockbackInheritance: 0f
                );
            if (damageClass == Magic)
                return StatInheritanceData.Full;

            return new StatInheritanceData(
                damageInheritance: 0f, critChanceInheritance: 0f,
                attackSpeedInheritance: 0f, armorPenInheritance: 0f, knockbackInheritance: 0f
            );
            // CAUTION: There is no hardcap on what you can set these to. Please be aware and advised that whatever you set them to may have unintended consequences,
            // and that we are NOT responsible for any temporary or permanent damage caused to you, your character, or your world as a result of your morbid curiosity.
            // To refer to a non-vanilla damage class for these sorts of things, use "ModContent.GetInstance<TargetDamageClassHere>()" instead of "DamageClass.XYZ".
        }

        public override bool GetEffectInheritance(DamageClass damageClass)
        {
            // This method allows you to make your damage class benefit from and be able to activate other classes' effects (e.g. Spectre bolts, Magma Stone) based on what returns true.
            // Note that unlike our stat inheritance methods up above, you do not need to account for universal bonuses in this method.
            // For this example, we'll make our class able to activate melee-specifically effects.
            if (damageClass == Melee)
                return true;

            return false;
        }

        public override void SetDefaultStats(Player player)
        {
            // This method lets you set default statistical modifiers for your class.
            // Here, we'll make our damage class have more critical strike chance and armor penetration than normal.
            player.GetCritChance<BansheeClass>() += 4;
            player.GetArmorPenetration<BansheeClass>() += 10;
            // These sorts of modifiers also exist for damage (GetDamage), knockback (GetKnockback), and attack speed (GetAttackSpeed).
            // You'll see these used all around in referencce to vanilla classes and our class here. Familiarize yourself with them.
        }

        // This property lets you decide whether or not your damage class can use standard critical strike calculations.
        // Note that setting it to false will also prevent the critical strike chance tooltip line from being shown.
        // This prevention will overrule anything set by ShowStatTooltipLine, so be careful!
        public override bool UseStandardCritCalcs => true;

        public override bool ShowStatTooltipLine(Player player, string lineName)
        {
            // This method lets you prevent certain common statistical tooltip lines from appearing on items associated with this DamageClass.
            // The four line names you can use are "Damage", "CritChance", "Speed", and "Knockback". All four cases default to true, and thus will be shown. For example...
            /*if (lineName == "Kockback")
                return false;

            */return true;
            // PLEASE BE AWARE that this hook will NOT be here forever; only until an upcoming revamp to tooltips as a whole comes around.
            // Once this happens, a better, more versatile explanation of how to pull this off will be showcased, and this hook will be removed.
        }
    }
}