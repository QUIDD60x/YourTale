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
    [AutoloadEquip(EquipType.Legs)]
    public class FlintLeggings : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;

            Item.value = Item.sellPrice(silver: -1);
            Item.rare = ItemRarityID.White;

            Item.defense = 2;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 7);
            recipe.AddTile(TileID.Stone);
            recipe.Register();
        }
    }
}