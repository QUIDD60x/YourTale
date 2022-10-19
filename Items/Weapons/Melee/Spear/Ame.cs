using yourtale.Projectiles.Spears;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using yourtale.Dusts;

namespace yourtale.Items.Weapons.Melee.Spear
{
	public class Ame : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Ame-no-nuhoko");
			Tooltip.SetDefault("A legendary spear, responsible for creating the first land.\nIt's a lot less flimsy than it looks.");

			ItemID.Sets.SkipsInitialUseSound[Item.type] = true;
			ItemID.Sets.Spears[Item.type] = true;
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			// Common Properties
			Item.rare = ItemRarityID.Pink;
			Item.value = Item.sellPrice(gold: 8, silver: 35);

			// Use Properties
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.useAnimation = 12;
			Item.useTime = 12;
			Item.UseSound = SoundID.Item71;
			Item.autoReuse = true;

			// Weapon Properties
			Item.damage = 45;
			Item.knockBack = 1.1f;
			Item.noUseGraphic = true;
			Item.DamageType = DamageClass.Melee;
			Item.noMelee = true;

			// Projectile Properties
			Item.shootSpeed = 2.5f;
			Item.shoot = ModContent.ProjectileType<AmeProj>();
		}

		public override bool CanUseItem(Player player)
		{
			return player.ownedProjectileCounts[Item.shoot] < 1;
		}

		public override bool? UseItem(Player player)
		{
			if (!Main.dedServ && Item.UseSound.HasValue)
			{
				SoundEngine.PlaySound(Item.UseSound.Value, player.Center);
			}

			return null;
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, ModContent.DustType<AncientBrownDust>());
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.DirtBlock, 500)
				.AddIngredient(ItemID.Ruby)
				.AddIngredient(ModContent.ItemType<AncientShard>(), 15)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}