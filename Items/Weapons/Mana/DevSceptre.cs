using yourtale.Projectiles.Evil;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Mana
{
    public class DevSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Developer Sceptre");
            Tooltip.SetDefault("Why do you have this? \nUsed for testing hostile projectiles.");
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.damage = 14;
            item.magic = true;
            item.mana = 5;
            item.width = 40;
            item.height = 40;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true;
            item.knockBack = 5;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<EvilCryolisisProj>();
            item.shootSpeed = 1f; //the speed at which the projectile goes flying out.
        }
    }
}