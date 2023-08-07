using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;
using yourtale.Items;
using yourtale.Rarities;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class  RavenClaw : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 30;
            Item.crit = 14;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 24;
            Item.height = 28;
            Item.scale *= 1.25f;
            Item.useTime = 11;
            Item.useAnimation = 11;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.3f;
            Item.value = 2075;
            Item.rare = ItemRarityID.Yellow;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SpookyWood, 75);
            recipe.AddIngredient(ItemID.HallowedBar, 7);
            recipe.AddIngredient(ModContent.ItemType<RavenFeather>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}