using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Tools
{
    public class FlintPick : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flint Pickaxe");
            Tooltip.SetDefault("I used the stones to mine the stones... NOT a good pick.");
        }

        public override void SetDefaults()
        {

            item.damage = 2; // Base Damage of the Weapon
            item.width = 24; // Hitbox Width
            item.height = 24; // Hitbox Height
            item.useTime = 20; // Speed before reuse
            item.useAnimation = 20; // Animation Speed
            item.useStyle = 1; // 1 = Broadsword 
            item.knockBack = 1.5f; // Weapon Knockbase: Higher means greater "launch" distance
            item.value = -1; // 10 | 00 | 00 | 00 : Platinum | Gold | Silver | Bronze
            item.rare = 1; // Item Tier
            item.UseSound = SoundID.Item1; // Sound effect of item on use 
            item.autoReuse = true; // Do you want to torture people with clicking? Set to false

            item.pick = 30; // Pick Power - Higher Value = Better
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("flint"), 6);
            recipe.AddTile(TileID.Stone);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}