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

namespace yourtale.Items.Armor.Cryolite
{
    [AutoloadEquip(EquipType.Legs)]
    public class CryoliteLeggings : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700;

            Item.value = Item.sellPrice(silver: -1);
            Item.rare = ItemRarityID.Blue;

            Item.defense = 8;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("CryoliteBar").Type, 9);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}