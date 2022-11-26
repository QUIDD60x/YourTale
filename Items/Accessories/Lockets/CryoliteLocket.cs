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
	public class CryoliteLocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Gives you extra defense, and inflicts frostburn.");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.accessory = true;
			Item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed *= 0.9f;
			player.jumpSpeedBoost -= 0.4f;
			player.statLifeMax2 += 20;
			player.statDefense += 4;
			player.endurance += 0.25f;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			// Inflict the OnFire debuff for 1 second onto any NPC/Monster that this hits.
			// 60 frames = 1 second
			target.AddBuff(BuffID.Frostburn, 60);
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