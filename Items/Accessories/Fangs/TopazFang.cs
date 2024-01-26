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
using YourTale.Items;

namespace YourTale.Items.Accessories.Fangs
{
    public class TopazFang : ModItem
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
            player.pickSpeed /= 2;
            player.AddBuff(BuffID.Spelunker, 2);

            if (Main.rand.NextFloat() < 0.3139535f)
            {
                Dust dust; 
                Vector2 position = Main.LocalPlayer.Center; 
                dust = Terraria.Dust.NewDustDirect(position, 4, 4, 179, 0f, 0f, 112, new Color(222,255,0), 1.1046512f); 
                dust.noGravity = true; 
                dust.fadeIn = 1.6744187f; 
            }
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Topaz, 3);
            recipe.AddIngredient(ItemType<CrackedWolfFang>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}