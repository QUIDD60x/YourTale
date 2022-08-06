using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using yourtale;
using yourtale.NPCs;
using Terraria.ModLoader.IO;

namespace yourtale.NPCs
{
    public class YourTaleGlobalNPC : GlobalNPC
    {
            // TODO, npc.netUpdate when this changes, and GlobalNPC gets a SendExtraAI hook
            public bool HasBeenHitByPlayer;

            public override bool InstancePerEntity => true;

            public override bool AppliesToEntity(NPC entity, bool lateInstantiation)
            {
                // after ModNPC has run (lateInstantiation), check if the entity is a townNPC
                return lateInstantiation && entity.townNPC;
            }

            public override void OnHitByProjectile(NPC npc, Projectile projectile, int damage, float knockback, bool crit)
            {
                if (projectile.owner != 255)
                {
                    HasBeenHitByPlayer = true;
                }
            }

            public override void OnHitByItem(NPC npc, Player player, Item item, int damage, float knockback, bool crit)
            {
                HasBeenHitByPlayer = true;
            }

            public override void SaveData(NPC npc, TagCompound tag)
            {
                if (HasBeenHitByPlayer)
                {
                    tag.Add("HasBeenHitByPlayer", true);
                }
            }

            public override void LoadData(NPC npc, TagCompound tag)
            {
                HasBeenHitByPlayer = tag.ContainsKey("HasBeenHitByPlayer");
            }
        
    }


    /* //used to globally add something to NPCs, modded or non modded.
    // i do not know if you can manipulate specific NPCs yet, but i haven't cared enough to look into it.
    public override void OnKill(NPC npc)
    {
        if (Main.rand.NextBool(19))
        {
            Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, Mod.Find<ModItem>("LifeShard").Type);
        }
        if (npc.type == NPCID.EyeofCthulhu)
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
        } //for random chances, with multiple tries at it.
    }*/
}