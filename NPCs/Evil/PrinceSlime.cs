﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.Modules;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Design;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;

namespace yourtale.NPCs.Evil
{
    public class PrinceSlime : ModNPC
    {

        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[NPC.type] = 2; //the amount of frames the NPC has, 0 if it doesn't change.
        }
        public override void SetDefaults()
        {
            NPC.lifeMax = Main.rand.Next(20, 75); //sets the health between some random numbers, fun to mess with.
            NPC.height = 52;
            NPC.width = 32; //best to keep these the same size as the sprite.
            NPC.aiStyle = 1; //I don't know if i have a list of the AIstyles yet, you can google them tho.
            NPC.damage = 25;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.defense = 70; // the defense of the NPC.
            AnimationType = NPCID.BlueSlime;
            NPC.value = Main.rand.Next(1500, 10000);
            NPC.knockBackResist = 0.3f;

        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A slime that was exposed to royal jelly, just a bit too late."),
            });
        }

        //the spawn info for them.
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        { //how these work are pretty simple. You do a If: Then= statement, and just add conditions.
            //so as an example:
            if (Main.dayTime && Main.time < 18000.0) //18000 is middle of the day i think.
            {//if: It's daytime
                return 0.09f;
            }//Then: return a chance of 0.09f.
            //There is also an exception piece
            else 
            {//if that requirement isn't met Then:
                return 0.001f;
            } //Then: return a chance of 0.001f.
        } //there is more info on spawning on tmodloaders github somewhere, i'll probably link it in my cheatsheet soon maybe, just google it.
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 1, 2, 8));
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCrown, 40));
            npcLoot.Add(ItemDropRule.Common(ItemID.SlimeStaff, 20));
        }

    }
}