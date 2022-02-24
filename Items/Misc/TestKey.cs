using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Misc
{
    public class TestKey : ModItem
    { //this is a test item, don't expect it to work. It's for a chest generation attempt, might take me a while tho.
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.FrozenKey);
        }
    }
}