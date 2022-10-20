using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Projectiles.Swords;
using yourtale.Rarities;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class GloomSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("THESWORD"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("''Oh the woe! 'Tis quite gloomy indeed, in the fun and games of war. What was once a breaker of hearts is now a broken heart.''");
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item1;
            Item.shoot = ProjectileID.VilePowder;
            Item.useTime = 6;
            Item.useAnimation = 120;
            Item.autoReuse = true;
            Item.damage = 130;
            Item.shootSpeed = 12;
            Item.rare = ModContent.RarityType<AncientPurple>();
        }


        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust dust;
            Vector2 position = Main.LocalPlayer.Center;
            dust = Dust.NewDustDirect(position, 0, 0, DustID.Granite, 0f, 0f, 0, new Color(255, 255, 255), 0.3f);
            dust.noGravity = true;
            dust.fadeIn = 1.4302325f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.VilePowder, 13);
            recipe.AddIngredient(ItemID.BreakerBlade, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ViciousPowder, 13);
            recipe.AddIngredient(ItemID.BreakerBlade, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard"), 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}