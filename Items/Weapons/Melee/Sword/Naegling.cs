using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Rarities;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class Naegling : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BeamSword);
            Item.crit = 70;
            Item.damage = 60;
            Item.useTime = 10;
            Item.useAnimation = 12;
            Item.shootSpeed = 2;
            Item.autoReuse = true;
            Item.rare = ModContent.RarityType<AncientPurple>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard").Type, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}