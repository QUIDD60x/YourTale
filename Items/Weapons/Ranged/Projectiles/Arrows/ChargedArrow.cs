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
            Item.damage = 18;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 7;
            Item.height = 7;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 5;
            Item.rare = 6;
            Item.shoot = Mod.Find<ModProjectile>("ChargedArrow").Type;
            Item.ammo = AmmoID.Arrow;
            Item.rare = ItemRarityID.Green;
            Item.value = Item.buyPrice(0, 0, 1, 25);
            Item.shootSpeed = 14;

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 8);
            recipe.AddIngredient(ItemID.WoodenArrow);
            recipe.AddTile(Mod.Find<ModTile>("EnergyCharger").Type);
            recipe.Register();
        }
    }
}
