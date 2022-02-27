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
    [AutoloadEquip(EquipType.Head)] //helmets are where I (and most other mod creators) put the set bonus feature at, although you can put it anywhere it doesn't matter that much.
    public class AnimulaHelmet : ModItem
    {
        public virtual int Speed => 1;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Animula Helm");
            Tooltip.SetDefault("Makes me feel smart!");

        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 700;
            item.value = Item.sellPrice(silver: 12);
            item.rare = ItemRarityID.Green;
            item.defense = 9;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("LifeShard"), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) //This last bit here is the set bonus code.
        { //this checks to see if you have all 3 armours equipped.
            return body.type == mod.ItemType("AnimulaBreastplate") && legs.type == mod.ItemType("AnimulaLeggings");
        }

        public override void UpdateArmorSet(Player player) //here is the armor set upgrade.
        {
            player.setBonus = "You've never felt so alive! Increased all types of speed, and constant swiftness!";
            player.AddBuff(BuffID.Swiftness, 2);
            player.moveSpeed += 3;
            player.jumpSpeedBoost += 2.5f;
            player.extraFall += 11;
        }
    }
}