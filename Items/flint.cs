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

namespace yourtale.Items
{
    public class flint : ModItem //You should always capitalise the first letter (grammar is important). I'll leave this though because it's funny, and the first thing I'd ever made in Tmodloader.
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Flint Shard");
            Tooltip.SetDefault("I can probably make tools with this if I can find some stone nearby..."); // \n = new line
        } 

        public override void SetDefaults()
        {
            Item.width = 1;
            Item.height = 1;
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

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.StoneBlock);
            recipe.AddIngredient(ModContent.ItemType<Items.flint>(), 1);
            recipe.Register();
        }
    }
}