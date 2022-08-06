using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Buffs.Debuffs;

namespace yourtale.Items.Consumables.Potions
{
	public class MeltingPot : ModItem
	{
		public override void SetStaticDefaults() //this is a debug potion, but still usable.
		{
			Tooltip.SetDefault("Manual debug for the melting effect.");
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 26;
			Item.useStyle = 3;
			Item.useAnimation = 15;
			Item.useTime = 15;
			Item.useTurn = true;
			Item.UseSound = SoundID.Item3; //i have a list of sounds on my cheetsheat, or you can google them.
			Item.maxStack = 30;
			Item.consumable = true;
			Item.rare = 5; //rarities are specified on my cheetsheat. item.rare = ItemRarityID.colour also works to specify one.
			Item.value = 1000; //i think 1 = 1 copper coin?
			Item.buffType = ModContent.BuffType<Buffs.Debuffs.Melting>(); // Specify an existing buff to be applied when used.
			Item.buffTime = 5400; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}
	}
}