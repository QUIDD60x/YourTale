using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Mana
{
    public class DestructionSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Staff Of Destruction");
            Tooltip.SetDefault("Absolutely terrifying!");
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.damage = 60;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 50;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = false; //so the item's animation doesn't do damage
            Item.knockBack = 7;
            Item.value = Item.buyPrice(0, 0, 55, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            //Item.shoot = ModContent.ProjectileType<EarlyBomb>();
            Item.shootSpeed = 5f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Bomb, 5);
            recipe.AddIngredient(ItemID.Grenade, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("CorExitio").Type, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("StarShard").Type, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}