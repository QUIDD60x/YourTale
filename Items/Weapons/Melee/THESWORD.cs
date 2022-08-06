using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Prefixes;

namespace yourtale.Items.Weapons.Melee
{
	public class THESWORD : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("THESWORD"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Achieve everything.");
		}

		public override void SetDefaults() 
		{
			Item.damage = 65000;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			Item.width = 1000;
			Item.height = 1000;
			Item.useTime = 1;
			Item.useAnimation = 1;
			Item.useStyle = 3;
			Item.knockBack = 0;
			Item.value = -1;
			Item.rare = 13;
			Item.autoReuse = true;
			Item.UseSound = SoundID.Item107;
		}

		public override void AddRecipes() 
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 1000);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
    }
}