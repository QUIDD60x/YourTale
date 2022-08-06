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

namespace yourtale.Items.Placeables
{
    public class Dolomite : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dolomite Rock");
            Tooltip.SetDefault("A small crystal sticks out, wonder what I could do with this..."); // \n = new line
        }
        public override void SetDefaults()
        {
            Item.Size = new Vector2(12);
            Item.rare = ItemRarityID.Blue;
            Item.value = 25;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.consumable = true;
            Item.maxStack = 999;

            Item.createTile = TileType<Tiles.Ores.Dolomite>();
        }
    }
}