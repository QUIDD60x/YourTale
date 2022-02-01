using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Tools.Flint
{
    public class FlintHatchet : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flint Hatchet");
            Tooltip.SetDefault("NOT good... swings faster than an axe, but weaker...");
        }

        public override void SetDefaults()
        {

            item.damage = 3; // Base Damage of the Weapon
            item.width = 18; // Hitbox Width
            item.height = 20; // Hitbox Height

            item.useTime = 18; // Speed before reuse
            item.useAnimation = 18; // Animation Speed
            item.useStyle = 1; // 1 = Broadsword 
            item.knockBack = 1f; // Weapon Knock base: Higher means greater "launch" distance
            item.value = -1; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
            item.rare = 1; // Item Tier
            item.UseSound = SoundID.Item1; // Sound effect of item on use 
            item.autoReuse = true; // Do you want to torture people with clicking? Set to false

            item.axe = 5; // Axe Power - Higher Value = Better
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("flint"), 3);
            recipe.AddTile(TileID.Stone);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}