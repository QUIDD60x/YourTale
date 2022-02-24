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
using yourtale.NPCs.Banners;

namespace yourtale.NPCs.Evil
{
    public class PrinceSlime : ModNPC
    {

        public override void SetStaticDefaults()
        {

            Main.npcFrameCount[npc.type] = 2; //the amount of frames the NPC has, 0 if it doesn't change.
        }
        public override void SetDefaults()
        {
            npc.lifeMax = Main.rand.Next(20, 75); //sets the health between some random numbers, fun to mess with.
            npc.height = 52;
            npc.width = 32; //best to keep these the same size as the sprite.
            npc.aiStyle = 1; //I don't know if i have a list of the AIstyles yet, you can google them tho.
            npc.damage = Main.rand.Next(1, 100); //lol
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.defense = 100; // the defense of the NPC.
            animationType = NPCID.BlueSlime;
            npc.value = Main.rand.Next(1000, 10000);
            npc.knockBackResist = 0.3f;
            banner = npc.type; //banner currently does NOT work.
            bannerItem = ModContent.ItemType<PrinceSlimeBanner>();

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
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(4, 8)); //Main.rand.Next(int, int)); will generate a random amount
            if (Main.rand.Next(7) == 0) //(0) == 0 will guarantee the drop, i think it's just picking a random number and then comparing it? (so this would theoretically be a 1 in 7, or a 14% chance.)
            {
                Item.NewItem(npc.position, ItemID.GoldCrown, 1);
            }
        }

    }
}