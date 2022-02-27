using Terraria;
using yourtale.Dusts;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.NPCs.Evil
{
    public class ZombKing : ModNPC // ModNPC is used for Custom NPCs
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("King Zombie");
        }

        public override void SetDefaults()
        {
            /* Removed as of 0.10
            //npc.name = "Tutorial Zombie";
            //npc.displayName = "Tutorial Zombie";
            */
            npc.width = 18;
            npc.height = 40;
            npc.damage = 12;
            npc.defense = 10;
            npc.lifeMax = 200;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 100f;
            npc.knockBackResist = 0.75f;
            npc.aiStyle = 3; //basic walker AI
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Zombie]; //Main.npcFrameCount[3];
            aiType = NPCID.Zombie; // aiType = 3;
            animationType = NPCID.Zombie; // animationType = 3;
            banner = Item.NPCtoBanner(NPCID.Zombie); //Gets NPC to banner
            bannerItem = Item.BannerToItem(banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.3f; //Might have fixed issue with spawns.

            float chance = 0f;
            if(!Main.dayTime)
            {
                chance += .05f;
                if(spawnInfo.spawnTileY <= Main.rockLayer && spawnInfo.spawnTileY >= Main.worldSurface * 0.15)
                {
                    chance += .1f;
                }

            }
            return chance;
        }
        /*public override void HitEffect(int hitDirection, double damage) // NOT ADDED but saving for if needed later, this is how you add dust. Thanks for making me add this Jenova.
        {
            for (int i = 0; i < 10; i++)
            {
                int dustType = mod.DustType("Sparkle");
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }

        }*/
        public override void NPCLoot() //do mod.ItemType instead of ItemID for modded items
        {
            /*Will make NPC always drop entered loot
            Item.NewItem(npc.position, ItemID.Gel, 100);*/
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.position, ItemID.ZombieArm, 1);
            }
            if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(npc.position, ItemID.Shackle, 1);
            }
            //will only drop 25% of the time based on integer added
            if (Main.rand.Next(3) == 0)
            {
                Item.NewItem(npc.position, ItemID.GoldCrown, 1);
            }
            //Will drop only in Hardmode
            if(Main.hardMode)
            {
                Item.NewItem(npc.position, ItemID.GoldBar, Main.rand.Next(1, 6));
            }
        }
    }
}