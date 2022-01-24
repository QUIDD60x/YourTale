using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Buffs.Debuffs;

namespace yourtale.Items.Potions
{
	public class MeltingPot : ModItem
	{
		public override void SetStaticDefaults()
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
			item.UseSound = SoundID.Item3;
			item.maxStack = 30;
			item.consumable = true;
			item.rare = 5;
			item.value = 1000;
			item.buffType = ModContent.BuffType<Buffs.Debuffs.Melting>(); // Specify an existing buff to be applied when used.
			item.buffTime = 5400; // The amount of time the buff declared in Item.buffType will last in ticks. 5400 / 60 is 90, so this buff will last 90 seconds.
		}
	}
}