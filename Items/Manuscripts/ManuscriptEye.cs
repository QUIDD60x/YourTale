using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Items.Manuscripts
{
    public class ManuscriptEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diary Entry: Eye of Cthulhu");
            Tooltip.SetDefault("You can use this to make a permanent spawner for the Trapped God's Eye. \nI've watched you on your journey thus far, and knew you'd pose a threat greater than I amassed. \nGo on, fight for me."); // \n = new line
        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 25;
            item.maxStack = 999;
            item.useStyle = 1;
            item.useTime = 45;
            item.useAnimation = 45;
            item.useTurn = true;
            item.autoReuse = false;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Blue;
        }
    }
}