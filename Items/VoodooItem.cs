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
    public class VoodooItem : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 15;
            Item.height = 15;
            Item.scale *= 1.45f;
            Item.maxStack = 999;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Red;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust dust;
            Vector2 position = Main.LocalPlayer.Center;
            dust = Main.dust[Dust.NewDust(position, 30, 30, DustID.SomethingRed, 0f, 0f, 0, new Color(255, 0, 0), 1f)];
            dust.shader = GameShaders.Armor.GetSecondaryShader(111, Main.LocalPlayer);
            dust.fadeIn = 0.69767445f;
        }
    }
}