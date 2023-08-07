using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using yourtale.Tiles.Plants;

namespace yourtale.Items.Placeables
{
	public class VoodooSeeds : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 14;

			Item.maxStack = 999;

			Item.autoReuse = true;
			Item.useTurn = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useAnimation = 15;
			Item.useTime = 10;

			Item.value = 80;
			Item.rare = ItemRarityID.Red;

			Item.consumable = true;
			Item.createTile = ModContent.TileType<VoodooBell>();
		}
	}
}