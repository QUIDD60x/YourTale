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
			item.width = 20;
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
			item.buffType = ModContent.BuffType<Buffs.Debuffs.Melting>(); // Specify an existing buff to be applied when used.
			item.buffTime = 5400; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}
	}
}