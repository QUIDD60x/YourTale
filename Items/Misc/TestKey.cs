using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Misc
{
    public class TestKey : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FrozenKey);
        }
    }
}