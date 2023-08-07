using yourtale.Projectiles.Spears;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using yourtale.Dusts;
using yourtale.Buffs.Bad;

namespace yourtale.Items.Weapons.Melee.Spear
{
    public class Ton : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
            ItemID.Sets.Spears[Item.type] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            // Common Properties
            Item.rare = ItemRarityID.Pink;
            Item.value = Item.sellPrice(gold: 40);

            // Use Properties
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.UseSound = SoundID.Item71;
            Item.autoReuse = true;

            // Weapon Properties
            Item.damage = 50;
            Item.knockBack = 6.5f;
            Item.noUseGraphic = true;
            Item.DamageType = DamageClass.Melee;
            Item.noMelee = true;

            // Projectile Properties
            Item.shootSpeed = 5.6f;
            Item.shoot = ModContent.ProjectileType<TonProj>();
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override bool? UseItem(Player player)
        {
            if (!Main.dedServ && Item.UseSound.HasValue)
            {
                SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
            }

            return null;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Gungnir, 1)
                .AddIngredient(ItemID.SoulofFright, 15)
                .AddIngredient(ItemID.SoulofMight, 15)
                .AddIngredient(ItemID.SoulofSight, 15)
                .AddIngredient(ItemID.AdamantiteBar, 10)
                .AddTile(TileID.Anvils)
                .Register();

                        CreateRecipe()
                .AddIngredient(ItemID.Gungnir, 1)
                .AddIngredient(ItemID.SoulofFright, 15)
                .AddIngredient(ItemID.SoulofMight, 15)
                .AddIngredient(ItemID.SoulofSight, 15)
                .AddIngredient(ItemID.TitaniumBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}