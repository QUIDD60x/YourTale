using System;
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
            NPC.damage = Main.rand.Next(1, 100); //lol
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.defense = 100; // the defense of the NPC.
            AnimationType = NPCID.BlueSlime;
            NPC.value = Main.rand.Next(1000, 10000);
            NPC.knockBackResist = 0.3f;
            Banner = NPC.type; //banner currently does NOT work.
            //BannerItem = ModContent.ItemType<PrinceSlimeBanner>();

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
            npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 100, 2, 8));
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCrown, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.SlimeStaff, 15));
        }

    }
}