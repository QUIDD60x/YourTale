using Terraria.Audio;
using yourtale.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.DamageClasses;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace yourtale.Projectiles.Bombs
{
    public class SparklerProj : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.DamageType = ModContent.GetInstance<ExplosiveClass>();
            Projectile.penetrate = 25;
            Projectile.timeLeft = 600;
            Projectile.tileCollide = true;
            Projectile.scale *= 1.25f;
        }

        public override void AI()
        {
            Projectile.velocity.Y +=  0.2f;
            Vector2 position = Projectile.Center;
            Dust dust;
            dust = Dust.NewDustPerfect(position, 6, new Vector2(0f, 0f), 0, new Color(255, 255, 255), 1f); 
            dust.noGravity = true; 
            dust.fadeIn = 0.9767442f;
            dust = Main.dust[Dust.NewDust(position, 2, 5, DustID.Torch, 0f, 0f, 0, new Color(255, 255, 255), 1f)];
            dust.noGravity = true;
            dust.fadeIn = 0.8023256f;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.velocity *= 0.95f;
            return false;
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.velocity *= 0.85f;
            target.AddBuff(BuffID.Burning, 5);
        }
    }
}
