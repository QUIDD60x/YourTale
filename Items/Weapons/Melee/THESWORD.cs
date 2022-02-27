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
			item.damage = 65000;
			item.melee = true;
			item.width = 1000;
			item.height = 1000;
			item.useTime = 1;
			item.useAnimation = 1;
			item.useStyle = 3;
			item.knockBack = 0;
			item.value = -1;
			item.rare = 13;
			item.autoReuse = true;
			item.UseSound = (mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Item/Explosion1")); //custom sounds are a pain, i'll probably do a youtube video on them soon.
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 1000);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}