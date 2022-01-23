using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;

namespace yourtale
{
    public class ytplayer : ModPlayer
    {
        public bool tutorialPet = false;
        public bool summonSpiritMinion = false;

        public bool zoneBiome = false;

        public override void ResetEffects()
        {
            tutorialPet = false;
            summonSpiritMinion = false;
        }

        public override void SetupStartInventory(IList<Item> items)
        {
            Item item = new Item();
            item.SetDefaults(mod.ItemType("KnowledgeBook"));
            item.stack = 1;
            items.Add(item);
        }
    }
}