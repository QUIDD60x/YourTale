using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace YourTale
{
    public class CustomRecipes : ModSystem
    {
        public override void AddRecipeGroups()
        {
            RecipeGroup group = new RecipeGroup(() => $"{Language.GetTextValue("LegacyMisc.37")} {Lang.GetItemNameValue(ItemID.GoldBar)}", ItemID.PlatinumBar, ItemID.GoldBar);
            RecipeGroup.RegisterGroup(nameof(ItemID.GoldBar), group);
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<Items.Weapons.Melee.Claws.EmptyClaw>());
            recipe.AddIngredient(ItemID.Leather, 3);
            recipe.AddRecipeGroup(nameof(ItemID.GoldBar), 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}