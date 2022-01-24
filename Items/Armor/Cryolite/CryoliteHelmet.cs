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
            base.SetStaticDefaults();
            DisplayName.SetDefault("Cryolite Helmet");
            Tooltip.SetDefault("Chilly!");

        }
        public override void SetDefaults()
        {
            item.width = 25;
            item.height = 700;
            item.value = Item.sellPrice(silver: -1);
            item.rare = ItemRarityID.White;
            item.defense = 7;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CryoliteBar"), 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == mod.ItemType("CryoliteBreastplate") && legs.type == mod.ItemType("CryoliteLeggings");
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "You're chilled out! life regen starts faster and more defense.";
            player.lifeRegenTime += 1000;
            player.endurance += 0.3f;
            player.AddBuff(BuffID.IceBarrier, 2);
            player.AddBuff(BuffID.Warmth, 2);
        }
    }
}