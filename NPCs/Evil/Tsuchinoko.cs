using yourtale.NPCs;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;

namespace yourtale.NPCs.Evil
{
	// These three class showcase usage of the WormHead, WormBody and WormTail classes from Worm.cs
	internal class TsuchinokoHead : WormHead
	{
		public override int BodyType => ModContent.NPCType<TsuchinokoBody>();

		public override int TailType => ModContent.NPCType<TsuchinokoTail>();

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tsuchioko");

			var drawModifier = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{ // Influences how the NPC looks in the Bestiary
				CustomTexturePath = "yourtale/NPCs/Evil/TsuchinokoHead", // If the NPC is multiple parts like a worm, a custom texture for the Bestiary is encouraged.
				Position = new Vector2(40f, 24f),
				PortraitPositionXOverride = 0f,
				PortraitPositionYOverride = 12f
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, drawModifier);
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			float chance = 0f;
				if (spawnInfo.SpawnTileY <= Main.rockLayer && spawnInfo.SpawnTileY >= Main.rockLayer * 0.15)
				{
					chance += 2.3f;
				}

			return chance;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			base.ModifyNPCLoot(npcLoot);

			npcLoot.Add(ItemDropRule.Common(ItemID.CursedFlame, 30, 1, 7));
			npcLoot.Add(ItemDropRule.Common(ItemID.WormTooth, 0, 1, 10));
			npcLoot.Add(ItemDropRule.Common(ItemID.CursedArrow, 20, 5, 8));
		}

		public override void SetDefaults()
		{
			// Head is 10 defence, body 20, tail 30.
			NPC.CloneDefaults(NPCID.DiggerHead);
			NPC.aiStyle = -1;
		}


		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the spawning conditions of this NPC that is listed in the bestiary.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Underground,
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Caverns,

				// Sets the description of this NPC that is listed in the bestiary.
				new FlavorTextBestiaryInfoElement("You should not be seeing this, little jenova.")
			});
		}

		public override void Init()
		{
			// Set the segment variance
			// If you want the segment length to be constant, set these two properties to the same value
			MinSegmentLength = 6;
			MaxSegmentLength = 12;

			CommonWormInit(this);
		}

		// This method is invoked from ExampleWormHead, ExampleWormBody and ExampleWormTail
		internal static void CommonWormInit(WormClass worm)
		{
			// These two properties handle the movement of the worm
			worm.MoveSpeed = 5.5f;
			worm.Acceleration = 0.045f;
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
				// If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
				if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
				{
					Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

					int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ProjectileID.CursedFlameHostile, 5, 0, Main.myPlayer);
					Main.projectile[projectile].timeLeft = 300;
					attackCounter = 500;
					NPC.netUpdate = true;
				}
			}
		}
	}

	internal class TsuchinokoBody : WormBody
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tsuchinoko");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
		}

		public override void Init()
		{
			TsuchinokoHead.CommonWormInit(this);
		}
	}

	internal class TsuchinokoTail : WormTail
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tsuchinoko");

			NPCID.Sets.NPCBestiaryDrawModifiers value = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
			{
				Hide = true // Hides this NPC from the Bestiary, useful for multi-part NPCs whom you only want one entry.
			};
			NPCID.Sets.NPCBestiaryDrawOffset.Add(NPC.type, value);
		}

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.DiggerTail);
			NPC.aiStyle = -1;
		}

		public override void Init()
		{
			TsuchinokoHead.CommonWormInit(this);
		}
	}
}