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
	public class GoldLocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("imbued with unpurified life shards, it feels powerful! \nIncreased defense and overall damage.");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.rare = ItemRarityID.Blue;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 4;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.GoldBar, 4);
			recipe.AddIngredient(mod.ItemType("EmptyLocket"));
			recipe.AddIngredient(mod.ItemType("LifeShard"), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}