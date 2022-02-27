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
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed *= 0.5f;
			player.jumpSpeedBoost -= 0.6f;
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
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType("EmptyLocket"));
			recipe.AddIngredient(mod.ItemType("Cryolite"), 12);
			recipe.AddIngredient(mod.ItemType("LifeShard"), 12);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}