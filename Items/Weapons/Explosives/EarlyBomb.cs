using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Explosives
{
    internal class EarlyBomb : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("exitium incarnatus est");
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[Item.type] = true; //basically means this in inventory=demolitionist will spawn.
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Swing; //makes it look more like a throw.
            Item.shootSpeed = 4f; //the velocity at which is goes flying out at.
            Item.shoot = ModContent.ProjectileType<Projectiles.Staffs.EarlyBomb>(); //the actual projectile.
            Item.width = 8;
            Item.height = 28;
            Item.maxStack = 30;
            Item.consumable = true; //VERY IMPORTANT as without this it will be infinite.
            Item.UseSound = SoundID.Item1;
            Item.useAnimation = 40;
            Item.useTime = 40;
            Item.noUseGraphic = true;
            Item.noMelee = true; //will stop it from dealing damage as a melee hit.
            Item.value = Item.buyPrice(0, 0, 20, 0);
            Item.rare = ItemRarityID.Pink;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.Grenade, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("CorExitio").Type, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}