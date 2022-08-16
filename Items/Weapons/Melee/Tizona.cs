using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Rarities;

namespace yourtale.Items.Weapons.Melee
{
    public class Tizona : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tizón");
            Tooltip.SetDefault("This legendary blade has been known to frighten those unworthy of battle.");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.Katana);
            Item.damage = 115;
            Item.useTime = 8;
            Item.useAnimation = 10;
            Item.rare = ModContent.RarityType<AncientPurple>();
            Item.crit = 99;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.MagicMirror);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Muramasa, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard").Type, 5);
            recipe.AddTile(Mod.Find<ModTile>("AncientAnvil"));
            recipe.Register();
        }
    }
}