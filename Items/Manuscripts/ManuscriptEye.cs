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

namespace yourtale.Items.Manuscripts
{
    public class ManuscriptEye : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 25;

            Item.maxStack = 999;

            Item.useStyle = 1;
            Item.useTime = 45;
            Item.useAnimation = 45;
            Item.useTurn = true;
            Item.autoReuse = false;
            Item.UseSound = SoundID.Item1;

            Item.value = 2007;
            Item.rare = ItemRarityID.Blue;
        }
    }
}