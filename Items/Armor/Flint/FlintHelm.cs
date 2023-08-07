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
    [AutoloadEquip(EquipType.Head)]
    public class FlintHelm : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 24;

            Item.value = Item.sellPrice(silver: -1);
            Item.rare = ItemRarityID.White;

            Item.defense = -1;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 6);
            recipe.AddTile(TileID.Stone);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("Flintmail").Type && legs.type == Mod.Find<ModItem>("FlintLeggings").Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Increased Mining speed.";
            player.pickSpeed -= 0.35f;
        }
    }
}