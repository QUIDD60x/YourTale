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
    public class Dolomite : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true; //will create it as solid
            Main.tileMergeDirt[Type] = true; //will merge with dirt
            Main.tileBlockLight[Type] = false; //will create light (if true)
            Main.tileLavaDeath[Type] = false; //will be destroyed by lava (if true)

            ItemDrop = ItemType<Items.Placeables.Dolomite>(); //drop = Item.itemhere for vanilla drops

            //dustType = DustID.Platinum for vanilla, dustType = mod.dustType.Platinum for modded
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Dolomite");
            AddMapEntry(new Color(124, 124, 124), name); //or AddMapEntry(Color.Red) or any other colour in the color class

            MinPick = 35; //will set minimum pick strength
        }
        // Will let you modify the light level and colour, RGB variables are obviously RBG colours.
        /*public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.5f;
            g = 0.75f;
            b = 1f;
        }
        //will let you generate particles for it, don't quite understand this bit yet.
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }*/
    }
}