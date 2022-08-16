using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Projectiles.Swords;

namespace yourtale.Items.Weapons.Melee
{
    public class Chrysaor : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("THESWORD"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Once weilded by one of the highest Thendra Knights\n" +
                "Shoots defense damaging ichor.");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.TrueExcalibur);
            Item.shoot = Mod.Find<ModProjectile>("ChrysaorProj").Type;
            Item.damage = 90;
            Item.shootSpeed = 3;
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.HallowedWeapons);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 10);
            recipe.AddIngredient(ItemID.HallowedBar, 14);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}