using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items
{
    public class ytGlobalItem : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            ItemID.Sets.ExtractinatorMode[ItemID.Cloud] = ItemID.Cloud;
        }

        public override void ExtractinatorUse(int extractType, ref int resultType, ref int resultStack)
        {
            Main.NewText(extractType);
            if (extractType == ItemID.DirtBlock)
            {
                resultType = ItemID.DirtBlock;
                resultStack = 1000;
            }
        }
    }
}