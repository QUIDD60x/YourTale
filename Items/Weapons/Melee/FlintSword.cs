using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Melee
{
    public class FlintSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("THESWORD"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("A Flint sword with medium range yet fast speed.");
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = 1;
            item.knockBack = 3;
            item.value = 2500;
            item.rare = 1;
            item.UseSound = SoundID.Item1;
            item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("flint"), 4);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddIngredient(ItemID.StoneBlock, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}