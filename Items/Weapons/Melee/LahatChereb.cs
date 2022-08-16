using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Rarities;
using yourtale.Projectiles.Swords;

namespace yourtale.Items.Weapons.Melee
{
    public class LahatChereb : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lahat Chereb");
            Tooltip.SetDefault("This flame of the whirling sword was once weilding by an angel.");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FieryGreatsword);
            Item.damage = 60;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee;
            Item.shootSpeed = 15;
            Item.rare = ModContent.RarityType<TestRarity>();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.FlameBurst);
        }


        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard").Type, 15);
            recipe.AddTile(Mod.Find<ModTile>("AncientAnvil"));
            recipe.Register();
        }
    }
}