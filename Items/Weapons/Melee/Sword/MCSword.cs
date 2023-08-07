using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Buffs.Bad;
using yourtale.Rarities;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class MCSword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 20+15+2+21+19+3+21+19; // Tobuscus lol
            Item.crit = 1;
            Item.DamageType = DamageClass.Melee;
            Item.width = 120;
            Item.height = 120;
            Item.scale *= 0.95f;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.8f;
            Item.value = 2015221;
            Item.rare = ItemRarityID.Cyan;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void RightClick(Player player)
        {
            base.RightClick(player);
            //Deez nuts lol
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Diamond, 200);
            recipe.AddIngredient(ModContent.ItemType<DiamondSword>(), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}