using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Items.Placeables;

namespace yourtale.Items.Weapons.Explosives
{
    public class RomanCandle : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 999;

            // Use Properties
            Item.useTime = 20; // (60 ticks == 1 second.)
            Item.useAnimation = 120;
            Item.useStyle = ItemUseStyleID.Rapier;
            Item.UseSound = SoundID.Item20;
            Item.consumeAmmoOnFirstShotOnly = true;

            // Weapon Properties
            Item.DamageType = DamageClass.Ranged;
            Item.damage = 19;
            Item.knockBack = 5f;
            Item.noMelee = true;

            // Gun Properties
            Item.shoot = ProjectileID.Flare;
            Item.shootSpeed = 12f;
            Item.consumable = true;
        }

    public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
    Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;
    if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0)) {
        position += muzzleOffset;
    }
    }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SparkPowder>(), 4);
            recipe.AddIngredient(ItemID.Wood, 7);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        // This method lets you adjust position of the gun in the player's hands. Play with these values until it looks good with your graphics.
        /*public override Vector2? HoldoutOffset()
        {
            return new Vector2(2f, -2f);
        }*/
    }
}