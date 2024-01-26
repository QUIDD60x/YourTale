using YourTale.Tiles.Furniture;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using YourTale.Projectiles.Arrows;

namespace YourTale.Items.Weapons.Ranged.Projectiles.Arrows
{
	public class HarpyShot : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 20;
		}

		public override void SetDefaults()
		{
			Item.damage = 20; // The damage for projectiles isn't actually 20, it actually is the damage combined with the projectile and the item together.
			Item.DamageType = DamageClass.Ranged;
			Item.width = 34;
			Item.height = 14;
			Item.maxStack = 999;
			Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
			Item.knockBack = 1.5f;
			Item.value = 10;
			Item.rare = ItemRarityID.Green;
			Item.shoot = ModContent.ProjectileType<HarpyShotProj>(); // The projectile that weapons fire when using this item as ammunition.
			Item.shootSpeed = 16f; // The speed of the projectile.
			Item.ammo = AmmoID.Bullet; // The ammo class this ammo belongs to.
			Item.ammo = Item.type;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Feather)
				.AddIngredient(ItemID.WoodenArrow, 3)
				.AddTile(TileID.SkyMill)
				.Register();
		}
	}
}