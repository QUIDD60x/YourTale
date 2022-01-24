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
    public class IceHeart : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Cold as ice... \ndecreases melee but protects you.");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.IceBarrier, 2);
            player.meleeSpeed -= 0.2f;
            player.moveSpeed *= 0.8f;
            player.maxRunSpeed *= 0.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddIngredient(ItemID.ManaCrystal, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}