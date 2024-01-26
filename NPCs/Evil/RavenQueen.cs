using yourtale.Items;
using yourtale.Projectiles.Evil;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using System.IO;
namespace yourtale.NPCs.Evil
{
        public class RavenQueen : ModNPC
        {
            public override void SetDefaults()
            {
                NPC.width = 95;
                NPC.height = 80;
                NPC.damage = 20;
                NPC.defense = 9;
                NPC.lifeMax = 250;
                NPC.HitSound = SoundID.NPCHit1;
                NPC.DeathSound = SoundID.NPCDeath1;
                NPC.value = 2200;
                NPC.knockBackResist = 0.4f;
                NPC.aiStyle = 14;
                Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.Raven];
                AnimationType = NPCID.Raven;
                //Banner = Item.NPCtoBanner(); Currently don't have a banner intended for this NPC.
                //BannerItem = Item.BannerToItem(Banner);
                NPC.noGravity = true;
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
                if (attackCounter > 0)
                {
                    attackCounter--; // tick down the attack counter.
                }

                Player target = Main.player[NPC.target];
                if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 820 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
                {
                    Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                    direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 16, ModContent.ProjectileType<RavenFeatherProj>(), 5, 0, Main.myPlayer);
                    Main.projectile[projectile].timeLeft = 300;
                    attackCounter = 50;
                    NPC.netUpdate = true;
                }
            }
        }

        /*public override float SpawnChance(NPCSpawnInfo spawnInfo)
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
            }*/
            public override void ModifyNPCLoot(NPCLoot npcLoot)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RavenFeather>(), 1, 7, 12));
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GiantRavenFeather>(), 1));
            }
        }
}
