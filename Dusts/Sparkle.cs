using Terraria;
using Terraria.ModLoader;

namespace YourTale.Dusts
{
    public class Sparkle : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.velocity *= 0.4f; //increases the speed in which the dust falls/is launched.
            dust.noGravity = true; //this obviously disables the gravity
            dust.noLight = true; //I don't think it will automatically enable light if this isn't specified, but might as well specify it.
            dust.scale *= 1.5f; //Increases the size of the dust from its pixel art size.
        }

        public override bool Update(Dust dust)
        {
            //most of this stuff is just math mumbo jumbo.
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f; //this will multiply the size over time.
            float light = 0.35f * dust.scale;
            Lighting.AddLight(dust.position, light, light, light); //adds light to the dusts as an aftereffect.
            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}