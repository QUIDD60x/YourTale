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
    [AutoloadEquip(EquipType.Head)]
    public class CryoliteHelmet : ModItem
    {
        public virtual int Speed => 1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryolite Helmet");
            Tooltip.SetDefault("Chilly!");

        }
        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700;

            Item.value = Item.sellPrice(silver: 12);
            Item.rare = ItemRarityID.Blue;

            Item.defense = 7;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("CryoliteBar").Type, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs) //This last bit here is the set bonus code.
        { //this checks to see if you have all 3 armours equipped. You MIGHT be able to add extra equipped gear here like wings and stuff although i haven't personally tried yet.
            return body.type == Mod.Find<ModItem>("CryoliteBreastplate").Type && legs.type == Mod.Find<ModItem>("CryoliteLeggings").Type;
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