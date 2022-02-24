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
    [AutoloadEquip(EquipType.Head)] //helmets are where I (and most other mod creators) put the set bonus feature at, although you can put it anywhere it doesn't matter that much.
    public class CryoliteHelmet : ModItem
    {
        public virtual int Speed => 1;

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryolite Helmet");
            Tooltip.SetDefault("Chilly!");

        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 700;
            item.value = Item.sellPrice(silver: 12);
            item.rare = ItemRarityID.Blue;
            item.defense = 7;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CryoliteBar"), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) //This last bit here is the set bonus code.
        { //this checks to see if you have all 3 armours equipped. You MIGHT be able to add extra equipped gear here like wings and stuff although i haven't personally tried yet.
            return body.type == mod.ItemType("CryoliteBreastplate") && legs.type == mod.ItemType("CryoliteLeggings");
        }

        public override void UpdateArmorSet(Player player) //here is the armor set upgrade.
        {
            player.setBonus = "You're chilled out! More defense, protection from cold sources, and an ice barrier!";
            player.endurance += 0.3f; //endurance decreases total damage taken. Check my CheatSheet for a list of the player.status upgrades.
            player.AddBuff(BuffID.IceBarrier, 2);
            player.AddBuff(BuffID.Warmth, 2); //player.AddBuff(mod.BuffType("buffhere"), numberhere); for modded buffs/debuffs.
        }
    }
}