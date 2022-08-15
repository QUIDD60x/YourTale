using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using yourtale.Tiles.Furniture;

namespace yourtale.Items.Placeables.Furniture
{
	public class AncientAnvil : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ancient Anvil");
			Tooltip.SetDefault("Used by ancients to craft mystical equipment, it is too used to continue that tradition.");
		}

		public override void SetDefaults()
		{
			Item.createTile = ModContent.TileType<Tiles.Furniture.AncientAnvil>(); // This sets the id of the tile that this item should place when used.

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
			recipe.AddIngredient(Mod.Find<ModItem>("StarShard").Type, 5);
			recipe.AddIngredient(ItemID.IronBar, 7);
			recipe.AddIngredient(Mod.Find<ModItem>("AncientShard").Type, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("AncientPurpleDust").Type);
		}
	}
}