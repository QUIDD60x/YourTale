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

namespace yourtale.Items.Armor.Flint
{
    [AutoloadEquip(EquipType.Body)]
    public class Flintmail : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("It holds together, somehow...");
        }

        public override void SetDefaults()
        {
            item.width = 22;
            item.height = 24;
            item.value = Item.sellPrice(silver: -1);
            item.rare = ItemRarityID.White;
            item.defense = 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("flint"), 9);
            recipe.AddTile(TileID.Stone);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}