using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Items.Accessories
{
    public class IceHeart : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20; //best to leave these the same size as the sprite if possible.
            Item.height = 20;

            Item.value = Item.sellPrice(gold: 1, silver: 50);
            Item.rare = ItemRarityID.Blue;

            Item.accessory = true; //will allow it to be equipped
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(BuffID.IceBarrier, 2); //player.AddBuff(mod.BuffType("buffnamehere"), number here); for modded buffs/debuffs.
            player.moveSpeed *= 0.9f; //remember that multiplying by a decimal is equivalent to dividing.
            player.maxRunSpeed *= 0.85f;
            player.endurance *= 1.45f;
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