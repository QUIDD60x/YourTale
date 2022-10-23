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
using yourtale.Dusts;

namespace yourtale.Items.Shells
{
    public class HelmMold : ModItem 
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Armor Mold-Helmet");
            Tooltip.SetDefault("Used as a base for powerful equipment.");
        }

        public override void SetDefaults()
        {
            Item.width = 1;
            Item.height = 1;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<AncientPurpleDust>());
        }
    }
}