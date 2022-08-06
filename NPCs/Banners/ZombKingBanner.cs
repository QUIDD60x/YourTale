using yourtale.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.NPCs.Banners
{
    public class PrinceSlimeBanner : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("ZombKing Banner");
        }
        // The tooltip for this item is automatically assigned from .lang files
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.buyPrice(0, 0, 10, 0);
            Item.createTile = ModContent.TileType<MonsterBanner>();
            Item.placeStyle = 1;        //Place style means which frame(Horizontally, starting from 0) of the tile should be placed
        }
    }
}