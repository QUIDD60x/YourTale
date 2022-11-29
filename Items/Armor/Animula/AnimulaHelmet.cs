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
    [AutoloadEquip(EquipType.Head)] //helmets are where I (and most other mod creators) put the set bonus feature at, although you can put it anywhere it doesn't matter that much.
    public class AnimulaHelmet : ModItem
    {
        public virtual int Speed => 1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Animula Helm");
            Tooltip.SetDefault("Makes me feel smart!\n" +
                "That grants extra max movement speed, for some reason.");

        }
        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700;

            Item.value = Item.sellPrice(0, 0, 85, 25);
            Item.rare = ItemRarityID.LightRed;

            Item.defense = 9;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.maxRunSpeed += 20;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("LifeShard").Type, 8);
            recipe.AddIngredient(Mod.Find<ModItem>("HelmMold"), 1);
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
            player.moveSpeed += 1.2f;
            player.jumpSpeedBoost += 1.5f;
            player.statLifeMax2 += 60;
        }
    }
}