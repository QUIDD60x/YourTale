using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Common
{
    public class HeavyWorkBenchGlobal : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.HeavyWorkBench;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new(Mod, "asldkmasklda", "Used for specialized explosive crafting."));
        }
    }
}