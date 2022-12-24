using System.Collections.Generic;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace yourtale.DamageClasses
{
    public class ExplosiveClass : DamageClass
    {
        public override StatInheritanceData GetModifierInheritance(DamageClass damageClass)
        {
                return StatInheritanceData.Full;
        }

        public override void SetDefaultStats(Player player)
        {
            player.GetArmorPenetration<ExplosiveClass>() -= 4; // Slightly prevent huge amounts of damage to heavily armored enemies, to prevent cheese.
        }
        public override bool UseStandardCritCalcs => true;

        public override bool ShowStatTooltipLine(Player player, string lineName)
        {
            if (lineName == "Speed")
                return false;

           
            return true;
        }
    }
}