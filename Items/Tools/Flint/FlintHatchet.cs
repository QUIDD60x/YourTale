using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace YourTale.Items.Tools.Flint
{
    public class FlintHatchet : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 3; // Base Damage of the Weapon
            Item.width = 18; // Hitbox Width
            Item.height = 20; // Hitbox Height

            Item.useTime = 18; // Speed before reuse
            Item.useAnimation = 18; // Animation Speed
            Item.useStyle = 1; // 1 = Broadsword 
            Item.knockBack = 1f; // Weapon Knock base: Higher means greater "launch" distance
            Item.value = -1; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
            Item.rare = 1; // Item Tier
            Item.UseSound = SoundID.Item1; // Sound effect of item on use 
            Item.autoReuse = true; // Do you want to torture people with clicking? Set to false

            Item.axe = 5; // Axe Power - Higher Value = Better
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 3);
            recipe.AddTile(TileID.Stone);
            recipe.Register();
        }
    }
}