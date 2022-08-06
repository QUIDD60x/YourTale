﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Tiles.Furniture
{
    public class EnergyCharger : ModTile
    {

        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);

            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);

            ModTranslation name = CreateMapEntryName();
            AddMapEntry(new Color(191, 142, 111), name);

            disableSmartCursor/* tModPorter Note: Removed. Use TileID.Sets.DisableSmartCursor instead */ = true;

            AdjTiles = new int[] { TileID.WorkBenches };
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Main.NewText(Lang.GetMapObjectName(TileID.WorkBenches));
            int style = frameX / 36;
            int type = ItemType<Items.Placeables.Furniture.EnergyCharger>();
            switch (style)
            {
                case 1:
                    type = ItemType<Items.Placeables.Furniture.EnergyCharger>();
                    break;
                default:
                    break;
            }
            Item.NewItem(i * 16, j * 16, 32, 16, type);
        }
    }
}