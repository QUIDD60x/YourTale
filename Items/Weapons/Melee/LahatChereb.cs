using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

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
            Item.shoot = ProjectileID.CultistBossFireBall;
            Item.damage = 60;
            Item.shootSpeed = 5;
            Item.autoReuse = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.FieryGreatsword, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard").Type, 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}