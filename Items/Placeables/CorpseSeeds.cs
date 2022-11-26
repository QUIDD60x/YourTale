using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using yourtale.Tiles.Plants;

namespace yourtale.Items.Placeables
{
	public class CorpseSeeds : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Red Spider Lily Seeds");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}

		public override void SetDefaults()
		{
			Item.autoReuse = true;
			Item.useTurn = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.maxStack = 999;
			Item.consumable = true;
			Item.placeStyle = 0;
			Item.width = 12;
			Item.height = 14;
			Item.value = 80;
			Item.createTile = ModContent.TileType<CorpseFlower>();
		}
	}
}