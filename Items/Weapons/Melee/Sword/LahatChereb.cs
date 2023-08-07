using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Rarities;
using yourtale.Projectiles.Swords;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class LahatChereb : ModItem
    {

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FieryGreatsword);
            Item.shoot = Mod.Find<ModProjectile>("LahatCherebProj").Type;
            Item.damage = 60;
            Item.crit = 5;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Melee;
            Item.shootSpeed = 15;
            Item.rare = ModContent.RarityType<Gold>();
        }

        public override void HoldItem(Player player)
        {
            base.HoldItem(player);
            if (Main.rand.NextFloat() < 0.3604651f)
            {
                Dust dust;
                Vector2 position = Main.LocalPlayer.Center; dust = Dust.NewDustDirect(position, 18, 30, DustID.HealingPlus, 0f, 0f, 0, new Color(255, 255, 255), 0.116279066f);
                dust.fadeIn = 1.6744187f;
            }
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