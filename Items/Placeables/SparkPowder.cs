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
using yourtale.Tiles.Ores;

namespace yourtale.Items.Placeables
{
    public class SparkPowder : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spark powder");
            Tooltip.SetDefault("A primitive ignition agent.");
        }
        public override void SetDefaults()
        {
            Item.height = 22;
            Item.width = 16;
            
            Item.maxStack = 999;
           
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.value = Item.buyPrice(0, 0, 1, 15);
            Item.rare = ItemRarityID.Green;
        }
    }
}