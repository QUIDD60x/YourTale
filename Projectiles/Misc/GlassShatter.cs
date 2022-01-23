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

            projectile.height = 15;
            projectile.width = 8;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 2;


        }
        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)

        {
            
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y + Main.rand.Next(-5, 5), ProjectileID.CrystalShard, projectile.damage, projectile.knockBack, Main.myPlayer);
            
            base.OnHitNPC(target, damage, knockBack, crit);
        }
        public override void AI()
        {
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 226, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.2f);
            Main.dust[DustID].noGravity = true;
        }

    }

}

