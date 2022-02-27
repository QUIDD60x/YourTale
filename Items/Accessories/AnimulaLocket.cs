using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Accessories
{
	public class AnimulaLocket : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Increased move speed, jump power, and more health.");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.accessory = true;
			item.rare = ItemRarityID.Green;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.moveSpeed += 1.5f;
			player.jumpSpeedBoost += 1.5f;
			player.extraFall += 7;
			player.statLifeMax2 += 20;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs) //This last bit here is the set bonus code.
		{ //this checks to see if you have all 3 armours equipped.
			return body.type == mod.ItemType("AnimulaBreastplate") && legs.type == mod.ItemType("AnimulaLeggings") && legs.type == mod.ItemType("AnimulaHelmet");
		}

		public override void UpdateArmorSet(Player player) //here is the armor set upgrade.
		{
			player.setBonus = "It almost feels purified! \nIncreases ALL stats.";
			player.moveSpeed += 4;
			player.jumpSpeedBoost += 3.5f;
			player.extraFall += 20;
			player.meleeDamage += 0.7f;
			player.thrownDamage += 0.7f;
			player.rangedDamage += 0.7f;
			player.magicDamage += 0.7f;
			player.minionDamage += 0.7f;
			player.endurance += 2f;
			player.pickSpeed -= 2f;
		}
	}
}