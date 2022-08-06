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
            Item.width = 25;
            Item.height = 700;
            Item.value = Item.sellPrice(silver: -1);
            Item.rare = ItemRarityID.Green;
            Item.defense = 10;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 9);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}