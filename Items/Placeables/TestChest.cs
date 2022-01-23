using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Items.Placeables
{
    public class TestChest : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Chest);
            item.createTile = TileType<Tiles.Furniture.TestChest>();
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}