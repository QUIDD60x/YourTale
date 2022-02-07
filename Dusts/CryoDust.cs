using Terraria;
using Terraria.ModLoader;

namespace yourtale.Dusts
{
    public class CryoDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.7f;
            dust.noGravity = false;
            dust.noLight = false;
            dust.scale *= 1.1f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.25f;
            dust.scale *= 1f;
            float light = 0.50f * dust.scale;
            Lighting.AddLight(dust.position, light, light, light);
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}