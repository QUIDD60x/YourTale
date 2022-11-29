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
	public class AnimulaLocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increased move speed, jump power, and more health.");
		}

		public override void SetDefaults()
		{	

			Item.width = 40;
			Item.height = 40;

			Item.rare = ItemRarityID.Green;

			Item.accessory = true;
			
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 1.5f;
			player.jumpSpeedBoost += 1.5f;
			player.extraFall += 7;
			player.statLifeMax2 += 20;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.LifeCrystal, 1);
			recipe.AddIngredient(ItemID.ManaCrystal);
			recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}