using Terraria;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
#pragma warning disable CS0162

namespace yourtale.NPCs.Evil
{
    public class AncientWarrior : ModNPC // ModNPC is used for Custom NPCs
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Warrior");
        }

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 12;
            NPC.defense = 10;
            NPC.lifeMax = 200;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = 1000f;
            NPC.knockBackResist = 0.75f;
            NPC.aiStyle = 3; //basic walker AI
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Zombie]; //Main.npcFrameCount[3];
            AIType = NPCID.Skeleton; // aiType = 3;
            AnimationType = NPCID.Zombie; // animationType = 3;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            float chance = 0;
            if (spawnInfo.SpawnTileY <= Main.maxTilesY - 200 && spawnInfo.SpawnTileY >= Main.rockLayer * 1.2f)
            {
                chance += 0.02f;
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
            npcLoot.Add(ItemDropRule.Common(ItemID.GoldCrown, 50, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.ZombieArm, 10, 1, 1));
        }
    }
}