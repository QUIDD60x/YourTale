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
            
            Projectile.height = 32;
            Projectile.width = 14;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 3;


        }
        public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)

        {
            
                Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X, Projectile.velocity.Y + Main.rand.Next(0, 0), Mod.Find<ModProjectile>("GlassShatter").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer);
            Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, Projectile.velocity.X, Projectile.velocity.Y + Main.rand.Next(0, 0), Mod.Find<ModProjectile>("GlassShatter").Type, Projectile.damage, Projectile.knockBack, Main.myPlayer);


        }
        public override void AI()
        {
            int DustID = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width + 2, Projectile.height + 2, 226, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.2f, 120, default(Color), 0.5f);
            Main.dust[DustID].noGravity = true;
        }
        
    }

}

