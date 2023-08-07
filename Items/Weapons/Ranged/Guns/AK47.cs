using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Ranged.Guns
{
    public class AK47 : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 62;
            Item.height = 32;
            Item.scale = 1.65f;
            Item.rare = ItemRarityID.Orange;

            // Use Properties
            Item.useTime = 11; // (60 ticks == 1 second.)
            Item.useAnimation = 11;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.autoReuse = true;

            Item.UseSound = new SoundStyle($"{nameof(yourtale)}/Assets/Sounds/Items/Ranged/AK47")
            {
                Volume = 1.2f,
                PitchVariance = 0.4f,
                MaxInstances = 4,
            };

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 19;
            Item.knockBack = 5f;
            Item.noMelee = true;

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder;
            Item.shootSpeed = 18f;
            Item.useAmmo = AmmoID.Bullet;
        }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
    Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
    if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
        position += muzzleOffset;
    }
    } // Ignore this awfully copy-pasted code lol

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GunParts>(), 4);
            recipe.AddIngredient(ItemID.LeadBar, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2f);
        }
    }
}