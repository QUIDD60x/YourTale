using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Items;

namespace yourtale.Items.Weapons.Ranged.Guns
{
    public class Mossberg : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 31;
            Item.height = 10;
            Item.scale = 1.55f;
            Item.rare = ItemRarityID.Orange;

            // Use Properties
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.reuseDelay = 15;
            Item.reuseDelay = 14;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            // The sound that this item plays when used.
            Item.UseSound = new SoundStyle($"{nameof(yourtale)}/Assets/Sounds/Items/Ranged/Moss500")
            {
                Volume = 1.3f,
                PitchVariance = 0.5f,
                MaxInstances = 2,
            };

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 20;
            Item.knockBack = 5f;
            Item.noMelee = true;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 14f; 
            Item.useAmmo = AmmoID.Bullet;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GunParts>(), 3);
            recipe.AddIngredient(ItemID.LeadBar, 14);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GunParts>(), 3);
            recipe.AddIngredient(ItemID.Boomstick, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float numberProjectiles = 3 + Main.rand.Next(4); // 5 shots
			float rotation = MathHelper.ToRadians(8);
			position += Vector2.Normalize(velocity) * 100f;
			for (int i = 0; i < numberProjectiles; i++) {
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1)));
				Projectile.NewProjectile(source, position, perturbedSpeed, type, damage, knockback, player.whoAmI);
			}
			return false;
		}
    }
}