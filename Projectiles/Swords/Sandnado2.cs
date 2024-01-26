using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.Items.Weapons.Melee;
using Terraria.Audio;
using Terraria.UI.Chat;

namespace YourTale.Projectiles.Swords
{
    public class Sandnado2 : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.SandnadoFriendly);
            AIType = ProjectileID.SandnadoFriendly;
            Projectile.penetrate -= 10;
            Projectile.damage = 8;
            Projectile.scale *= 0.75f;
        }
    }
}
