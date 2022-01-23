using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Tiles.Ores
{
    public class Cryolite : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true; 
            Main.tileMergeDirt[Type] = true; 
            Main.tileBlockLight[Type] = true; 
            Main.tileLavaDeath[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileShine[Type] = 80;

            drop = ItemType<Items.Placeables.Cryolite>(); //drop = Item.itemhere for vanilla drops

            dustType = 84; //dustType = DustID.Platinum for vanilla, dustType = mod.dustType.Platinum for modded
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Cryolite");
            AddMapEntry(new Color(129, 159, 242), name); //or AddMapEntry(Color.Red) or any other colour in the color class
            soundType = SoundID.Tink;
            soundStyle = 1;
            minPick = 35; //will set minimum pick strength
        }
        // Will let you modify the light level and colour, RGB variables are obviously RBG colours.
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 129f;
            g = 159f;
            b = 242f;
        }
        //will let you generate particles for it, don't quite understand this bit yet.
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}