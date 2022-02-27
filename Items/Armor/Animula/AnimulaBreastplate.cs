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

namespace yourtale.Items.Armor.Animula
{
    [AutoloadEquip(EquipType.Body)] // for that function when you can put the armour on in one click.
    public class AnimulaBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Almost makes me feel not empty!");
        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 700; //height is very large due to the need for it to resemble the sprite, i haven't messed with this so idk if it's nessecary to be exact.
            item.value = Item.sellPrice(silver: 14);
            item.rare = ItemRarityID.Green;
            item.defense = 11; //this obviously means the amount of defense it gets
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("LifeShard"), 15);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}