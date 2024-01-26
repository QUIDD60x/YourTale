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
using YourTale.Items.Shells;

namespace YourTale.Items.Armor.Ambrosia
{
    [AutoloadEquip(EquipType.Body)]
    public class AmbrosiaChest : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700;

            Item.value = 25000;
            Item.rare = ItemRarityID.LightRed;

            Item.defense = 11;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Generic) *= 1.05f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("Ambrosia").Type, 5);
            recipe.AddIngredient(Mod.Find<ModItem>("BreastMold"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}