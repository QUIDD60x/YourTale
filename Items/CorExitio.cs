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
			ItemID.Sets.ItemNoGravity[Item.type] = true;
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
        }

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.value = 850;
			Item.rare = ItemRarityID.Green;

		}
		/*public override void HoldItem(Player player)
        {
			Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
			Vector2 position = Main.LocalPlayer.Center;
			dust = Terraria.Dust.NewDustDirect(position, 30, 30, 60, 0f, 0f, 0, new Color(255,255,255), 0.9883721f);

        }*/

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe(5);
			recipe.AddIngredient(ItemID.Dynamite, 3);
			recipe.AddIngredient(ItemID.Bomb, 10);
			recipe.AddIngredient(ItemID.Grenade, 7);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}