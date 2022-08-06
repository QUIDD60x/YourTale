using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using yourtale.Items;

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

        /*public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)/* tModPorter Suggestion: Return an Item array to add to the players starting items. Use ModifyStartingInventory for modifying them if needed 
        {
            Item item = new Item();
            item.SetDefaults(Mod.Find<ModItem>("KnowledgeBook").Type);
            item.stack = 1;
            items.Add(item);
        }*/
    }
}