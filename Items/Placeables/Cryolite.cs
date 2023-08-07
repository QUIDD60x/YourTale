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
    public class Cryolite : ModItem //This is THE ITEM, NOT THE TILE. They are 2 different things, items are what you pickup and tiles are what are placed. YOU NEED BOTH to have a functioning item-to-tile combo. look for cryolite ore in the tile section.
    {
        public override void SetDefaults()
        {
            Item.Size = new Vector2(12); //vector2 gives it a 12x12 size instead of having to do item.width and item.height.
            
            Item.maxStack = 999;
           
            //these are all pretty self-explanatory.
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.value = Item.buyPrice(0, 0, 0, 75);
            Item.rare = ItemRarityID.Blue;

            Item.consumable = true; //this will make it to where when it's placed it will take one away. Veryyy important!
            //THIS is how you create it to become a tile when placed. Goto that folder section for the actual ore.
            Item.createTile = TileType<Tiles.Ores.Cryolite>();
        }
    }
}