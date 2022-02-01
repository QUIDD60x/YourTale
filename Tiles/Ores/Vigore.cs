using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Tiles.Ores
{
    public class Vigore : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true; 
            Main.tileMergeDirt[Type] = true; 
            Main.tileBlockLight[Type] = true; 
            Main.tileLavaDeath[Type] = true;
            Main.tileShine[Type] = 95;

            drop = ItemType<Items.LifeShard>(); //drop = Item.itemhere for vanilla drops

            
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Vigore");
            AddMapEntry(new Color(13, 195, 4), name); 
            minPick = 65; 
        }
        // Will let you modify the light level and colour, RGB variables are obviously RBG colours.
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 13f;
            g = 195f;
            b = 4f;
        }
        //will let you generate particles for it, don't quite understand this bit yet.
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}