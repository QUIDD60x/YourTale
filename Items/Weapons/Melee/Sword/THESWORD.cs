using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Prefixes;

namespace YourTale.Items.Weapons.Melee.Sword
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
            Item.damage = 25052006;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 2;
            Item.useAnimation = 3;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 0.1f;
            Item.value = 1;
            Item.rare = 15;
            Item.autoReuse = true;
            Item.healLife = 2000;
            Item.healMana = 200;
            Item.lifeRegen = 2000;
            Item.UseSound = SoundID.Grab;
            Item.createTile = TileID.Diamond;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 1000);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}