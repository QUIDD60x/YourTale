using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace yourtale.Projectiles.Arrows
{
    public class ChargedArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            
            projectile.height = 32;
            projectile.width = 14;
            projectile.aiStyle = 1;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.penetrate = 3;


        }
        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)

        {
            
                Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y + Main.rand.Next(0, 0), mod.ProjectileType("GlassShatter"), projectile.damage, projectile.knockBack, Main.myPlayer);
            Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, projectile.velocity.X, projectile.velocity.Y + Main.rand.Next(0, 0), mod.ProjectileType("GlassShatter"), projectile.damage, projectile.knockBack, Main.myPlayer);


        }
        public override void AI()
        {
            int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 2, projectile.height + 2, 226, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.2f, 120, default(Color), 0.5f);
            Main.dust[DustID].noGravity = true;
        }
        
    }

}

