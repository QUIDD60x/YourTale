/*using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Projectiles.Bombs;

namespace yourtale.Items.Weapons.Magic // Used this to test the explosion projectile, don't get your hopes up of these being added back soon.
{
    public class EarthSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[Item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            Item.damage = 16;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 5;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 12;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.noMelee = true; //so the item's animation doesn't do damage
            Item.knockBack = 0;
            Item.value = Item.buyPrice(0, 0, 65, 0);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Explosion>();
            Item.shootSpeed = 14f;
        }

        public override void AddRecipes()
        {

        }
    }
}*/