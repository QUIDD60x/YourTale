using Terraria.Audio;
using yourtale.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;

namespace yourtale.Projectiles.Bombs
{
    public class PipeBombProj : ModProjectile // TODO: fix nails that spawn.
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<ExplosiveClass>();
            Projectile.penetrate = 10;
            Projectile.timeLeft = 600;
        }

        public override void AI()
        {
            Projectile.velocity.Y +=  0.7f + Projectile.ai[0];
            Dust dust;
            Vector2 position = Projectile.Center;
            dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, DustID.Torch, 0f, -0.6976738f, 0, new Color(255,255,255), 1f)];
            dust.fadeIn = 1.0365117f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {

            }
            else
            {
                Projectile.ai[0] += 0.1f;
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                Projectile.velocity *= 0.70f;
            }
            return false;
        }

        public override void Kill(int timeLeft)
        {
            Vector2 launchVelocity = new(0, 0);
            launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver4);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ModContent.ProjectileType<SmallExplosion>(), 35, Projectile.knockBack, Projectile.owner);
            var proj = Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, Projectile.velocity * 2, ProjectileID.NailFriendly, 40, Projectile.knockBack, Projectile.owner);
            for (int i = proj; i <= 12; i++)
            {
                if (i <= 12)
                {
                    i++;                
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.ai[0] += 0.1f;
            Projectile.velocity *= 0.65f;
        }
    }
}
