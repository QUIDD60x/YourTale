using Terraria;
using Terraria.ModLoader;

namespace yourtale.Dusts
{
    public class AncientBrownDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.7f;
            dust.noGravity = true;
            dust.noLight = false;
            dust.scale *= 1.7f;
        }

        public override bool Update(Dust dust)
        {

            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.35f;
            dust.scale *= 0.99f;
            float light = 1 * dust.scale;
            Lighting.AddLight(dust.position, light, light, light);
            if (dust.scale < 0.3f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}