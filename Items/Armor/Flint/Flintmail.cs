using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace YourTale.Items.Armor.Flint
{
    [AutoloadEquip(EquipType.Body)]
    public class Flintmail : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;

            Item.value = Item.sellPrice(silver: -1);
            Item.rare = ItemRarityID.White;

            Item.defense = 3;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 9);
            recipe.AddTile(TileID.Stone);
            recipe.Register();
        }
    }
}