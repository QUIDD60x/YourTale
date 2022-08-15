using yourtale.DamageClasses;
using yourtale.Tiles.Furniture;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Melee
{
	public class AbsoluteEnd : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			Tooltip.SetDefault("Ultimate test for the banshee class.");
		}

		public override void SetDefaults()
		{
			Item.DamageType = ModContent.GetInstance<BansheeClass>();
			Item.width = 40;
			Item.height = 40;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
			Item.useAnimation = 30;
			Item.autoReuse = true;
			Item.damage = 150;
			Item.knockBack = 4;
			Item.crit = 6;
			Item.value = Item.buyPrice(gold: 1);
			Item.rare = ItemRarityID.Quest;
			Item.UseSound = SoundID.Item110;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<flint>(20)
				.AddTile<EnergyCharger>()
				.Register();
		}
	}
}