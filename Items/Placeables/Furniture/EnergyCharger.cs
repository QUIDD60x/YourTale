using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Tiles.Furniture;

namespace yourtale.Items.Placeables.Furniture
{
	public class EnergyCharger : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Energy Charger");
			Tooltip.SetDefault("Restores batteries in some mystical way");
		}

		public override void SetDefaults()
		{
			item.createTile = ModContent.TileType<Tiles.Furniture.EnergyCharger>(); // This sets the id of the tile that this item should place when used.

			item.width = 28; // The item texture's width
			item.height = 14; // The item texture's height

			item.useTurn = true;
			item.autoReuse = true;
			item.useStyle = 1;
			item.useTime = 10;
			item.useAnimation = 15;

			item.maxStack = 99;
			item.consumable = true;
			item.value = 150;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("LifeShard"), 5);
			recipe.AddIngredient(ItemID.IronBar, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}