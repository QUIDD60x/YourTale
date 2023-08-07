using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Prefixes;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class THESWORD : ModItem
    {
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