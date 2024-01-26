using YourTale.Projectiles.Staffs;
using YourTale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Items.Weapons.Magic
{
    public class FireSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.damage = 25;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 20;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 3;
            Item.useAnimation = 7;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 0;
            Item.value = Item.buyPrice(0, 0, 65, 0);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<FireStaffProj>();
            Item.shootSpeed = 20f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AshBlock, 20);
            recipe.AddIngredient(ItemID.LavaBucket, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("StarShard").Type, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}