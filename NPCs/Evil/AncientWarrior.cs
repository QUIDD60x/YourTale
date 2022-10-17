using Terraria;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;

namespace yourtale.NPCs.Evil
{
    public class AncientWarrior : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ancient Warrior");
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

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            float chance = 0.8f;

            if (spawnInfo.SpawnTileY <= Main.maxTilesY -200 && spawnInfo.SpawnTileY >= Main.rockLayer)
            {
                chance += 0.21f;
            }

            return chance;
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Bone, 10, 3, 9));
            npcLoot.Add(ItemDropRule.Common(ItemID.BoneSword, 30));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("AncientShard").Type, 1, 2, 5));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("LifeShard").Type, 5, 2, 6));
        }
    }
}