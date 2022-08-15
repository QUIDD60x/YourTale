using Terraria;
using Terraria.GameContent.ItemDropRules;

namespace YourTale.DropConditions
{
    // Very simple drop condition: drop during daytime
    public class YTDropCondition : IItemDropRuleCondition
    {
        public bool CanDrop(DropAttemptInfo info)
        {
            if (!info.IsInSimulation)
            {
                return Main.dayTime;
            }
            return false;
        }

        public bool CanShowItemDropInUI()
        {
            return true;
        }

        public string GetConditionDescription()
        {
            return "Drops during daytime";
        }
    }
}