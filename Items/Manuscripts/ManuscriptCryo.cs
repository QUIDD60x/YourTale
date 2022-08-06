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
            Item.width = 25;
            Item.height = 25;
            Item.maxStack = 999;
            Item.useStyle = 1;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useTurn = true;
            Item.autoReuse = false;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Green;
        }
    }
}