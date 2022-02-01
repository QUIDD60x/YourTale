using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Weapons.Mana
{
    public class LifeSceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Sceptre");
            Tooltip.SetDefault("Smells nice!\n very bouncy and fast, as it is full of life.");
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 12;
            item.magic = true;
            item.mana = 10;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 0;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<HealProj>();
            item.shootSpeed = 14f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood, 12);
            recipe.AddIngredient(ItemID.Acorn, 3);
            recipe.AddIngredient(mod.ItemType("StarShard"), 5);
            recipe.AddIngredient(mod.ItemType("LifeShard"), 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}