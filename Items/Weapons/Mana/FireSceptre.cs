using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Mana
{
    public class FireSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Sceptre");
            Tooltip.SetDefault("Incredibly hot! \nextremely powerful, but can only be used in bursts.");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 25;
            item.magic = true;
            item.mana = 20;
            item.width = 40;
            item.height = 40;
            item.useTime = 3;
            item.useAnimation = 7;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 0;
            item.value = 15000;
            item.rare = ItemRarityID.Orange;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<FireStaffProj>();
            item.shootSpeed = 20f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.AshBlock, 20);
            recipe.AddIngredient(ItemID.LavaBucket, 1);
            recipe.AddIngredient(mod.ItemType("StarShard"), 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}