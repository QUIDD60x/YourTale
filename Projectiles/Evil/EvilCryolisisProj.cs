using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Projectiles.Evil
{
	public class EvilCryolisisProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryo Shot");
		}

		public override void SetDefaults()
		{
			projectile.penetrate = 1;
			projectile.aiStyle = 1;
			projectile.width = 16;
			projectile.height = 16;
			projectile.ignoreWater = true;
			projectile.hostile = true;
			projectile.timeLeft = 9999;
			projectile.tileCollide = true;
			projectile.noDropItem = true;
			projectile.alpha = 255;
			projectile.extraUpdates = 100;
			aiType = ProjectileID.Bullet;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			if (Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
			}
			target.AddBuff(BuffID.Frostburn, 600);
		}

		private int GetWeaponCrit(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			int crit = item.crit;
			if (item.melee)
			{
				crit += player.meleeCrit;
			}
			else if (item.magic)
			{
				crit += player.magicCrit;
			}
			else if (item.ranged)
			{
				crit += player.rangedCrit;
			}
			else if (item.thrown)
			{
				crit += player.thrownCrit;
			}
			return crit;
		}

		public override void AI()
		{
			projectile.alpha = 255;
			projectile.frameCounter++;
			if (projectile.frameCounter % 2 == 0)
			{
					Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
				Vector2 position = Main.LocalPlayer.Center;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position + projectile.velocity, 30, 30, 76, 0f, 0.6976748f, 0, new Color(255,255,255), 0.8f)];
				dust.noLight = true;
				dust.fadeIn = 0.5232558f;

			}
		}

		public override bool PreKill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust dust;
				// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
				Vector2 position = Main.LocalPlayer.Center;
				dust = Main.dust[Terraria.Dust.NewDust(projectile.position + projectile.velocity, 30, 30, 76, 0f, 0.6976748f, 0, new Color(255,255,255), 0.8f)];
				dust.noLight = true;
				dust.fadeIn = 0.5232558f;
			}
			projectile.type = 0;
			return true;
		}
	}
}