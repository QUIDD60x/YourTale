using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Buffs.Bad;
using yourtale.Rarities;
using Terraria.DataStructures;
using static Terraria.ModLoader.PlayerDrawLayer;
using Microsoft.Xna.Framework;
using System.Security.Cryptography.X509Certificates;
using yourtale.Projectiles.Swords;
using yourtale.Projectiles.Staffs;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class AmberSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 17;
            Item.crit = 14;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 40;
            Item.useAnimation = 24;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.2f;
            Item.value = 2000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shootSpeed= 5;
            Item.shoot = ModContent.ProjectileType<Empty>();

        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (Main.rand.NextBool(5))
            {
                type = ModContent.ProjectileType<Sandnado2>();
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Amber, 8);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}