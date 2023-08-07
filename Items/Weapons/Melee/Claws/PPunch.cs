using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;
using Terraria.DataStructures;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class  PPunch : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.crit = 15;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 34;
            Item.height = 32;
            Item.scale *= 0.44f;
            Item.useTime = 21;
            Item.useAnimation = 21;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.92f;
            Item.value = 5721;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Vector2 direction = player.Center + player.velocity;
            Projectile.NewProjectileDirect(null, target.Center, direction.RotatedByRandom(MathHelper.ToRadians(20)), ProjectileID.BulletHighVelocity, 10, 0.3f);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FlintlockPistol, 1);
            recipe.AddIngredient(ItemID.IllegalGunParts, 1);
            recipe.AddIngredient(ItemID.IronBar, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}