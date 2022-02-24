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
            Tooltip.SetDefault("Cold as ice... \ndecreases overall speed but protects you."); // \n will add another line, very useful for big text.
        }

        public override void SetDefaults()
        {
            item.width = 20; //best to leave these the same size as the sprite if possible.
            item.height = 20;
            item.accessory = true; //will allow it to be equipped
            item.value = Item.sellPrice(gold: 1);
            item.rare = ItemRarityID.Blue;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.IceBarrier, 2); //player.AddBuff(mod.BuffType("buffnamehere"), number here); for modded buffs/debuffs.
            player.meleeSpeed -= 0.2f;
            player.moveSpeed *= 0.8f; //remember that multiplying a decimal is equivalent to dividing by a whole number.
            player.maxRunSpeed *= 0.2f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddIngredient(ItemID.ManaCrystal, 2);
            recipe.AddIngredient(mod.ItemType("Cryolite"), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}