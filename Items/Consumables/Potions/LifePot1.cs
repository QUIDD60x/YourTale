using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Consumables.Potions
{
	public class LifePot1 : ModItem
	{

		public int timer = 60;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cracked Boost Stone");
			Tooltip.SetDefault("**CURRENTLY NOT WORKING (sorry)**Heals the user for 10 health after 10 seconds of use.\nCould this be improved?");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void ModifyTooltips(List<TooltipLine> tooltips)
		{
			TooltipLine tooltip = new TooltipLine(Mod, "Yourtale: HealthBoost", $"You have {timer / 60f:N1} seconds left!") { OverrideColor = Color.Red };
			tooltips.Add(tooltip);
		}

		public override void UpdateInventory(Player player)
		{
			if (--timer <= 0)
			{
				player.statLife += 10;
				if (player.statLife > player.statLifeMax2) player.statLife = player.statLifeMax2;
				player.HealEffect(10);
				Item.TurnToAir();
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.ManaCrystal, 1);
			recipe.AddIngredient<StarShard>(10);
			(recipe.createItem.ModItem as LifePot1).timer = 60;
			recipe.Register();
		}
	}
}