using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Accessories.Lockets
{
	public class CryoliteLocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Gives you extra defense, and grants an ice shield.");
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
			player.moveSpeed *= 0.992f;
			player.jumpSpeedBoost -= 0.4f;
			player.statLifeMax2 += 20;
			player.statDefense += 4;
			player.endurance += 0.25f;
			player.AddBuff(BuffID.IceBarrier, 2);
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(Mod.Find<ModItem>("EmptyLocket").Type);
			recipe.AddIngredient(Mod.Find<ModItem>("Cryolite").Type, 12);
			recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}