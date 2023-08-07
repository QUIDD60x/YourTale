using yourtale.Items.Weapons.Ranged.Projectiles.Arrows;
using yourtale.Projectiles.Arrows;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Ranged.Bows
{
	public class Gandiva : ModItem
	{
		public override void SetStaticDefaults()
		{
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// Common Properties
			Item.width = 54; // Hitbox width of the item.
			Item.height = 92; // Hitbox height of the item.
			Item.scale = 0.95f;
			Item.rare = ItemRarityID.Red; // The color that the item's name will be in-game.

			// Use Properties
			Item.useTime = 12; // The item's use time in ticks (60 ticks == 1 second.)
			Item.useAnimation = 4;
			Item.consumeAmmoOnLastShotOnly = true;
			Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
			Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.

			// The sound that this item plays when used.
			/*Item.UseSound = new SoundStyle($"{nameof(yourtale)}/Assets/Sounds/Items/Guns/ExampleGun")
			{
				Volume = 0.9f,
				PitchVariance = 0.2f,
				MaxInstances = 3,
			};*/

			Item.DamageType = DamageClass.Ranged;
			Item.damage = 40;
			Item.noMelee = true;

			// Gun Properties
			Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
			Item.shoot = ProjectileID.Leaf;
			Item.shootSpeed = 12f; // The speed of the projectile (measured in pixels per frame.)
			Item.useAmmo = ItemID.WoodenArrow;
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient<AncientShard>(14)
				.AddIngredient(ItemID.WoodenBow, 5)
				.AddIngredient(ItemID.WhiteString, 5)
				.AddTile(TileID.Anvils)
				.Register();
		}

		// This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
		public override Vector2? HoldoutOffset()
		{
			return new Vector2(2f, -2f);
		}

		//TODO: Move this to a more specifically named example. Say, a paint gun?
		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			// Every projectile shot from this gun has a 1/5 chance of being an ExampleInstancedProjectile
			if (Main.rand.NextBool(3))
			{
				type = ProjectileID.CrystalLeafShot;
			}
			if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = ProjectileID.Leaf;
			}
		}

		/*
		* Feel free to uncomment any of the examples below to see what they do
		*/

		// What if I wanted it to work like Uzi, replacing regular bullets with High Velocity Bullets?
		// Uzi/Molten Fury style: Replace normal Bullets with High Velocity
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			if (type == ProjectileID.Bullet) { // or ProjectileID.WoodenArrowFriendly
				type = ProjectileID.BulletHighVelocity; // or ProjectileID.FireArrow;
			}
		}*/

		// What if I wanted multiple projectiles in a even spread? (Vampire Knives)
		// Even Arc style: Multiple Projectile, Even Spread
		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 3 + Main.rand.Next(8); // 3, 4, or 5 shots
			float rotation = MathHelper.ToRadians(12);
			position += Vector2.Normalize(velocity) * 35f; //Distance from player
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * .5f; // Watch out for dividing by 0 if there is only 1 projectile.
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false; // return false to stop vanilla from calling Projectile.NewProjectile.
		}

		// How can I make the shots appear out of the muzzle exactly?
		// Also, when I do this, how do I prevent shooting through tiles?
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
			if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
				position += muzzleOffset;
			}
		}*/

		// How can I get a "Clockwork Assault Rifle" effect?
		// 3 round burst, only consume 1 ammo for burst. Delay between bursts, use reuseDelay
		// Make the following changes to SetDefaults():
		/*
			item.useAnimation = 12;
			item.useTime = 4; // one third of useAnimation
			item.reuseDelay = 14;
			item.consumeAmmoOnLastShotOnly = true;
		*/

		// How can I shoot 2 different projectiles at the same time?
		/*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// Here we manually spawn the 2nd projectile, manually specifying the projectile type that we wish to shoot.
			Projectile.NewProjectile(source, position, velocity, ProjectileID.GrenadeI, damage, knockback, player.whoAmI);
			// By returning true, the vanilla behavior will take place, which will shoot the 1st projectile, the one determined by the ammo.
			return true;
		}*/

		// How can I choose between several projectiles randomly?
		/*public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
			// Here we randomly set type to either the original (as defined by the ammo), a vanilla projectile, or a mod projectile.
			type = Main.rand.Next(new int[] { type, ProjectileID.GoldenBullet, ModContent.ProjectileType<Projectiles.ExampleBullet>() });
		}*/
	}
}