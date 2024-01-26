using Terraria.Audio;
using yourtale.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Projectiles.Staffs
{
    public class SparklingBall : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true; //makes it to where it won't hurt you.
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 3; //the amount of things it can penetrate without stopping ;)
            Projectile.timeLeft = 600; //i think this is in milliseconds, 100 is 1 second.
        }

        public override void AI() //how the projectile acts.
        {
            Projectile.velocity.Y += Projectile.ai[0];
            if (Main.rand.NextBool(3)) //summons dust to follow it.
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity) //how the projectile acts upon hitting a solid block.
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {//this basically kills the projectile instantly if it doesn't have enough "stored bounces"
                Projectile.Kill();
            }
            else
            {
                Projectile.ai[0] += 0.1f; //this is what makes it richochet against tiles.
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }
                Projectile.velocity *= 0.75f;
                SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
            }
            return false;
        }

        public override void Kill(int timeLeft) //this is what kills the projectile.
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<Sparkle>(), Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            }
            SoundEngine.PlaySound(SoundID.Item25, Projectile.position);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone) //this is obviously when you hit an entity.
        {
            Projectile.ai[0] += 0.1f;
            Projectile.velocity *= 0.75f;
        }
    }
}