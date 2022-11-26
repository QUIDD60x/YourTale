using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Graphics.Shaders;

namespace yourtale.Items
{
    public class CorpseItem : ModItem //You should always capitalise the first letter (grammar is important). I'll leave this though because it's funny.
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Red Spider Lily");
            Tooltip.SetDefault("A flower to represent death and what could come after.");
        }

        public override void SetDefaults()
        {
            Item.width = 1;
            Item.height = 1;
            Item.scale *= 1.45f;
            Item.maxStack = 999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.White;
            Item.createTile = TileType<Tiles.Ores.FlintDeposit>();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust dust;
            Vector2 position = Main.LocalPlayer.Center;
            dust = Main.dust[Dust.NewDust(position, 30, 30, DustID.CopperCoin, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
            dust.shader = GameShaders.Armor.GetSecondaryShader(111, Main.LocalPlayer);
            dust.fadeIn = 0.69767445f;
        }
    }
}