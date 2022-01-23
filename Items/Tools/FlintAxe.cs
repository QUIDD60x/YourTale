using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Tools
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

            item.damage = 5; // Base Damage of the Weapon
            item.width = 20; // Hitbox Width
            item.height = 24; // Hitbox Height

            item.useTime = 28; // Speed before reuse
            item.useAnimation = 28; // Animation Speed
            item.useStyle = 1; // 1 = Broadsword 
            item.knockBack = 2f; // Weapon Knock base: Higher means greater "launch" distance
            item.value = -1; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
            item.rare = 1; // Item Tier
            item.UseSound = SoundID.Item1; // Sound effect of item on use 
            item.autoReuse = true; // Do you want to torture people with clicking? Set to false

            item.axe = 5; // Axe Power - Higher Value = Better
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("flint"), 4);
            recipe.AddTile(TileID.Stone);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}