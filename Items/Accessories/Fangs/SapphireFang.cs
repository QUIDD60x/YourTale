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
    public class SapphireFang : ModItem
    {
        public override void SetDefaults()
        {
            // Item properties
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
            // Item value
            Item.value = (0, 0, 20, 50);
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);
            player.maxRunSpeed += 5 - player.maxRunSpeed;
            player.extraFall += 10;

            Dust dust; 
            Vector2 position = Main.LocalPlayer.Center; 
            dust = Terraria.Dust.NewDustDirect(position, 30, 30, 179, 0f, 0f, 112, new Color(0,255,244), 1f); 
            dust.noGravity = true; 
            dust.fadeIn = 1.255814f;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Sapphire, 3);
            recipe.AddIngredient(ItemType<CrackedWolfFang>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
