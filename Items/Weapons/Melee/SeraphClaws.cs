using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using yourtale.Rarities;
using Microsoft.Xna.Framework;

namespace yourtale.Items.Weapons.Melee
{
    public class SeraphClaws : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("THESWORD"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Heavenly claws forged by the Sisterhood of Steel, they swing faster than you can imagine.\n" +
                "Grants rapid healing on enemy hits.");
        }

        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Melee;
            Item.width = 50;
            Item.height = 50;
            Item.useTime = 10;
            Item.useAnimation = 2;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 1;
            Item.value = 500;
            Item.rare = ModContent.RarityType<Gold>();
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.crit = 77;
            Item.shootSpeed = 15;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);
        }
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            base.HoldItem(player);
            if (Main.rand.NextBool(3))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.HallowedWeapons);
            player.AddBuff(BuffID.RapidHealing, 100);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("flint").Type, 4);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}