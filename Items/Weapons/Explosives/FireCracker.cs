using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;
using yourtale.Items.Placeables;
using yourtale.Projectiles.Bombs;
using yourtale.Projectiles.Staffs;

namespace yourtale.Items.Weapons.Explosives
{
    public class FireCracker : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Firecrackers");
            Tooltip.SetDefault("A small explosive, to get you started in your boom business.\nThrows a string of 5 explosive firecrackers that explode after a short delay.\nFirecrackers do not destroy blocks.");
        }

        public override void SetDefaults()
        {
            Item.damage = 50;
            Item.crit = 20;
            Item.noMelee= true;
            Item.DamageType = ModContent.GetInstance<ExplosiveClass>();
            Item.consumable = true;
            Item.maxStack = 995;
            Item.width = 24;
            Item.height = 40;
            Item.useTime = 7;
            Item.useAnimation = 32;
            Item.reuseDelay = 40;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.value = 120;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.shoot = ModContent.ProjectileType<FireCrackerProj>();
            Item.shootSpeed = 9;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(5);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddIngredient(Mod.Find<ModItem>("SparkPowder"), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}