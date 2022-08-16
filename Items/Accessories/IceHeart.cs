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
            Item.width = 20; //best to leave these the same size as the sprite if possible.
            Item.height = 20;
            Item.accessory = true; //will allow it to be equipped
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.IceBarrier, 2); //player.AddBuff(mod.BuffType("buffnamehere"), number here); for modded buffs/debuffs.
            player.moveSpeed *= 0.9f; //remember that multiplying a decimal is equivalent to dividing by a whole number.
            player.maxRunSpeed *= 0.7f;
            player.endurance *= 1.5f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddIngredient(ItemID.ManaCrystal, 2);
            recipe.AddIngredient(Mod.Find<ModItem>("Cryolite").Type, 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}