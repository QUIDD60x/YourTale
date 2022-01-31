using Terraria;
using Terraria.ModLoader;

namespace yourtale.Dusts
{
    public class CryoDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.2f;
            dust.noGravity = false;
            dust.noLight = true;
            dust.scale *= 1.5f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 3f;
            dust.scale *= 0.60f;
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}