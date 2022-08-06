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
			Projectile.penetrate = 1;
			//projectile.aiStyle = 1;
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.ignoreWater = true;
			Projectile.hostile = true;
			Projectile.timeLeft = 1200;
			Projectile.tileCollide = true;
			Projectile.noDropItem = true;
			Projectile.alpha = 255;
			Projectile.extraUpdates = 100;
			AIType = ProjectileID.Bullet;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[Projectile.owner];
			if (Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
				target.AddBuff(BuffID.Frostburn, 60);
			}
			
		}

		private int GetWeaponCrit(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			int crit = item.crit;
			if (item.CountsAsClass(DamageClass.Melee))
			{
				crit += player.GetCritChance(DamageClass.Generic);
			}
			else if (item.CountsAsClass(DamageClass.Magic))
			{
				crit += player.GetCritChance(DamageClass.Magic);
			}
			else if (item.CountsAsClass(DamageClass.Ranged))
			{
				crit += player.GetCritChance(DamageClass.Ranged);
			}
			else if (item.CountsAsClass(DamageClass.Throwing))
			{
				crit += player.GetCritChance(DamageClass.Throwing);
			}
			return crit;
		}

		public override void AI()
		{
			Projectile.alpha = 255;
			Projectile.frameCounter++;
			if (Projectile.frameCounter % 2 == 0)
			{
					Dust dust;
				Vector2 position = Main.LocalPlayer.Center;
				dust = Main.dust[Terraria.Dust.NewDust(Projectile.position + Projectile.velocity, 30, 30, 76, 0f, 0.6976748f, 0, new Color(255,255,255), 0.8f)];
				dust.noLight = true;
				dust.fadeIn = 0.5232558f;

			}
		}

		public override bool PreKill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				Dust dust;
				Vector2 position = Main.LocalPlayer.Center;
				dust = Main.dust[Terraria.Dust.NewDust(Projectile.position + Projectile.velocity, 30, 30, 76, 0f, 0.6976748f, 0, new Color(255,255,255), 0.8f)];
				dust.noLight = true;
				dust.fadeIn = 0.5232558f;
			}
			Projectile.type = 0;
			return true;
		}
	}
}