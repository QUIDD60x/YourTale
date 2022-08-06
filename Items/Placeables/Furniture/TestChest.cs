using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Items.Placeables.Furniture
{
    public class TestChest : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Chest);
            //Item.createTile = TileType<Tiles.Furniture.TestChest>(); Item doesn't currently exist.
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}