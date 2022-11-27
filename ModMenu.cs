using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.ID;

namespace yourtale
{
	public class ExampleModMenu : ModMenu
	{
		// I'm not going to be using any special textures simply because I can't draw.
		// private const string menuAssetPath = "yourtale/Assets/Textures/Menu"; // This Creates a constant variable representing the texture path, so we don't have to write it out multiple times

		public override Asset<Texture2D> Logo => ModContent.Request<Texture2D>($"yourtale/icon");

		// public override Asset<Texture2D> SunTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/ExampleSun");

		// public override Asset<Texture2D> MoonTexture => ModContent.Request<Texture2D>($"{menuAssetPath}/ExampliumMoon");

		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/YourTaleTheme");

		// public override ModSurfaceBackgroundStyle MenuBackgroundStyle => ModContent.GetInstance<ExampleSurfaceBackgroundStyle>();

		public override string DisplayName => "[c/5EAFF1:Y][c/74acda:o][c/82abcc:u][c/96a9b8:r] [c/c1a48d:T][c/c1a48d:a][c/e7a067:l][c/e7a067:e] menu";
		// I think the amount of raw text data this contains literally pushes the menu switch button to the side. Looks like there's a new bug for the Tmodloader devs to fix?

		public new bool IsSelected => MenuLoader.CurrentMenu == this;

		public override void OnSelected()
		{
			SoundEngine.PlaySound(SoundID.Item9); // Plays a sound when this ModMenu is selected
		}

		public override bool PreDrawLogo(SpriteBatch spriteBatch, ref Vector2 logoDrawCenter, ref float logoRotation, ref float logoScale, ref Color drawColor)
		{
			drawColor = Main.DiscoColor; // Changes the draw color of the logo
			logoScale *= 2.2f;
			return true;
			
		}
	}
}