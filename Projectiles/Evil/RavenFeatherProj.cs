using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Items.Weapons;
using Terraria.Audio;

namespace yourtale.Projectiles.Evil
{
	public class RavenFeatherProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.HarpyFeather);
			AIType = ProjectileID.HarpyFeather;
			Projectile.friendly = false;
			Projectile.hostile = true;
		}
	}
}