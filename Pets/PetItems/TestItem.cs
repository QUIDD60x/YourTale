using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using YourTale.Pets.PetBuffs;
using YourTale.Pets.PetProjectiles;

namespace YourTale.Pets.PetItems
{
	public class TestItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// Names and descriptions of all ExamplePetX classes are defined using .hjson files in the Localization folder
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.ZephyrFish); // Copy the Defaults of the Zephyr Fish Item.

			Item.shoot = ModContent.ProjectileType<TestProj>(); // "Shoot" your pet projectile.
			Item.buffType = ModContent.BuffType<TestBuff>(); // Apply buff upon usage of the Item.
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600);
			}
		}
	}
}