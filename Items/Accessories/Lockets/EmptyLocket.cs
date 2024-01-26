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
		public override void SetDefaults()
		{
			// Item properties
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			// Item value
			Item.value = (0, 0, 12, 10);
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
