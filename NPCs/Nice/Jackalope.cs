using Terraria;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;

namespace yourtale.NPCs.Nice
{
    public class Jackalope : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jackalope");

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 28;
            NPC.height = 26;
            NPC.damage = 8;
            NPC.defense = 1;
            NPC.lifeMax = 14;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath6;
            NPC.value = 15000f;
            NPC.aiStyle = 3;
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Bunny];
            AIType = NPCID.Bunny;
            AnimationType = NPCID.Bunny;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A very rare rabbit, who also happens to strongly dislike you."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            if (Main.dayTime)
            {
                if(spawnInfo.SpawnTileY >= Main.worldSurface)
                {
                    return 0.09f;
                }
                return 0.001f;
            }

            else
            {
                return 0;
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {

        }
    }
}