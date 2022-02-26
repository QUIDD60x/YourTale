using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;


namespace yourtale.NPCs
{
    public class YourTaleGlobalNPC : GlobalNPC
    { //used to globally add something to NPCs, modded or non modded.
        // i do not know if you can manipulate specific NPCs yet, but i haven't cared enough to look into it.
        public override void NPCLoot(NPC npc)
        {
            if (Main.rand.Next(19) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LifeShard"));
            }
            if (npc.type == NPCID.EyeofCthulhu)
            {
                Item.NewItem((int)nc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CorExitio"), Main.rand.Next(3, 11));
                Item.NewItem((int)nc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ManuscriptEye"), 1);
            } //for specific vanilla NPCs to drop things.
            if (npc.type == NPCID.KingSlime)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CorExitio"), Main.rand.Next(3, 11));
                Item.NewItem((int)nc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ManuscriptSlime"), 1);
            }
            if (npc.type == NPCID.EaterofWorldsHead)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CorExitio"), Main.rand.Next(0, 3));
            }
            if (npc.type == NPCID.BrainofCthulhu)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CorExitio"), Main.rand.Next(3, 11));
                Item.NewItem((int)nc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ManuscriptBOC"), 1);
            }
            if (npc.type == NPCID.Creeper)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("LifeShard"), 0);
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
            }*/ //for random chances, with multiple tries at it.
        }
    }
}