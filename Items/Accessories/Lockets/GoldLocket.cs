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
		public override void SetDefaults()
		{

			Item.width = 40;
			Item.height = 40;

			Item.rare = ItemRarityID.Blue;

			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.statDefense += 6;
			player.GetDamage(DamageClass.Generic) *= 1.215f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 4);
			recipe.AddIngredient(Mod.Find<ModItem>("EmptyLocket").Type);
			recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}