using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class FlintJian : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 5;
            Item.crit = 15;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 50;
            Item.height = 50;
            Item.scale *= 0.75f;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 1;
            Item.value = 0;
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 4);
            recipe.AddIngredient(ItemID.Wood, 6);
            recipe.AddIngredient(ItemID.StoneBlock, 2);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}