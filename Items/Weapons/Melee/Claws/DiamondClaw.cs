using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class  DiamondClaw : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 9;
            Item.crit = 14;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 34;
            Item.height = 32;
            Item.scale *= 1.25f;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.25f;
            Item.value = 4435;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EmptyClaw>(), 1);
            recipe.AddIngredient(ItemID.Diamond, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}