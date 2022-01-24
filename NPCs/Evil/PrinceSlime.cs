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

            Main.npcFrameCount[npc.type] = 2;
        }
        public override void SetDefaults()
        {
            npc.lifeMax = Main.rand.Next(20, 75);
            npc.height = 52;
            npc.width = 32;
            npc.aiStyle = 1;
            npc.damage = Main.rand.Next(1, 100);
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.defense = 100;
            animationType = NPCID.BlueSlime;
            npc.value = Main.rand.Next(1000, 10000);
            npc.knockBackResist = 0.3f;
            banner = npc.type;
            bannerItem = ModContent.ItemType<PrinceSlimeBanner>();

        }




        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            if (Main.dayTime && Main.time < 18000.0)
            {
                return 0.5f;
            }
            else 
            {
                return 0.001f;
            }
        }
        public override void NPCLoot()
        {
            Item.NewItem(npc.getRect(), ItemID.Gel, Main.rand.Next(4, 8)); //Main.rand.Next(int, int)); will generate a random amount
            if (Main.rand.Next(7) == 0)
            {
                Item.NewItem(npc.position, ItemID.GoldCrown, 1);
            }
        }

    }
}