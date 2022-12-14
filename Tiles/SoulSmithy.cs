using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using yourtale.Items.Placeables;

namespace yourtale.Tiles
{
    internal class SoulSmithy : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            // Set to True if you'd like your tile to die if hit by lava
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.addTile(Type);

            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Soul Smithy");
            AddMapEntry(new Color(255, 1, 1), name);

            // Can't use this since texture is vertical
            // AnimationFrameHeight = 56;
        }

        // Our textures animation frames are arranged horizontally, which isn't typical, so here we specify animationFrameWidth which we use later in AnimateIndividualTile
        private readonly int animationFrameWidth = 18;

        // This method allows you to determine how much light this block emits
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.99f;
            g = 0.10f;
            b = 0.10f;
        }

        // This method allows you to determine whether or not the tile will draw itself flipped in the world
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            // Flips the sprite if x coord is odd. Makes the tile more interesting
            if (i % 2 == 1)
                spriteEffects = SpriteEffects.FlipHorizontally;
        }

        public override void AnimateIndividualTile(int type, int i, int j, ref int frameXOffset, ref int frameYOffset)
        {
            // Tweak the frame drawn by x position so tiles next to each other are off-sync and look much more interesting
            int uniqueAnimationFrame = Main.tileFrame[Type] + i;
            if (i % 2 == 0)
                uniqueAnimationFrame += 3;
            if (i % 3 == 0)
                uniqueAnimationFrame += 3;
            if (i % 4 == 0)
                uniqueAnimationFrame += 3;
            uniqueAnimationFrame %= 6;

            // frameYOffset = modTile.animationFrameHeight * Main.tileFrame [type] will already be set before this hook is called
            // But we have a horizontal animated texture, so we use frameXOffset instead of frameYOffset
            frameXOffset = uniqueAnimationFrame * animationFrameWidth;
        }

        // This method allows you to change the sound a tile makes when hit
        public override bool KillSound(int i, int j, bool fail)
        {
            // Play the glass shattering sound instead of the normal digging sound if the tile is destroyed on this hit
            if (!fail)
            {
                SoundEngine.PlaySound(SoundID.DD2_BetsyDeath, new Vector2(i, j).ToWorldCoordinates());
                return false;
            }
            return base.KillSound(i, j, fail);
        }

        //TODO: It's better to have an actual class for this example, instead of comments

        // Below is an example completely manually drawing a tile. It shows some interesting concepts that may be useful for more advanced things
        /*public override bool PreDraw(int i, int j, SpriteBatch spriteBatch) {
			// Instead of SetSpriteEffects
			// Flips the sprite if x coord is odd. Makes the tile more interesting
			SpriteEffects effects = SpriteEffects.None;
			if (i % 2 == 1)
				effects = SpriteEffects.FlipHorizontally;
			// Instead of AnimateIndividualTile
			// Tweak the frame drawn by x position so tiles next to each other are off-sync and look much more interesting
			int uniqueAnimationFrame = Main.tileFrame[Type] + i % 6;
			if (i % 2 == 0)
				uniqueAnimationFrame += 3;
			if (i % 3 == 0)
				uniqueAnimationFrame += 3;
			if (i % 4 == 0)
				uniqueAnimationFrame += 3;
			uniqueAnimationFrame %= 6;
			int frameXOffset = uniqueAnimationFrame * animationFrameWidth;
			Tile tile = Main.tile[i, j];
			Texture2D texture = ModContent.Request<Texture2D>("ExampleMod/Content/Tiles/ExampleAnimatedTileTile").Value;
			// If you are using ModTile.SpecialDraw or PostDraw or PreDraw, use this snippet and add zero to all calls to spriteBatch.Draw
			// The reason for this is to accommodate the shift in drawing coordinates that occurs when using the different Lighting mode
			// Press Shift+F9 to change lighting modes quickly to verify your code works for all lighting modes
			Vector2 zero = Main.drawToScreen ? Vector2.Zero : new Vector2(Main.offScreenRange);
			Main.spriteBatch.Draw(
				texture,
				new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero,
				new Rectangle(tile.frameX + frameXOffset, tile.frameY, 16, 16),
				Lighting.GetColor(i, j), 0f, default, 1f, effects, 0f);
			return false; // return false to stop vanilla draw
		}*/

        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            /*
			// Spend 9 ticks on each of 6 frames, looping
			frameCounter++;
			if (frameCounter >= 9) {
				frameCounter = 0;
				if (++frame >= 6) {
					frame = 0;
				}
			}
			// Or, more compactly:
			if (++frameCounter >= 9) {
				frameCounter = 0;
				frame = ++frame % 6;
			}*/

            // Above code works, but since we are just mimicking another tile, we can just use the same value
            frame = Main.tileFrame[TileID.Hellforge];
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 32, ModContent.ItemType<SoulSmithyItem>());
        }
    }
}