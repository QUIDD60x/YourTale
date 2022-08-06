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
            Item.width = 25;
            Item.height = 700;
            Item.value = Item.sellPrice(silver: 12);
            Item.rare = ItemRarityID.Green;
            Item.defense = 9;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) //This last bit here is the set bonus code.
        { //this checks to see if you have all 3 armours equipped.
            return body.type == Mod.Find<ModItem>("AnimulaBreastplate").Type && legs.type == Mod.Find<ModItem>("AnimulaLeggings").Type;
        }

        public override void UpdateArmorSet(Player player) //here is the armor set upgrade.
        {
            player.setBonus = "You've never felt so alive! Increased all types of speed, more health, and constant swiftness!";
            player.AddBuff(BuffID.Swiftness, 2);
            player.moveSpeed += 3;
            player.jumpSpeedBoost += 2.5f;
            player.extraFall += 11;
            player.statLifeMax2 += 40;
        }
    }
}