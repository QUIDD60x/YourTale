using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Accessories
{
    public class BrokenUmbrella : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Broken Umbrella");
            Tooltip.SetDefault("Good job, you broke an umbrella. Your rage increases melee damage and speed.");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;

            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;

            Item.accessory = true;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) *= 1.18f;
            player.GetAttackSpeed(DamageClass.Melee) *= 1.11f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Umbrella, 1);
            recipe.AddIngredient(ItemID.WoodenHammer, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}