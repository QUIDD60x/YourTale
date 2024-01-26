using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.DamageClasses;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class TopazClaw : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 6;
            Item.crit = 39;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 34;
            Item.height = 32;
            Item.scale *= 1.25f;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.18f;
            Item.value = 1935;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EmptyClaw>(), 1);
            recipe.AddIngredient(ItemID.Topaz, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}