using Terraria.Audio;
using yourtale.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Projectiles.Swords
{
    public class LahatCherebProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.friendly = true;
            Projectile.CloneDefaults(ProjectileID.CultistBossFireBall);
            Projectile.penetrate = 3;
        }
    }
}