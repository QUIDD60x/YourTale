/*using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Mana
{
    public class EarthSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Earth Sceptre");
            Tooltip.SetDefault("Smells... odd.");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 27;
            item.magic = true;
            item.mana = 5;
            item.width = 40;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 5;
            item.value = Item.buyPrice(0, 0, 20, 0);
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SparklingBall>();
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 50);
            recipe.AddIngredient(ItemID.MudBlock, 10);
            //recipe.AddIngredient(mod.ItemType("LifeShard"), 10);
            recipe.AddIngredient(mod.ItemType("StarShard"), 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}*/