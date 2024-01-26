using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.Items.Weapons.Melee;
using Terraria.Audio;

namespace YourTale.Projectiles.Swords
{
	public class CultFireBallClone : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.HellfireArrow);
			AIType = ProjectileID.CultistBossFireBall;
			Projectile.friendly = true;
		}

		public override void OnKill(int timeLeft)
		{
			Vector2 launchVelocity = new Vector2(-4, 0); // Create a velocity moving the left.
			for (int i = 0; i < 4; i++)
			{
				launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver4);
				Projectile.friendly = true;
			}
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			SoundEngine.PlaySound(Main.rand.NextBool() ? SoundID.DD2_ExplosiveTrapExplode : SoundID.DD2_KoboldExplosion, Projectile.position);

			return base.OnTileCollide(oldVelocity);
		}
	}
}