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
    [AutoloadEquip(EquipType.Body)] // for that function when you can put the armour on in one click.
    public class CryoliteBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Reminds me of winter!");
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700; //height is very large due to the need for it to resemble the sprite, i haven't messed with this so idk if it's nessecary to be exact.
            Item.value = Item.sellPrice(silver: 14);
            Item.rare = ItemRarityID.Blue;
            Item.defense = 9; //this obviously means the amount of defense it gets
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("CryoliteBar").Type, 11);
            recipe.AddIngredient(Mod.Find<ModItem>("IceHeart").Type, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}