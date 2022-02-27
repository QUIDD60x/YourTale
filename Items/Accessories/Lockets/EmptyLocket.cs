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
			item.width = 20;
			item.height = 20;
			item.rare = ItemRarityID.White;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 2);
			recipe.AddIngredient(ItemID.IronBar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}