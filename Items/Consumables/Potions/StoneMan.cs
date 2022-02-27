using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Buffs;

namespace yourtale.Items.Consumables.Potions
{
	public class StoneMan : ModItem
	{
		public override void SetStaticDefaults() //this is a debug potion, but still usable.
		{
			DisplayName.SetDefault("Bulwark Potion");
			Tooltip.SetDefault("You're stuck between a rock and a... nother rock. \nFreezes you in place for 10 seconds, but heavily increases life regen and defense.");
		}

		public override void SetDefaults()
		{
			item.width = 8;
			item.height = 26;
			item.useStyle = 3;
			item.useAnimation = 15;
			item.useTime = 15;
			item.useTurn = true;
			item.UseSound = SoundID.Item3; //i have a list of sounds on my cheetsheat, or you can google them.
			item.maxStack = 30;
			item.consumable = true;
			item.rare = 5; //rarities are specified on my cheetsheat. item.rare = ItemRarityID.colour also works to specify one.
			item.value = 1000; //i think 1 = 1 copper coin?
			item.buffType = ModContent.BuffType<Buffs.StoneMan>(); // Specify an existing buff to be applied when used.
			item.buffTime = 600; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(mod.ItemType("Dolomite"), 2);
			recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}