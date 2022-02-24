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
            ItemID.Sets.ItemsThatCountAsBombsForDemolitionistToSpawn[item.type] = true; //basically means this in inventory=demolitionist will spawn.
        }

        public override void SetDefaults()
        {
            item.useStyle = ItemUseStyleID.SwingThrow; //makes it look more like a throw.
            item.shootSpeed = 4f; //the velocity at which is goes flying out at.
            item.shoot = ModContent.ProjectileType<Projectiles.Staffs.EarlyBomb>(); //the actual projectile.
            item.width = 8;
            item.height = 28;
            item.maxStack = 30;
            item.consumable = true; //VERY IMPORTANT as without this it will be infinite.
            item.UseSound = SoundID.Item1;
            item.useAnimation = 40;
            item.useTime = 40;
            item.noUseGraphic = true;
            item.noMelee = true; //will stop it from dealing damage as a melee hit.
            item.value = Item.buyPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Pink;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 3);
            recipe.AddIngredient(mod.ItemType("CorExitio"), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this, 3);
            recipe.AddRecipe();
        }
    }
}