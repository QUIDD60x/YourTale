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
using yourtale.Items.Shells;

namespace yourtale.Items.Armor.Animula
{
    [AutoloadEquip(EquipType.Legs)] //this doesn't really have anything worth mentioning in it.
    public class AnimulaLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("I think this fixed that arrow to the knee issue?\n" +
                "Grants extra fall speed and a higher fall damage threshold.");
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700;
            Item.value = Item.sellPrice(0, 0, 50, 75);
            Item.rare = ItemRarityID.LightRed;
            Item.defense = 10;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxFallSpeed += 20;
            player.extraFall += 100;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 7);
            recipe.AddIngredient(Mod.Find<ModItem>("LegMold"), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}