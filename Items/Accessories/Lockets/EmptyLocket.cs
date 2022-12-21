using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Accessories.Lockets
{
	public class EmptyLocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("You could put something in the middle... \nNo status effects.");
		}

		public override void SetDefaults()
		{

			Item.width = 20;
			Item.height = 20;

			Item.rare = ItemRarityID.White;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 2);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

			recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.PlatinumBar, 2);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}