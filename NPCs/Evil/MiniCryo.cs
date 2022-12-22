using Terraria;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Microsoft.Xna.Framework;
using System.IO;
using yourtale.Projectiles.Evil;

namespace yourtale.NPCs.Evil
{
    public class MiniCryo : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice elemental");

            NPCID.Sets.NPCBestiaryDrawModifiers value = new(0)
            {
                Velocity = 1f
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
            NPC.HitSound = SoundID.Item25;
            NPC.DeathSound = SoundID.Item4;
            NPC.value = 755f;
            NPC.knockBackResist = 0.2f;
            NPC.aiStyle = 5;
            AIType = NPCID.Crimera;
            NPC.noGravity = true;
        }
        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // We can use AddRange instead of calling Add multiple times in order to add multiple items at once
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Times.DayTime,
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Snow,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("A shard of ice imbued with some kind of mystic energy. A small fraction of what could be."),
            });
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {

            float chance = 0;

            if (Main.tile[spawnInfo.PlayerFloorX, spawnInfo.PlayerFloorY].TileType == TileID.SnowBlock)
            {
                chance += 0.11f;
            }

            return chance;
        }
        private int attackCounter;
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(attackCounter);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            attackCounter = reader.ReadInt32();
        }
        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                Vector2 direction = (NPC.Center).SafeNormalize(Vector2.UnitX);
                direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

                if (attackCounter > 0)
                {
                    attackCounter--; // tick down the attack counter.
                }

                Player target = Main.player[NPC.target];
                // If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
                if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
                {
                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 3.5f, Mod.Find<ModProjectile>("IceBolt").Type, 14, 2, Main.myPlayer);
                    Main.projectile[projectile].timeLeft = 300;
                    attackCounter = 120;
                    NPC.netUpdate = true;
                }
            }
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.IceBlock, 5, 2, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.Shiverthorn, 4, 1, 5));
            npcLoot.Add(ItemDropRule.Common(ItemID.ShiverthornSeeds, 4, 1, 5));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("LetharvitalicEssence").Type, 1, 2, 5));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("LifeShard").Type, 5, 2, 6));
        }
    }
}