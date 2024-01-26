﻿using Terraria.Audio;
using YourTale.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.DamageClasses;
using System.Security.Cryptography.X509Certificates;

namespace YourTale.Projectiles.Bombs
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
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                Projectile.velocity *= 0.70f;
            }
            return false;
        }

#pragma warning disable CS0672 // Member overrides obsolete member
        public override void OnKill(int timeLeft)
#pragma warning restore CS0672 // Member overrides obsolete member
        {
            Vector2 launchVelocity = new(0, 2);
            launchVelocity = launchVelocity.RotatedBy(MathHelper.PiOver4);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity * 0, ModContent.ProjectileType<SmallExplosion>(), 35, Projectile.knockBack, Projectile.owner);
            Projectile.NewProjectile(Projectile.InheritSource(Projectile), Projectile.Center, launchVelocity, ProjectileID.WoodenArrowFriendly, 35, Projectile.knockBack, Projectile.owner);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.ai[0] += 0.1f;
            Projectile.velocity *= 0.65f;
        }
    }
}
