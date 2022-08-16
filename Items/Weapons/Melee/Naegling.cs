using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Melee
{
    public class Naegling : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nægling");
            Tooltip.SetDefault("Weilded by an ancient warrior, it has been broken by some giant power.");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.BeamSword);
            Item.damage = 60;
            Item.useTime = 10;
            Item.useAnimation = 12;
            Item.shootSpeed = 2;
            Item.autoReuse = true;
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