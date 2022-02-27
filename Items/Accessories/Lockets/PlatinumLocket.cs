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
	public class PlatinumLocket : ModItem
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
			player.meleeDamage += 0.5f;
			player.thrownDamage += 0.5f;
			player.rangedDamage += 0.5f;
			player.magicDamage += 0.5f;
			player.minionDamage += 0.5f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.PlatinumBar, 4);
			recipe.AddIngredient(mod.ItemType("EmptyLocket"));
			recipe.AddIngredient(mod.ItemType("LifeShard"), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}