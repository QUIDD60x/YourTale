using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YourTale.Projectiles.Evil
{
    public class PoisonSpit : ModProjectile
    {

        public override void SetDefaults()
        {
            
            Projectile.height = 16;
            Projectile.width = 16;
            Projectile.aiStyle = 1;
            Projectile.scale = 2f;
            Projectile.hostile = true;
            Projectile.DamageType = DamageClass.Ranged;
           
            Projectile.penetrate = 1;
            Projectile.alpha = 128;


        }

        public override void AI()
        {
            
            if (Main.rand.NextBool(1))
            {
                int DustID = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width + 4, Projectile.height + 4, 74, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 120, default, 2f);
                Main.dust[DustID].noGravity = true;
            }


        }
        public override void OnHitPlayer(Player target, Player.HurtInfo info)
        {
            target.AddBuff(Mod.Find<ModBuff>("Melting").Type, 100);

        }
    }
}
