using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Common
{
    public class CopperPickGlobal : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.CopperPickaxe;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            tooltips.Add(new(Mod, "CopperNerf", "Nearly useless. Look for something easy to craft something new out of. Flint, perhaps?"));
        }
    }
}