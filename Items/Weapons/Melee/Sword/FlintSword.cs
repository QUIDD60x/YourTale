using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class FlintSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 10;
            Item.crit = 12;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 40;
            Item.height = 40;
            Item.scale *= 1.35f;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 3;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 4);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddIngredient(ItemID.StoneBlock, 4);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}