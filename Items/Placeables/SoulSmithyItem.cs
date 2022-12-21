using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Tiles;

namespace yourtale.Items.Placeables
{
    internal class SoulSmithyItem : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul Smithy");

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Hellforge);
            Item.createTile = ModContent.TileType<SoulSmithy>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Hellforge, 1);
            recipe.AddIngredient(ModContent.ItemType<SpiritShard1>(), 10);
        }
    }
}
