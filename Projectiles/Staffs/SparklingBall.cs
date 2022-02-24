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
            projectile.width = 16;
            projectile.height = 16;
            projectile.friendly = true; //makes it to where it won't hurt you.
            projectile.magic = true;
            projectile.penetrate = 3; //the amount of things it can penetrate without stopping ;)
            projectile.timeLeft = 600; //i think this is in milliseconds, 100 is 1 second.
        }

        public override void AI() //how the projectile acts.
        {
            projectile.velocity.Y += projectile.ai[0];
            if (Main.rand.NextBool(3)) //summons dust to follow it.
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Sparkle>(), projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f);
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity) //how the projectile acts upon hitting a solid block.
        {
            projectile.penetrate--;
            if (projectile.penetrate <= 0)
            {//this basically kills the projectile instantly if it doesn't have enough "stored bounces"
                projectile.Kill();
            }
            else
            {
                projectile.ai[0] += 0.1f; //this is what makes it richochet against tiles.
                if (projectile.velocity.X != oldVelocity.X)
                {
                    projectile.velocity.X = -oldVelocity.X;
                }
                if (projectile.velocity.Y != oldVelocity.Y)
                {
                    projectile.velocity.Y = -oldVelocity.Y;
                }
                projectile.velocity *= 0.75f;
                Main.PlaySound(SoundID.Item10, projectile.position);
            }
            return false;
        }

        public override void Kill(int timeLeft) //this is what kills the projectile.
        {
            for (int k = 0; k < 5; k++)
            {
                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, ModContent.DustType<Sparkle>(), projectile.oldVelocity.X * 0.5f, projectile.oldVelocity.Y * 0.5f);
            }
            Main.PlaySound(SoundID.Item25, projectile.position);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit) //this is obviously when you hit an entity.
        {
            projectile.ai[0] += 0.1f;
            projectile.velocity *= 0.75f;
        }
    }
}