using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Projectiles.Swords;
using yourtale.Rarities;
#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class Chrysaor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("THESWORD"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Once weilded by one of the highest Thendra Knights, its age has taken a toll on the magic.\n" +
                "Shoots a variety of projectiles, some harder to handle than others.");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TrueExcalibur);
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.damage = 90;
            Item.shootSpeed = 12;
            Item.rare = ModContent.RarityType<Gold>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {

            if (Main.rand.NextBool(3))
            {
                type = ProjectileID.EnchantedBeam;
                type = ProjectileID.SuperStar;
            }

            if (!Main.rand.NextBool(2))
            {
                type = ProjectileID.HallowStar;
            }

            if (!Main.rand.NextBool(2))
            {
                type = ProjectileID.IchorSplash;
            }

            if (Main.rand.NextBool(10))
            {
                type = ProjectileID.EnchantedBeam;
                type = ProjectileID.SuperStar;
                type = ProjectileID.HallowStar;
                type = ProjectileID.IchorSplash;
            }

        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.HallowedWeapons);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TitaniumBar, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 14);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 14);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard"), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}