using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class SapphireClaw : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 4;
            Item.crit = 19;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 34;
            Item.height = 32;
            Item.scale *= 1.25f;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.1f;
            Item.value = 1935;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EmptyClaw>(), 1);
            recipe.AddIngredient(ItemID.Sapphire, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}