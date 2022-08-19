using IL.Terraria.DataStructures;
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
            if (Main.rand.NextFloat() < 0.7209302f)
            {
                Dust dust;
                // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                Vector2 position = Main.LocalPlayer.Center;
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, DustID.GemSapphire, 0.4651165f, -0.6976738f, 0, new Color(255, 255, 255), 0.69767445f)];
                dust.fadeIn = 1.0116279f;
            }

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