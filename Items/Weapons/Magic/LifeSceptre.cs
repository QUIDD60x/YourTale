using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Magic
{
    public class LifeSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 5;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 0;
            Item.value = Item.buyPrice(0, 0, 65, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<HealProj>();
            Item.shootSpeed = 14f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.AddIngredient(ItemID.Acorn, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("StarShard").Type, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("StarShard").Type, 5);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}