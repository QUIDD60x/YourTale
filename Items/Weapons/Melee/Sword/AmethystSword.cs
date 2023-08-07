using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class AmethystSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.crit = 4;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 1.5f;
            Item.value = 3000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amethyst, 8);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}