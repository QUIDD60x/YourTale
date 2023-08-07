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
using rail;
using yourtale.Items;

namespace yourtale.Items.Accessories.Fangs
{
    public class AmethystFang : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 1;
            Item.accessory = true;
            Item.height = 1;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);
            player.AddBuff(BuffID.Calm, 2);

            if (Main.rand.NextFloat() < 0.0588372f)
            {
                Dust dust;
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Dust.NewDust(position, 30, 30, DustID.BubbleBurst_Purple, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
                dust.noGravity = true;
                dust.fadeIn = 1.4651163f;
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amethyst, 3);
            recipe.AddIngredient(ItemType<CrackedWolfFang>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}