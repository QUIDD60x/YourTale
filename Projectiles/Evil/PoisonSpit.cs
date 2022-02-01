using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace yourtale.Projectiles.Evil
{
    public class PoisonSpit : ModProjectile
    {

        public override void SetDefaults()
        {
            
            projectile.height = 16;
            projectile.width = 16;
            projectile.aiStyle = 1;
            projectile.scale = 2f;
            projectile.hostile = true;
            projectile.ranged = true;
           
            projectile.penetrate = 1;
            projectile.alpha = 128;


        }

        public override void AI()
        {
            
            if (Main.rand.Next(1) == 0)
            {
                int DustID = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y + 2f), projectile.width + 4, projectile.height + 4, 74, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 120, default(Color), 2f);
                Main.dust[DustID].noGravity = true;
            }


        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(mod.BuffType("Melting"), 100);

        }
    }
}
