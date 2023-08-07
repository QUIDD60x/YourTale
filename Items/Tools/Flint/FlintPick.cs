using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Tools.Flint
{
    public class FlintPick : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 2; // Base Damage of the Weapon
            Item.width = 24; // Hitbox Width
            Item.height = 24; // Hitbox Height
            Item.useTime = 20; // Speed before reuse
            Item.useAnimation = 20; // Animation Speed
            Item.useStyle = 1; // 1 = Broadsword 
            Item.knockBack = 1.5f; // Weapon Knockbase: Higher means greater "launch" distance
            Item.value = -1; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
            Item.rare = 1; // Item Tier
            Item.UseSound = SoundID.Item1; // Sound effect of item on use 
            Item.autoReuse = true; // Do you want to torture people with clicking? Set to false

            Item.pick = 30; // Pick Power - Higher Value = Better
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 6);
            recipe.AddTile(TileID.Stone);
            recipe.Register();
        }
    }
}