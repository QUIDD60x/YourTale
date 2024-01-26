using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using YourTale.Rarities;
using Microsoft.Xna.Framework;
using YourTale.Items.Shells;
using YourTale.DamageClasses;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class SeraphClaws : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
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
            Item.crit = 1;
            Item.shootSpeed = 15;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(player, target, hit, damageDone);
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
            recipe.AddIngredient(Mod.Find<ModItem>("SwordMold").Type, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}