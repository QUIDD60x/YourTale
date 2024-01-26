using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace YourTale.Projectiles.Evil
{
    public class TreeBlast : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.DeerclopsIceSpike);
            AIType = ProjectileID.SharpTears;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate += 4;
            Projectile.tileCollide = false;
            Projectile.damage = 5;
            Projectile.width = 45;
            Projectile.height = 200;
        }
    }
}