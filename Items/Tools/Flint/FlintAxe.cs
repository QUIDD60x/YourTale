using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Tools.Flint
{
    public class FlintAxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flint Axe");
            Tooltip.SetDefault("NOT good... stronger than a hatchet at least.");
        }

        public override void SetDefaults()
        {

            Item.damage = 5; // Base Damage of the Weapon
            Item.width = 20; // Hitbox Width
            Item.height = 24; // Hitbox Height

            Item.useTime = 28; // Speed before reuse
            Item.useAnimation = 28; // Animation Speed
            Item.useStyle = 1; // 1 = Broadsword 
            Item.knockBack = 2f; // Weapon Knock base: Higher means greater "launch" distance
            Item.value = -1; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
            Item.rare = 1; // Item Tier
            Item.UseSound = SoundID.Item1; // Sound effect of item on use 
            Item.autoReuse = true; // Do you want to torture people with clicking? Set to false

            Item.axe = 5; // Axe Power - Higher Value = Better
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 4);
            recipe.AddTile(TileID.Stone);
            recipe.Register();
        }
    }
}