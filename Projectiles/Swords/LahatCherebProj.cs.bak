using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Items.Weapons.Melee;
using Terraria.Audio;

namespace yourtale.Projectiles.Swords
{
	public class LahatCherebProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ExplosiveBullet);

			AIType = ProjectileID.ChlorophyteBullet;

			Projectile.penetrate += 5;
		}

		public override void Kill(int timeLeft)
		{
			Vector2 launchVelocity = new Vector2(-4, 0); // Create a velocity moving the left.
			for (int i = 0; i < 4; i++)
			{
				// Every iteration, rotate the newly spawned projectile by the equivalent 1/4th of a circle (MathHelper.PiOver4)
				// (Remember that all rotation in Terraria is based on Radians, NOT Degrees!)
				launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver4);

				// Spawn a new projectile with the newly rotated velocity, belonging to the original projectile owner. The new projectile will inherit the spawning source of this projectile.
				Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<CultFireBallClone>(), Projectile.damage / 2, Projectile.knockBack, Projectile.owner);
			}
		}


		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(Main.rand.NextBool() ? SoundID.DD2_BetsyFireballImpact : SoundID.DD2_BetsyWindAttack, Projectile.position);
			return base.OnTileCollide(oldVelocity);
		}
	}
}