using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using yourtale.Items.Placeables;
using yourtale.Tiles.Furniture;

namespace yourtale.Items
{
    public class HypervitalicEssence : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hypervitalic Essense");
            Tooltip.SetDefault("A fast moving particle of consciousness.");

            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(4, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;

            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.maxStack = 999;
            Item.value = 1000; // Makes the item worth 1 gold.
            Item.rare = ItemRarityID.Orange;
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.ForestGreen.ToVector3() * 0.22f * Main.essScale);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SpiritShard1>(), 3);
            recipe.AddTile(ModContent.TileType<Tiles.Furniture.AnimanticConvoluter>());
            recipe.Register();
        }
    }
}