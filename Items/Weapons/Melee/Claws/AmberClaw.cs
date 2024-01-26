using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.DamageClasses;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class  AmberClaw : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.crit = 59;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 34;
            Item.height = 32;
            Item.scale *= 1.25f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.72f;
            Item.value = 3035;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EmptyClaw>(), 1);
            recipe.AddIngredient(ItemID.Amber, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}