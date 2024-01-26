using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using YourTale.Items;

namespace YourTale
{
	public class Ytplayer : ModPlayer
	{
		public bool tutorialPet = false;
		public bool summonSpiritMinion = false;

		public bool zoneBiome = false;

		public override void ResetEffects()
		{
			tutorialPet = false;
			summonSpiritMinion = false;
		}

		public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
		{

			return new[] {
				new Item(ModContent.ItemType<KnowledgeBook>(), 1),
			};
		}

	}
}