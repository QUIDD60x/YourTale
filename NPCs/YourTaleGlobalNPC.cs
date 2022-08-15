using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace yourtale.NPCs
{
    public class YourTaleGlobalNPC : GlobalNPC
    {
        /*if (npc.type == NPCID.EyeofCthulhu)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("CorExitio").Type, Main.rand.Next(3, 11));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("ManuscriptEye").Type, 1);
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Boss1_Otherworldly");
        } //for specific vanilla NPCs to drop things.
        if (npc.type == NPCID.KingSlime)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("CorExitio").Type, Main.rand.Next(3, 11));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("ManuscriptSlime").Type, 1);
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Boss1_Otherworldly");
        }
        if (npc.type == NPCID.EaterofWorldsHead)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("CorExitio").Type, Main.rand.Next(0, 3));
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Boss1_Otherworldly");
        }
        if (npc.type == NPCID.BrainofCthulhu)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("CorExitio").Type, Main.rand.Next(3, 11));
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("ManuscriptBOC").Type, 1);
            //music = mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Boss1_Otherworldly");
        }
        if (npc.type == NPCID.Creeper)
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("LifeShard").Type, 0);
        }


        /*if (npc.type == NPCID.EyeofCthulhu)
        {
            if (Main.rand.Next(2) == 0)
            { // 1 in 2 chance
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bababooey"));
            }
        }
        else if (npc.type == NPCID.Zombie)
        {
            if (Main.rand.Next(5) == 0)
            { //1 in 5 chance
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Bababooey2"));
            }
        } //for random chances, with multiple tries at it.*/
    }

}