using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace yourtale
{
    public class ToolTweaks : GlobalItem
    { //this allows you to manipulate the defaults for items. This is a little more advanced, just about on the brink of my knowledge so i don't have a tutorial yet, although expect a video on it eventually.

        public override void SetDefaults(Item item)
        {
            switch (item.type)
            {
                case ItemID.CopperAxe:
                    if (GetInstance<ServerConfig>().ToolTweaks)
                    {
                        item.axe = -1;
                        item.useTime = 100;
                    }
                    return;
                case ItemID.CopperPickaxe:
                        if (GetInstance<ServerConfig>().ToolTweaks)
                        {
                            item.pick = 6;
                            item.useTime = 20;
                            item.useAnimation = 20;
                        }
                    return;
                case ItemID.CopperShortsword:
                    if (GetInstance<ServerConfig>().ToolTweaks)
                    {
                        item.damage = 1;
                    }
                    return;
            }
        }
    }
} 