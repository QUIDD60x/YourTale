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
    public class ManuscriptSlime : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diary Entry: Slime King");
            Tooltip.SetDefault("You can use this to make a permanent spawner for the fool's king. \nThey say slimes are thoughtless; only blobs of goo, mindlessly wandering the world. \nThose are the ones who fall victim to this kings tyranny."); // \n = new line
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
            Item.rare = ItemRarityID.Blue;
        }
    }
}