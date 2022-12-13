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
    public class CrackedWolfFang : ModItem
    {
        public override void SetStaticDefaults() 
        {
            Tooltip.SetDefault("This wolf fang won't do anything by itself, but the hole could be filled...");
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
            Item.rare = ItemRarityID.Green;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bone, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}