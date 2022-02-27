using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Weapons.Ranged.Projectiles.Arrows
{
    public class ChargedArrow : ModItem
    {
        public override void SetDefaults()
        {
            item.damage = 18;
            item.ranged = true;
            item.width = 7;
            item.height = 7;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 5;
            item.rare = 6;
            item.shoot = mod.ProjectileType("ChargedArrow");
            item.ammo = AmmoID.Arrow;
            item.rare = ItemRarityID.Green;
            item.value = Item.buyPrice(0, 0, 1, 25);
            item.shootSpeed = 14;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 8);
            recipe.AddIngredient(ItemID.WoodenArrow);
            recipe.AddTile(mod.TileType("EnergyCharger"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
