using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Magic
{
    public class IceStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Sceptre");
            Tooltip.SetDefault("Chilly!");
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.damage = 14;
            Item.DamageType = DamageClass.Magic; //important to set the weapon to a class.
            Item.mana = 5;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 5;
            Item.value = Item.buyPrice(0, 0, 55, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<SparklingBall>(); //the projectile it shoots
            Item.shootSpeed = 16f; //the speed at which the projectile goes flying out.
        }

        public override void AddRecipes()
        { //this recipe is good as it contains all the things you would need, modded or not.
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SnowBlock, 12);
            recipe.AddIngredient(ItemID.Shiverthorn, 3);
            recipe.AddIngredient(ItemID.IceBlock, 15);
            recipe.AddIngredient(Mod.Find<ModItem>("Cryolite").Type, 10);
            recipe.AddIngredient(Mod.Find<ModItem>("StarShard").Type, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}