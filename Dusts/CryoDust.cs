using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace yourtale.Dusts
{
	public class CryoDust : ModDust
	{
		public override void OnSpawn(Dust dust)
		{
			//Dust dust;
			// You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
			Vector2 position = Main.LocalPlayer.Center;
			dust = Terraria.Dust.NewDustDirect(position, 9, 4, 10, 0f, 0f, 0, new Color(255, 255, 255), 1.162791f);
			dust.noLight = true;
			dust.fadeIn = 0.9767442f;

		}
	}
}
