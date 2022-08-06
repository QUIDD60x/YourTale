using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace yourtale.Projectiles.Misc
{
    public class GlassShatter : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.height = 15;
            Projectile.width = 8;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 2;


        }
        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
        {
            
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X, Projectile.velocity.Y + Main.rand.Next(-5, 5), ProjectileID.CrystalShard, Projectile.damage, Projectile.knockBack, Main.myPlayer);
            
            base.OnHitNPC(target, damage, knockBack, crit);
        }
        public override void AI()
        {
            int DustID = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width + 4, Projectile.height + 4, 226, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 120, default(Color), 0.2f);
            Main.dust[DustID].noGravity = true;
        }

    }

}

