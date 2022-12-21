using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using yourtale.Tiles.Furniture;
using yourtale.Rarities;

namespace yourtale.Items.Placeables
{
    public class AncientAnvil2 : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thendric Anvil");
            Tooltip.SetDefault("You somehow repaired this, and can now use it to make weapons beyond mortality.");
        }

        public override void SetDefaults()
        {
            Item.createTile = ModContent.TileType<Tiles.Furniture.AncientAnvil2>(); // This sets the id of the tile that this item should place when used.

            Item.width = 28; // The item texture's width
            Item.height = 14; // The item texture's height

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 15;

            Item.maxStack = 99;
            Item.consumable = true;
            Item.value = 150;
            Item.rare = ModContent.RarityType<AncientPurple>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("AncientAnvil").Type, 3);
            recipe.AddIngredient(ItemID.HallowedBar, 15);
            recipe.AddIngredient(ItemID.MythrilBar, 10);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard").Type, 35);
            recipe.AddTile(Mod.Find<ModTile>("AnimanticConvoluter").Type);
            recipe.Register();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("AncientPurpleDust").Type);
        }
    }
}