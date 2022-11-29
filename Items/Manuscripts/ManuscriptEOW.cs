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
    public class ManuscriptEOW : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diary Entry: Eater of Worlds");
            Tooltip.SetDefault("You can use this to make a permanent spawner for the Corrupted Pet. \nIt has no brain. Just mindless hunger, compulsion to spread the dark energy of its home. It didn't need a brain to claim the lives of many good adventurers.\nI doubt killing it had any stop to the corruption."); // \n = new line
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

            Item.value = 2007;
            Item.rare = ItemRarityID.Green;
        }
    }
}