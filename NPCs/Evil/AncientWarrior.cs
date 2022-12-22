using Terraria;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;

namespace yourtale.NPCs.Evil
{
    public class AncientWarrior : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Warrior");

            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 35;
            NPC.defense = 7;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 1000f;
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3;
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.ArmoredSkeleton];
            AIType = NPCID.Skeleton;
            AnimationType = NPCID.Zombie;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("An old warrior who's somehow escaped the dungeon. They seem to hold ancient artifacts..."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            float chance = 0f;

            if (spawnInfo.SpawnTileY <= Main.rockLayer && spawnInfo.SpawnTileY >= Main.worldSurface)
            {
                chance += 0.07f;
            }
            if (spawnInfo.SpawnTileY >= Main.maxTilesY - 200 && spawnInfo.SpawnTileY <= Main.rockLayer)
            {
                chance += 0.10f;
            }

            return chance;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Bone, 10, 3, 9));
            npcLoot.Add(ItemDropRule.Common(ItemID.BoneSword, 30));
            npcLoot.Add(ItemDropRule.Common(ItemID.AncientNecroHelmet, 10));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("AncientShard").Type, 1, 2, 5));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("LifeShard").Type, 5, 2, 6));
        }
    }
}