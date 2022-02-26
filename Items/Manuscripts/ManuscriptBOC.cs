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
    public class ManuscriptBOC : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Diary Entry: Brain of Cthulhu");
            Tooltip.SetDefault("You can use this to make a permanent spawner for the Almagamated Mind. \nThis crimson hell is truly a wretched place; A living, breathing beating land, with every creatures sole purpose to just spread it's disease.\nIt is crucial that you killed this beast, although I doubt it helped at all."); // \n = new line
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