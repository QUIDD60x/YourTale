using Terraria;
using Terraria.ModLoader;

namespace yourtale.Dusts
{
    public class AncientGoldDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.6f;
            dust.noGravity = false; 
            dust.noLight = false; 
            dust.scale *= 0.3f; 
        }

        public override bool Update(Dust dust)
        {
            
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.7f; 
            float light = 0.35f * dust.scale;
            Lighting.AddLight(dust.position, light, light, light); 
            if (dust.scale < 0.1f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}