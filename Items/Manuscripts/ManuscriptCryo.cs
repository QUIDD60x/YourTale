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
    public class ManuscriptCryo : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diary Entry: Cryolisis");
            Tooltip.SetDefault("You can use this to make a permanent spawner for the Frost Crystal. \nand as I watch the ice melt, I am the only one left. I cannot melt. I stay, guard, become the stronghold for those who cannot egress, those who cannot hope to fight the calamity that is..."); // \n = new line
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
            item.rare = ItemRarityID.Green;
        }
    }
}