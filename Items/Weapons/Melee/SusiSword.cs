using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Rarities;

namespace yourtale.Items.Weapons.Melee
{
    public class SusiSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SusiSwinger");
            Tooltip.SetDefault("Thank you for the great sprites Susi!");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.height = 35;
            Item.width = 35;
            Item.damage = 125;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.autoReuse = true;
            Item.rare = ItemRarityID.Pink;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FoodPlatter, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}