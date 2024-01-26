﻿#pragma warning disable CA2211 // Non-constant fields should not be visible
using YourTale.Common;
using YourTale.NPCs.Evil.Boss.Minion;
using YourTale.Items;
using YourTale.Projectiles.Evil;
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
using YourTale.Items.Consumables.BossBags;

namespace YourTale.NPCs.Evil.Boss.Cryolisis
{
    // The main part of the boss, usually refered to as "body"
    [AutoloadBossHead] // This attribute looks for a texture called "ClassName_Head_Boss" and automatically registers it as the NPC boss head icon
    public class CryolisisBody : ModNPC
    {
        // This boss has a second phase and we want to give it a second boss head icon, this variable keeps track of the registered texture from Load().
        // It is applied in the BossHeadSlot hook when the boss is in its second stage
        public static int secondStageHeadSlot = -1;

        // This code here is called a property: It acts like a variable, but can modify other things. In this case it uses the NPC.ai[] array that has four entries.
        // We use properties because it makes code more readable ("if (SecondStage)" vs "if (NPC.ai[0] == 1f)").
        // We use NPC.ai[] because in combination with NPC.netUpdate we can make it multiplayer compatible. Otherwise (making our own fields) we would have to write extra code to make it work (not covered here)
        public bool SecondStage
        {
            get => NPC.ai[0] == 1f;
            set => NPC.ai[0] = value ? 1f : 0f;
        }
        // If your boss has more than two stages, and since this is a boolean and can only be two things (true, false), concider using an integer or enum

        // More advanced usage of a property, used to wrap around to floats to act as a Vector2
        public Vector2 FirstStageDestination
        {
            get => new(NPC.ai[1], NPC.ai[2]);
            set
            {
                NPC.ai[1] = value.X;
                NPC.ai[2] = value.Y;
            }
        }

        // Auto-implemented property, acts exactly like a variable by using a hidden backing field
        public Vector2 LastFirstStageDestination { get; set; } = Vector2.Zero;

        // This property uses NPC.localAI[] instead which doesn't get synced, but because SpawnedMinions is only used on spawn as a flag, this will get set by all parties to true.
        // Knowing what side (client, server, all) is in charge of a variable is important as NPC.ai[] only has four entries, so choose wisely which things you need synced and not synced
        public bool SpawnedMinions
        {
            get => NPC.localAI[0] == 1f;
            set => NPC.localAI[0] = value ? 1f : 0f;
        }

        private const int FirstStageTimerMax = 90;
        // This is a reference property. It lets us write FirstStageTimer as if it's NPC.localAI[1], essentially giving it our own name
        public ref float FirstStageTimer => ref NPC.localAI[1];

        public ref float RemainingShields => ref NPC.localAI[2];

        // We could also repurpose FirstStageTimer since it's unused in the second stage, or write "=> ref FirstStageTimer", but then we have to reset the timer when the state switch happens
        public ref float SecondStageTimer_SpawnIce => ref NPC.localAI[3];

        // Do NOT try to use NPC.ai[4]/NPC.localAI[4] or higher indexes, it only accepts 0, 1, 2 and 3!
        // If you choose to go the route of "wrapping properties" for NPC.ai[], make sure they don't overlap (two properties using the same variable in different ways), and that you don't accidently use NPC.ai[] directly

        // Helper method to determine the minion type
        public static int MinionType()
        {
            return ModContent.NPCType<CryoMinion>();
        }

        // Helper method to determine the amount of minions summoned
        public static int MinionCount()
        {
            int count = 15;

            if (Main.expertMode)
            {
                count += 7; // Increase by 7 if expert or master mode
            }

            if (Main.getGoodWorld)
            {
                count += 100; // Increase by 100 if using the "For The Worthy" seed
            }

            return count;
        }

