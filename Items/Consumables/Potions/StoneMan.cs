using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
			Item.width = 8;
			Item.height = 26;
			Item.useStyle = ItemUseStyleID.DrinkLiquid;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3; // I have a list of sounds on my cheetsheat, or you can google them.
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = ItemRarityID.Pink; // Rarities are specified on my cheetsheat. item.rare = ItemRarityID.colour also works to specify one.
			Item.value = 1000; // 1 = 1 copper coin. 
			Item.buffType = ModContent.BuffType<YourTale.Buffs.Good.StoneMan>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 600; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.BottledWater, 1);
			recipe.AddIngredient(ItemID.StoneBlock, 15);
			recipe.AddIngredient(ItemID.HealingPotion, 2);
			recipe.AddIngredient(ItemID.Blinkroot);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}