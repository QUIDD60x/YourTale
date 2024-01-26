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

namespace YourTale.Items.Armor.RavensWing
{
    [AutoloadEquip(EquipType.Head)]
    public class RavenlaidHelmet : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 1;
            Item.height = 15;

            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Yellow;

            Item.defense = 10;
        }
        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);
            player.arrowDamage += .33f;
            player.wingTime += .3f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("RavenFeather").Type, 12);
            recipe.AddIngredient(Mod.Find<ModItem>("GiantRavenFeather").Type, 1);
            recipe.AddIngredient(ItemID.SpookyWood, 110);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) //This last bit here is the set bonus code.
        { //this checks to see if you have all 3 armours equipped.
            return body.type == Mod.Find<ModItem>("RavenlaidChest").Type && legs.type == Mod.Find<ModItem>("RavenlaidLeggings").Type;
        }

        public override void UpdateArmorSet(Player player) //here is the armor set upgrade.
        {
            player.setBonus = "You feel as light as a feather! Grants nearly infinite flight time, and heavy arrow damage increase.";
            player.wingTime *= 4;
            player.wingAccRunSpeed *= 4;
            player.arrowDamage *= 1.7f; // LARGE increase I know.
        }
    }
}