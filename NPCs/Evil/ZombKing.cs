using Terraria;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

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
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 12;
            NPC.defense = 10;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 100f;
            NPC.knockBackResist = 0.75f;
            NPC.aiStyle = 3; //basic walker AI
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie]; //Main.npcFrameCount[3];
            AIType = NPCID.Zombie; // aiType = 3;
            AnimationType = NPCID.Zombie; // animationType = 3;
            Banner = Item.NPCtoBanner(NPCID.Zombie); //Gets NPC to banner
            BannerItem = Item.BannerToItem(Banner);
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldNightMonster.Chance * 0.3f; //Might have fixed issue with spawns.

#pragma warning disable CS0162 // Unreachable code detected
            float chance = 0.1f;
#pragma warning restore CS0162 // Unreachable code detected
            if (!Main.dayTime)
            {
                chance += .05f;
                if (spawnInfo.SpawnTileY <= Main.rockLayer && spawnInfo.SpawnTileY >= Main.worldSurface * 0.15)
                {
                    chance += .1f;
                }

            }
            return chance;
        }
        /*public override void HitEffect(int hitDirection, double damage) // NOT ADDED but saving for if needed later, this is how you add dust.
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
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            base.ModifyNPCLoot(npcLoot);

            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCrown, 50));
            npcLoot.Add(ItemDropRule.Common(ItemID.ZombieArm, 10));
        }
    }
}