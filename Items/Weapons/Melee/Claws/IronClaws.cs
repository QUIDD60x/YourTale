using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class IronClaws : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("A sturdy set of claws, perfect for unrelenting bloodlust.");
        }

        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.crit = 6;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 25;
            Item.height = 25;
            Item.scale *= 1.25f;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.3f;
            Item.value = 135;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 6);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LeadBar, 6);
            recipe.AddIngredient(ItemID.Wood, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}