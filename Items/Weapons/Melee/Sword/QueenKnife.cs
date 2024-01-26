using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.Projectiles.Arrows;
using YourTale.Items;
using YourTale.Projectiles.Spears;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class QueenKnife : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 19;
            Item.crit = 8;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 0.2f;
            Item.value = 2000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed= 12;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<HHShot>();

        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GiantRavenFeather>(), 1);
            recipe.AddIngredient(ItemID.SpookyWood, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}