        public override void Load()
        {
            // We want to give it a second boss head icon, so we register one
            string texture = BossHeadTexture + "_SecondStage"; // Our texture is called "ClassName_Head_Boss_SecondStage"
            secondStageHeadSlot = Mod.AddBossHeadTexture(texture, -1); // -1 because we already have one registered via the [AutoloadBossHead] attribute, it would overwrite it otherwise
        }

        public override void BossHeadSlot(ref int index)
        {
            int slot = secondStageHeadSlot;
            if (SecondStage && slot != -1)
            {
                // If the boss is in its second stage, display the other head icon instead
                index = slot;
            }
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 1;

            // Add this in for bosses that have a summon item, requires corresponding code in the item (See MinionBossSummonItem.cs)
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            // Automatically group with other bosses
            NPCID.Sets.BossBestiaryPriority.Add(Type);

            // Specify the debuffs it is immune to
            NPCDebuffImmunityData debuffData = new()
            {
                SpecificallyImmuneTo = new int[] {
                    BuffID.Poisoned,

                    BuffID.Confused // Most NPCs have this
				}
            };
        }

        public override void SetDefaults()
        {
            NPC.width = 180;
            NPC.height = 180;
            NPC.damage = 40;
            NPC.defense = 10;
            NPC.lifeMax = 4500;
            NPC.HitSound = SoundID.Item25;
            NPC.DeathSound = SoundID.Item4;
            NPC.knockBackResist = 0f;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.value = Item.buyPrice(gold: 5);
            NPC.SpawnWithHigherTime(30);
            NPC.boss = true;
            NPC.npcSlots = 8f; // Take up open spawn slots, preventing random NPCs from spawning during the fight

            // Don't set immunities like this as of 1.4:
            // NPC.buffImmune[BuffID.Confused] = true;
            // immunities are handled via dictionaries through NPCID.Sets.DebuffImmunitySets

            // Custom AI, 0 is "bound town NPC" AI which slows the NPC down and changes sprite orientation towards the target
            NPC.aiStyle = -1;


            // The following code assigns a music track to the boss in a simple way.
            if (!Main.dedServ)
            {
                Music = MusicLoader.GetMusicSlot(Mod, "Assets/Music/BadPianoFight");
            }
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            // Sets the description of this NPC that is listed in the bestiary
            bestiaryEntry.Info.AddRange(new List<IBestiaryInfoElement> {
                new MoonLordPortraitBackgroundProviderBestiaryInfoElement(), // Plain black background
				new FlavorTextBestiaryInfoElement("An ancient ice elemental, certainly the weakest of the bunch.")
            });
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Shiverthorn, 1, 3, 9));
            npcLoot.Add(ItemDropRule.Common(ItemID.ShiverthornSeeds, 1, 5, 10));
            npcLoot.Add(ItemDropRule.Common(ItemID.IceBlade, 7, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.IceBoomerang, 7, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.IceSkates, 7, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.SnowballCannon, 4, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.BlizzardinaBottle, 7, 1, 1));
            npcLoot.Add(ItemDropRule.Common(ItemID.FlurryBoots, 5, 1, 1));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("AncientShard").Type, 10, 5, 15));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CorExitio").Type, 1, 7, 14));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("IceHeart").Type, 1, 1));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("CryoliteLocket").Type, 1, 1));
            npcLoot.Add(ItemDropRule.Common(Mod.Find<ModItem>("LetharvitalicEssence").Type, 1, 3, 9));

             //Add the treasure bag using ItemDropRule.BossBag (automatically checks for expert mode)
            npcLoot.Add(ItemDropRule.BossBag(ModContent.ItemType<CryoBossBag>()));
        }

        public override void OnKill()
        {
            // This sets downedMinionBoss to true, and if it was false before, it initiates a lantern night
            NPC.SetEventFlagCleared(ref DownedBossSystem.downedCryolisis, -1);

            // Since this hook is only ran in singleplayer and serverside, we would have to sync it manually.
            // Thankfully, vanilla sends the MessageID.WorldData packet if a BOSS was killed automatically, shortly after this hook is ran

            // If your NPC is not a boss and you need to sync the world (which includes ModSystem, check DownedBossSystem), use this code:
            /*
			if (Main.netMode == NetmodeID.Server) {
				NetMessage.SendData(MessageID.WorldData);
			}
			*/
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.HealingPotion;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses; // use the boss immunity cooldown counter, to prevent ignoring boss attacks by taking damage from other sources
            return true;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
            // If the NPC dies, spawn gore and play a sound
            if (Main.netMode == NetmodeID.Server)
            {
                // We don't want Mod.Find<ModGore> to run on servers as it will crash because gores are not loaded on servers
                return;
            }

            if (NPC.life <= 0)
            {
                // These gores work by simply existing as a texture inside any folder which path contains "Gores/"
                int backGoreType = Mod.Find<ModGore>("CryolisisGore1").Type;
                int frontGoreType = Mod.Find<ModGore>("CryolisisGore2").Type;

                var entitySource = NPC.GetSource_Death();

                for (int i = 0; i < 2; i++)
                {
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), backGoreType);
                    Gore.NewGore(entitySource, NPC.position, new Vector2(Main.rand.Next(-6, 7), Main.rand.Next(-6, 7)), frontGoreType);
                }

                SoundEngine.PlaySound(SoundID.Roar, NPC.Center);
            }
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
        public int bolt = ModContent.ProjectileType<IceBolt>();

        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (attackCounter > 0)
                {
                    attackCounter--; // tick down the attack counter.
                }

                Player target = Main.player[NPC.target];
                
                if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 800 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
                {
                    Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                    direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 15, bolt, 20, 2, Main.myPlayer);
                    Main.projectile[projectile].timeLeft = 300;
                    attackCounter = 500;
                    NPC.netUpdate = true;
                }
            }

            // This should almost always be the first code in AI() as it is responsible for finding the proper player target
            if (NPC.target < 0 || NPC.target == 255 || Main.player[NPC.target].dead || !Main.player[NPC.target].active)
            {
                NPC.TargetClosest();
            }

            Player player = Main.player[NPC.target];

            if (player.dead)
            {
                // If the targeted player is dead, flee
                NPC.velocity.Y -= 0.04f;
                // This method makes it so when the boss is in "despawn range" (outside of the screen), it despawns in 10 ticks
                NPC.EncourageDespawn(10);
                return;
            }

            SpawnMinions();

            CheckSecondStage();

            // Be invulnerable during the first stage
            NPC.dontTakeDamage = !SecondStage;

            if (SecondStage)
            {
                DoSecondStage(player);
            }
            else
            {
                DoFirstStage(player);
            }
        }

        private void SpawnMinions()
        {
            if (SpawnedMinions)
            {
                // No point executing the code in this method again
                return;
            }

            SpawnedMinions = true;

            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                // Because we want to spawn minions, and minions are NPCs, we have to do this on the server (or singleplayer, "!= NetmodeID.MultiplayerClient" covers both)
                // This means we also have to sync it after we spawned and set up the minion
                return;
            }

            int count = MinionCount();
            var entitySource = NPC.GetSource_FromAI();

            for (int i = 0; i < count; i++)
            {
                int index = NPC.NewNPC(entitySource, (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<CryoMinion>(), NPC.whoAmI);
                NPC minionNPC = Main.npc[index];

                // Now that the minion is spawned, we need to prepare it with data that is necessary for it to work
                // This is not required usually if you simply spawn NPCs, but because the minion is tied to the body, we need to pass this information to it

                if (minionNPC.ModNPC is CryoMinion minion)
                {
                    // This checks if our spawned NPC is indeed the minion, and casts it so we can access its variables
                    minion.ParentIndex = NPC.whoAmI; // Let the minion know who the "parent" is
                    minion.PositionIndex = i; // Give it the iteration index so each minion has a separate one, used for movement
                }

                // Finally, syncing, only sync on server and if the NPC actually exists (Main.maxNPCs is the index of a dummy NPC, there is no point syncing it)
                if (Main.netMode == NetmodeID.Server && index < Main.maxNPCs)
                {
                    NetMessage.SendData(MessageID.SyncNPC, number: index);
                }
            }
        }

        private void CheckSecondStage()
        {
            if (SecondStage)
            {
                // No point checking if the NPC is already in its second stage
                return;
            }

            float remainingShieldsSum = 0f;
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                NPC otherNPC = Main.npc[i];
                if (otherNPC.active && otherNPC.type == MinionType() && otherNPC.ModNPC is CryoMinion minion)
                {
                    if (minion.ParentIndex == NPC.whoAmI)
                    {
                        remainingShieldsSum += (float)otherNPC.life / otherNPC.lifeMax;
                    }
                }
            }

            // We reference this in the MinionBossBossBar
            RemainingShields = remainingShieldsSum / MinionCount();

            if (RemainingShields <= 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                // If we have no shields (aka "no minions alive"), we initiate the second stage, and notify other players that this NPC has reached its second stage
                // by setting NPC.netUpdate to true in this tick. It will send important data like position, velocity and the NPC.ai[] array to all connected clients

                // Because SecondStage is a property using NPC.ai[], it will get synced this way
                SecondStage = true;
                NPC.netUpdate = true;
            }
        }

        private void DoFirstStage(Player player)
        {
            // Each time the timer is 0, pick a random position a fixed distance away from the player but towards the opposite side
            // The NPC moves directly towards it with fixed speed, while displaying its trajectory as a telegraph

            FirstStageTimer++;
            if (FirstStageTimer > FirstStageTimerMax)
            {
                FirstStageTimer = 0;
            }

            float distance = 350; // Distance in pixels behind the player

            if (FirstStageTimer == 0)
            {
                Vector2 fromPlayer = NPC.Center - player.Center;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    // Important multiplayer concideration: drastic change in behavior (that is also decided by randomness) like this requires
                    // to be executed on the server (or singleplayer) to keep the boss in sync

                    float angle = fromPlayer.ToRotation();
                    float twelfth = MathHelper.Pi / 6;

                    angle += MathHelper.Pi + Main.rand.NextFloat(-twelfth, twelfth);
                    if (angle > MathHelper.TwoPi)
                    {
                        angle -= MathHelper.TwoPi;
                    }
                    else if (angle < 0)
                    {
                        angle += MathHelper.TwoPi;
                    }

                    Vector2 relativeDestination = angle.ToRotationVector2() * distance;

                    FirstStageDestination = player.Center + relativeDestination;
                    NPC.netUpdate = true;
                }
            }

            // Move along the vector
            Vector2 toDestination = FirstStageDestination - NPC.Center;
            Vector2 toDestinationNormalized = toDestination.SafeNormalize(Vector2.UnitY);
            float speed = Math.Min(distance, toDestination.Length());
            NPC.velocity = toDestinationNormalized * speed / 25;

            if (FirstStageDestination != LastFirstStageDestination)
            {
                // If destination changed
                NPC.TargetClosest(); // Pick the closest player target again

                // "Why is this not in the same code that sets FirstStageDestination?" Because in multiplayer it's ran by the server.
                // The client has to know when the destination changes a different way. Keeping track of the previous ticks' destination is one way
                if (Main.netMode != NetmodeID.Server)
                {
                    // For visuals regarding NPC position, netOffset has to be concidered to make visuals align properly
                    NPC.position += NPC.netOffset;

                    // Draw a line between the NPC and its destination, represented as dusts every 20 pixels
                    Dust.QuickDustLine(NPC.Center + toDestinationNormalized * NPC.width, FirstStageDestination, toDestination.Length() / 20f, Color.WhiteSmoke);

                    NPC.position -= NPC.netOffset;
                }
            }
            LastFirstStageDestination = FirstStageDestination;

            // No damage during first phase
            NPC.damage = 0;

            // Fade in based on remaining total minion life
            NPC.alpha = (int)(RemainingShields * 255);

            NPC.rotation = NPC.velocity.ToRotation() - MathHelper.PiOver2;
        }

        private void DoSecondStage(Player player)
        {
            Vector2 toPlayer = player.Center - NPC.Center;

            float offsetX = 200f;

            Vector2 abovePlayer = player.Top + new Vector2(NPC.direction * offsetX, -NPC.height);

            Vector2 toAbovePlayer = abovePlayer - NPC.Center;
            Vector2 toAbovePlayerNormalized = toAbovePlayer.SafeNormalize(Vector2.UnitY);

            // The NPC tries to go towards the offsetX position, but most likely it will never get there exactly, or close to if the player is moving
            // This checks if the npc is "20% there", and then changes direction
            float changeDirOffset = offsetX * 0.2f;

            if (NPC.direction == -1 && NPC.Center.X - changeDirOffset < abovePlayer.X ||
                NPC.direction == 1 && NPC.Center.X + changeDirOffset > abovePlayer.X)
            {
                NPC.direction *= -1;
            }

            float speed = 12f;
            float inertia = 55f;

            // If the boss is somehow below the player, move faster to catch up
            if (NPC.Top.Y > player.Bottom.Y)
            {
                speed = 16f;
            }

            Vector2 moveTo = toAbovePlayerNormalized * speed;
            NPC.velocity = (NPC.velocity * (inertia - 1) + moveTo) / inertia;

            DoSecondStage_SpawnIce(player);

            NPC.damage = NPC.defDamage;

            NPC.alpha = 0;

            NPC.rotation = toPlayer.ToRotation() - MathHelper.PiOver2;
        }

        private void DoSecondStage_SpawnIce(Player player)
        {
            // At 100% health, spawn every 75 ticks
            // Drops down until 50% health to spawn every 30 ticks
            float timerMax = Utils.Clamp((float)NPC.life / NPC.lifeMax, 0.5f, 1f) * 75;

            SecondStageTimer_SpawnIce++;
            if (SecondStageTimer_SpawnIce > timerMax)
            {
                SecondStageTimer_SpawnIce = 0;
            }

            if (NPC.HasValidTarget && SecondStageTimer_SpawnIce == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                // Spawn projectile randomly below player, based on horizontal velocity to make kiting harder, starting velocity 1f upwards
                // (The projectiles accelerate from their initial velocity)
                // This is all for the blue fire thing.
                float kitingOffsetX = Utils.Clamp(player.velocity.X * 30, -100, 100);
                Vector2 position = player.Bottom + new Vector2(kitingOffsetX + Main.rand.Next(-100, 100), Main.rand.Next(50, 100));

                int type = ModContent.ProjectileType<FreezeFire>();
                int damage = NPC.damage - 15;
                var entitySource = NPC.GetSource_FromAI();

                Projectile.NewProjectile(entitySource, position, -Vector2.UnitY, type, damage, 0f, Main.myPlayer);
                // Hoping I can make a new projectile he will shoot, to make the fight more intresting.
            }

            if (NPC.HasValidTarget && SecondStageTimer_SpawnIce == 0 && Main.netMode != NetmodeID.MultiplayerClient)
            {
                var entitySource = NPC.GetSource_FromAI();
                float kitingOffsetX = Utils.Clamp(player.velocity.X * 100, -1000, 1000);
                Vector2 position = player.Bottom + new Vector2(kitingOffsetX + Main.rand.Next(-100, 1000), Main.rand.Next(50, 100));

                Projectile.NewProjectile(entitySource, position, -Vector2.UnitY, ProjectileID.IceBolt, 15, 0f, Main.myPlayer);
            }
        }
    }
}