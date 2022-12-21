using Terraria;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;

namespace YourTale.DropConditions
{
	public class YTSoulCondition : IItemDropRuleCondition
	{
		public bool CanDrop(DropAttemptInfo info)
		{
			if (!info.IsInSimulation)
			{
				// Can drop if it's not hardmode, and not a critter or an irrelevant enemy

				NPC npc = info.npc;
				if (npc.boss || NPCID.Sets.CannotDropSouls[npc.type])
				{
					return false;
				}

				if (!Main.hardMode || npc.lifeMax <= 1 || npc.friendly || npc.value < 1f)
				{
					return false;
				}
			}
			return false;
		}

		public bool CanShowItemDropInUI()
		{
			return true;
		}

		public string GetConditionDescription()
		{
			return "Drops asdfasdf";
		}
	}
}