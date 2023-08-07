using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;
using yourtale.Items.Placeables;
using yourtale.Projectiles.Bombs;
using yourtale.Projectiles.Staffs;

namespace yourtale.Items.Weapons.Explosives
{
    public class PipeBomb : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 10;
            Item.noMelee= true;
            Item.DamageType = ModContent.GetInstance<ExplosiveClass>();
            Item.consumable = true;
            Item.maxStack = 999;
            Item.width = 24;
            Item.height = 40;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 120;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<PipeBombProj>();
            Item.shootSpeed = 8;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.Wire, 7);
            recipe.AddIngredient(ItemID.IronBar, 4);
            recipe.AddIngredient(Mod.Find<ModItem>("SparkPowder"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}