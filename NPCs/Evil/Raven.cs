using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;
using YourTale.Items.Placeables;
using YourTale.Items.Accessories;
using YourTale.Dusts;
using YourTale.Items;

namespace YourTale.NPCs.Evil
{
    public class Raven : ModNPC
    {

        public override void SetDefaults()
        {
            NPC.width = 18;
            NPC.height = 40;
            NPC.damage = 12;
            NPC.defense = 2;
            NPC.lifeMax = 35;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = 50f;
            NPC.knockBackResist = 0.4f;
            NPC.aiStyle = 22;
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Raven];
            AIType = NPCID.Raven;
            AnimationType = NPCID.Raven;
            Banner = Item.NPCtoBanner(NPCID.Raven);
            BannerItem = Item.BannerToItem(Banner);
            NPC.noGravity = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            float chance = 0;
            if (!Main.dayTime)
            {
                chance += 0.12f;

            }
            if (spawnInfo.Player.ZoneGraveyard)
            {
                {
                    chance += 0.6f;
                }
            }
            return chance;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RavenFeather>(), 1, 3, 7));
        }
    }
}