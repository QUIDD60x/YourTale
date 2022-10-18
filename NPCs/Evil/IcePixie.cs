using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Bestiary;
using yourtale.Items.Placeables;
using yourtale.Items.Accessories;
using yourtale.Dusts;

namespace yourtale.NPCs.Evil
{
    public class IcePixie : ModNPC // ModNPC is used for Custom NPCs
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Pixie");
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
            NPC.damage = 14;
            NPC.defense = 6;
            NPC.lifeMax = 85;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath7;
            NPC.value = 388f; //how much money is dropped (why is it a float?)
            NPC.knockBackResist = 0.4f;
            NPC.aiStyle = 22;
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Pixie]; //Main.npcFrameCount[3];
            AIType = NPCID.Pixie; // aiType = 3;
            AnimationType = NPCID.Pixie; // animationType = 3;
            Banner = Item.NPCtoBanner(NPCID.Pixie); //Gets NPC to banner
            BannerItem = Item.BannerToItem(Banner);
            NPC.noGravity = true;
            //npc.DeathSound = mod.GetLegacySoundSlot(SoundType.NPCKilled, "Sounds/NPCHit/Spacey"); EXTRMELY USEFUL
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A weaker pixie. It seems to be uncontained by the forces of light and dark."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return (Main.tile[spawnInfo.PlayerFloorX, spawnInfo.PlayerFloorY].TileType == TileID.SnowBlock).ToInt() * 0.5f;

#pragma warning disable CS0162 // Unreachable code detected
            float chance = 10f;
#pragma warning restore CS0162 // Unreachable code detected
            if (!Main.dayTime)
            {
                chance += 5f;
                
            }
            if (spawnInfo.Player.ZoneSnow)
            {    
               {
                 chance += 8f;
               }
            }
            return chance;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            {
                int dustType = Mod.Find<ModDust>("IceDust").Type;
                int dustIndex = Dust.NewDust(NPC.position, NPC.width, NPC.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }

        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.PixieDust, 0, 2, 8));
        }
    }
}