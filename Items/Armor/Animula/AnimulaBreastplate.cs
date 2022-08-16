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
            Tooltip.SetDefault("Almost makes me feel not empty!\n" +
                "Grants an extra 40 health.");
        }

        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700; //height is very large due to the need for it to resemble the sprite, i haven't messed with this so idk if it's nessecary to be exact.
            Item.value = Item.sellPrice(0, 1, 25, 0);
            Item.rare = ItemRarityID.Green;
            Item.defense = 11; //this obviously means the amount of defense it gets
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.Heal(20);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 10);
            recipe.AddIngredient(ItemID.Bone, 15);
            recipe.AddIngredient(ItemID.LifeCrystal, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}