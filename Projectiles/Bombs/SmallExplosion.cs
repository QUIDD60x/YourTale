using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;
#pragma warning disable ChangeMagicNumberToID // Change magic numbers into appropriate ID values

namespace yourtale.Projectiles.Bombs;

public class SmallExplosion : ModProjectile // Default explosion, you can use this as a base to create different kinds of explosives (which is what i'm using it for aswell).
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
        ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
    }
    public override string Texture => "yourtale/Projectiles/Bombs/ExplosionPng";

    public override void SetDefaults()
    {
        Projectile.width = 50;
        Projectile.height = 50;
        Projectile.aiStyle = 0;
        Projectile.friendly = true;
        Projectile.damage = 19;
        Projectile.DamageType = ModContent.GetInstance<ExplosiveClass>();
        Projectile.penetrate = -1;
        Projectile.timeLeft = 2;
        Projectile.tileCollide = false;
        Projectile.light = 0.45f;
        Projectile.ignoreWater = true;
        Projectile.extraUpdates = 1;
        AIType = ProjectileID.Bullet;
    }

    public override void OnKill(int timeLeft)
    {
        SoundEngine.PlaySound(SoundID.Item14, Projectile.Center);
        Projectile.position.X = Projectile.position.X + Projectile.width / 2f;
        Projectile.position.Y = Projectile.position.Y + Projectile.height / 2f;
        Projectile.position.X = Projectile.position.X - Projectile.width / 2f;
        Projectile.position.Y = Projectile.position.Y - Projectile.height / 2f;

        for (int i = 0; i < 50; i++)
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width,
                Projectile.height, 31, 0f, 0f, 100, default, 3f);
            Main.dust[dust].velocity *= 1.4f;
        }

        for (int i = 0; i < 30; i++)
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width,
                Projectile.height, 6, 0f, 0f, 100, default, 3.5f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= 7f;
            dust = Dust.NewDust(Projectile.position, Projectile.width,
                Projectile.height, 6, 0f, 0f, 100, default, 1.5f);
            Main.dust[dust].velocity *= 3f;
        }

        for (int i = 0; i < 5; i++)
        {
            float scaleFactor9 = 0.5f;
            if (i == 1 || i == 3) scaleFactor9 = 1f;

            for (int j = 0; j < 4; j++)
            {
                int gore = Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center,
                    default,
                    Main.rand.Next(61, 64));

                Main.gore[gore].velocity *= scaleFactor9;
                Main.gore[gore].velocity.X += 1f;
                Main.gore[gore].velocity.Y += 1f;
            }
        }
    }
}