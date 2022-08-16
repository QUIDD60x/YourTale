using Terraria.Audio;
using yourtale.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Projectiles.Swords
{
    public class ChrysaorProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.ChlorophyteBullet);
            Projectile.height = 20;
            Projectile.width = 20;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //this is obviously when you hit an entity.
        {
            Projectile.velocity *= 1.5f;
        }
    }
}