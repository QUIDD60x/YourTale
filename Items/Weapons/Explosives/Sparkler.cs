using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;
using yourtale.Items.Placeables;
using yourtale.Projectiles.Bombs;
using yourtale.Projectiles.Staffs;

namespace yourtale.Items.Weapons.Explosives
{
    public class Sparkler : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sparkler");
            Tooltip.SetDefault("A small basic sparkler, that will deal a steady stream of damage.\nWill light enemies on fire, but doesn't explode.");
        }

        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 7;
            Item.noMelee= true;
            Item.DamageType = ModContent.GetInstance<ExplosiveClass>();
            Item.consumable = true;
            Item.maxStack = 999;
            Item.width = 24;
            Item.height = 40;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.value = 120;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<SparklerProj>();
            Item.shootSpeed = 7;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.IronBar, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("SparkPowder"), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.LeadBar, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("SparkPowder"), 1);
            recipe.Register();
        }
    }
}