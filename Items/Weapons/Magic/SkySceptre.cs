/*using yourtale.Projectiles.Staffs;
using yourtale.Tiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
namespace yourtale.Items.Weapons.Magic
{
    public class SkySceptre : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
        }

        public override void SetDefaults()
        {
            item.damage = 8;
            item.magic = true;
            item.mana = 10;
            item.width = 40;
            item.height = 40;
            item.useTime = 15;
            item.useAnimation = 15;
            item.useStyle = ItemUseStyleID.HoldingOut;
            item.noMelee = true; //so the item's animation doesn't do damage
            item.knockBack = 10;
            item.value = 100;
            item.rare = ItemRarityID.Green;
            item.UseSound = SoundID.Item20;
            item.autoReuse = true;
            item.shoot = ModContent.ProjectileType<SkySceptreProj>();
            item.shootSpeed = 10f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Cloud, 15);
            recipe.AddIngredient(ItemID.RainCloud, 3);
            recipe.AddIngredient(ItemID.SunplateBlock, 5);
            recipe.AddIngredient(mod.ItemType("StarShard"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
            recipe.AddIngredient(ItemID.CloudinaBottle);
            recipe.AddIngredient(mod.ItemType("StarShard"), 10);
            recipe.AddTile(TileID.Anvils);
        }
    }
} */