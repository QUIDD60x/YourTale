/*using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Projectiles.Misc
{
	public class OGCryolisisProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Shot");
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
			projectile.damage = 11;
		}

		public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			if(Main.rand.Next(0, 101) < GetWeaponCrit(player))
			{
				crit = true;
			}
			target.AddBuff(BuffID.Frostburn, 600);
			target.AddBuff(BuffID.Frozen, 60);
		}

		private int GetWeaponCrit(Player player)
		{
			Item item = player.inventory[player.selectedItem];
			int crit = item.crit;
			if(item.melee)
			{
				crit += player.meleeCrit;
			}
			else if(item.magic)
			{
				crit += player.magicCrit;
			}
			else if(item.ranged)
			{
				crit += player.rangedCrit;
			}
			else if(item.thrown)
			{
				crit += player.thrownCrit;
			}
			return crit;
		}

		public override void AI()
		{
			projectile.alpha = 255;
			projectile.frameCounter++;
			if(projectile.frameCounter % 2 == 0)
			{
				int dust = Dust.NewDust(new Vector2(projectile.Center.X, projectile.Center.Y), projectile.width, projectile.height, mod.DustType("IceDust"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[dust].velocity = Vector2.Zero;
				Main.dust[dust].color = new Color(0, 255, 255);
			}
		}

		public override bool PreKill(int timeLeft)
		{
			for(int i = 0; i < 5; i++)
			{
				int dust = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, mod.DustType("IceDust"), 0f, 0f, 0, default(Color), 1f);
				Main.dust[dust].velocity.X = (int)(Main.rand.Next(-8, 9));
				Main.dust[dust].velocity.Y = (int)(Main.rand.Next(-8, 9));
				Main.dust[dust].color = new Color(0, 255, 255);
			}
			projectile.type = 0;
			return true;
		}
	}
}*/