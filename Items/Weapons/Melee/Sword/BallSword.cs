using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class BallSword : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dawn of Power"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
            Tooltip.SetDefault("Shoots a slow-moving sword.\nFeels like it's missing something...");
        }

        public override void SetDefaults()
        {
            Item.damage = 34;
            Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
            Item.width = 27;
            Item.height = 27;
            Item.scale = 1.95f;
            Item.useTime = 7;
            Item.useAnimation = 32;
            Item.reuseDelay = 40;
            Item.useStyle = ItemUseStyleID.Thrust;
            Item.knockBack = 1.5f;
            Item.value = 1150;
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.SwordBeam;
            Item.shootSpeed = 5;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 4);
            recipe.AddIngredient(ItemID.Wood, 8);
            recipe.AddIngredient(ItemID.StoneBlock, 4);
            recipe.AddIngredient(Mod.Find<ModItem>("StarShard"), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}