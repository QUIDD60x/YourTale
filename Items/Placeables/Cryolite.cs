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
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryolite sample");
            Tooltip.SetDefault("irratates my skin! feels like ice..."); // \n = new line
        }
        public override void SetDefaults()
        {
            item.Size = new Vector2(12); //vector2 gives it a 12x12 size instead of having to do item.width and item.height.
            item.rare = ItemRarityID.Blue;
            item.value = Item.sellPrice(silver: 2);
            //these are all pretty self-explanatory.
            item.autoReuse = true;
            item.useTurn = true;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useStyle = ItemUseStyleID.SwingThrow;

            item.consumable = true; //this will make it to where when it's placed it will take one away. Veryyy important!
            item.maxStack = 999;
            //THIS is how you create it to become a tile when placed. Goto that folder section for the actual ore.
            item.createTile = TileType<Tiles.Ores.Cryolite>();
        }
    }
}