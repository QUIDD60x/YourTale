using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Tiles.Furniture;

namespace yourtale.Items.Placeables.Furniture
{
	public class EnergyCharger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Restorer");
			Tooltip.SetDefault("It has the capability to restore ancient materials, using artifacts.");
		}

		public override void SetDefaults()
		{
			Item.createTile = ModContent.TileType<Tiles.Furniture.EnergyCharger>(); // This sets the id of the tile that this item should place when used.

			Item.width = 28; // The item texture's width
			Item.height = 14; // The item texture's height

			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
			Item.useAnimation = 15;

			Item.maxStack = 99;
			Item.consumable = true;
			Item.value = 150;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 5);
			recipe.AddIngredient(ItemID.IronBar, 7);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}