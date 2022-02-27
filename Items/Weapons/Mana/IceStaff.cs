using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Mana
{
    public class IceStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Sceptre");
            Tooltip.SetDefault("Chilly!");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.magic = true; //important to set the weapon to a class.
            item.mana = 5;
            item.width = 40;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = Item.buyPrice(0, 0, 55, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SparklingBall>(); //the projectile it shoots
            item.shootSpeed = 16f; //the speed at which the projectile goes flying out.
        }

        public override void AddRecipes()
        { //this recipe is good as it contains all the things you would need, modded or not.
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.SnowBlock, 12);
            recipe.AddIngredient(ItemID.Shiverthorn, 3);
            recipe.AddIngredient(ItemID.IceBlock, 15);
            recipe.AddIngredient(mod.ItemType("Cryolite"), 10);
            recipe.AddIngredient(mod.ItemType("StarShard"), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}