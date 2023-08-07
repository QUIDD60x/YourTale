using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Items.Armor.RavensWing
{
    [AutoloadEquip(EquipType.Body)]
    public class RavenlaidChest : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700;

            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Yellow;

            Item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);
            player.moveSpeed += .4f;
            player.wingTime += .3f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("RavenFeather").Type, 15);
            recipe.AddIngredient(Mod.Find<ModItem>("GiantRavenFeather").Type, 1);
            recipe.AddIngredient(Mod.Find<ModItem>("SpookyHeart").Type, 1);
            recipe.AddIngredient(ItemID.SpookyWood, 150);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}