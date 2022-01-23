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
            item.rare = ItemRarityID.LightRed;
            item.value = 1000;
            item.shootSpeed = 10;

        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Glass, 999); //currently uncraftable, will implement recipe later.
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this); //can add recipe.SetResult(this, number here) for making multiple
            recipe.AddRecipe();
        }
    }
}
