using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using System.IO;
using Terraria.GameContent.Bestiary;

namespace yourtale.NPCs.Evil
{
    public class DuneGolem : ModNPC // ModNPC is used for Custom NPCs
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                // Influences how the NPC looks in the Bestiary
                Velocity = 1f // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
            };
            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, value);
        }

        public override void SetDefaults()
        {
            NPC.width = 42;
            NPC.height = 54;
            NPC.damage = 35;
            NPC.defense = 8;
            NPC.lifeMax = Main.rand.Next(200, 350);
            NPC.HitSound = SoundID.NPCHit41;
            NPC.DeathSound = SoundID.NPCDeath43;
            NPC.value = 100f;
            NPC.knockBackResist = 0.75f;
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.RockGolem];
            AnimationType = NPCID.RockGolem;
            AIType = NPCID.RockGolem;
            NPC.aiStyle = 3;
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Desert,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A sandier counterpart to the rock golem."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySandCritter.Chance * 2f;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust dust;  
                Vector2 position = NPC.Center; 
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, DustID.DynastyWall, 0f, 0f, 0, new Color(255,255,255), 1f)]; 
                dust.noGravity = true; 
                dust.fadeIn = 1.8139534f;
            }

        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.FossilOre, 1, 1, 7));
            npcLoot.Add(ItemDropRule.Common(ItemID.SandBlock, 10, 4, 9));
            npcLoot.Add(ItemDropRule.Common(ItemID.Waterleaf, 15, 3, 7));
        }
    }
}