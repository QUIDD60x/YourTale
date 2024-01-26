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
using YourTale.Tiles.Ores;

namespace YourTale.Items.Placeables
{
    public class Athium : ModItem
    {
        public override void SetDefaults()
        {
            Item.Size = new Vector2(12);
            
            Item.maxStack = 999;
           
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.value = Item.buyPrice(0, 0, 0, 14);
            Item.rare = ItemRarityID.Blue;

            Item.consumable = true;

            Item.createTile = TileType<Tiles.Ores.Athium>();
        }
    }
}