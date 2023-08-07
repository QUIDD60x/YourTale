using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Items;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class BBallSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 70;
            Item.DamageType = DamageClass.Melee;
            Item.width = 90;
            Item.crit = 35;
            Item.height = 90;
            Item.useTime = 6;
            Item.useAnimation = 24;
            Item.reuseDelay = 28;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 3.5f;
            Item.value = 5235;
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.SwordBeam;
            Item.shootSpeed = 15;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback) {
            type = Main.rand.Next(new int[] { type, ProjectileID.NightBeam, ProjectileID.TerraBeam, ProjectileID.EnchantedBeam });
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
        Projectile.NewProjectile(source, position, velocity, ProjectileID.FinalFractal, damage, knockback, player.whoAmI);
    return true;
}

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BallSword>());
            recipe.AddIngredient(ModContent.ItemType<YellowBall>());
            recipe.AddIngredient(ModContent.ItemType<OrangeBall>());
            recipe.AddIngredient(ModContent.ItemType<GreenBall>());
            recipe.AddIngredient(ModContent.ItemType<BlueBall>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}