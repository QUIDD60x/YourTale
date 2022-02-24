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

namespace yourtale.Items.Armor.Cryolite
{
    [AutoloadEquip(EquipType.Legs)] //this doesn't really have anything worth mentioning in it.
    public class CryoliteLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("I need some nether-heated underwear to wear these...");
        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 700;
            item.value = Item.sellPrice(silver: -1);
            item.rare = ItemRarityID.Blue;
            item.defense = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CryoliteBar"), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}