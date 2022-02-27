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
    [AutoloadEquip(EquipType.Legs)] //this doesn't really have anything worth mentioning in it.
    public class AnimulaLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("I think this fixed that arrow to the knee issue?");
        }

        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 700;
            item.value = Item.sellPrice(silver: -1);
            item.rare = ItemRarityID.Green;
            item.defense = 10;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("LifeShard"), 9);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}