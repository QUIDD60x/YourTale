using Terraria.Audio;
using yourtale.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Projectiles.Swords
{
    public class Empty : ModProjectile // I use this to have an empty projectile, mainly for using random shoot chances for projectiles. (I don't know any other way atm lol)
    {
        public override void SetDefaults()
        {
            Projectile.width = 1;
            Projectile.height = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 1;
            Projectile.damage = 0;
        }
    }
}