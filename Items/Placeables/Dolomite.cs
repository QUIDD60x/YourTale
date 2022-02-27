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
            item.Size = new Vector2(12);
            item.rare = ItemRarityID.Blue;
            item.value = 25;

            item.autoReuse = true;
            item.useTurn = true;
            item.useTime = 10;
            item.useAnimation = 12;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.consumable = true;
            item.maxStack = 999;

            item.createTile = TileType<Tiles.Ores.Dolomite>();
        }
    }
}