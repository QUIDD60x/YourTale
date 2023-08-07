﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using yourtale.Items.Placeables;
using yourtale.Tiles.Furniture;

namespace yourtale.Items
{
    public class GunParts : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.maxStack = 999;
            Item.value = 945;
            Item.rare = ItemRarityID.Orange;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LeadBar, 7);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}