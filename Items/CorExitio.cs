using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.Graphics;
using Microsoft.Xna.Framework;

namespace yourtale.Items
{
	public class CorExitio : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("Essence of destruction, very volatile!"); 
			ItemID.Sets.ItemNoGravity[item.type] = true;
            ItemID.Sets.AnimatesAsSoul[item.type] = true;
            Main.RegisterItemAnimation(item.type, new DrawAnimationVertical(5, 4));
        }

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.value = 850;
			item.rare = ItemRarityID.Green;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Dynamite, 3);
			recipe.AddIngredient(ItemID.Bomb, 10);
			recipe.AddIngredient(ItemID.Grenade, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this, 5);
			recipe.AddRecipe();
		}
	}
}