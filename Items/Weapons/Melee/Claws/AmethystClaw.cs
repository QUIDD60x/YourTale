using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class  AmethystClaw : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 4;
            Item.crit = 14;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 34;
            Item.height = 32;
            Item.scale *= 1.25f;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.11f;
            Item.value = 1235;
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