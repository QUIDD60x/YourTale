using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using static Terraria.ModLoader.ModContent;
using yourtale.Projectiles.Evil;
using yourtale.NPCs.Evil;
using IL.Terraria.DataStructures;

namespace yourtale.NPCs.Evil
{


	public class TsuchinokoHead: Tsuchinoko
	{


		public override void SetDefaults()
		{

			NPC.CloneDefaults(NPCID.DiggerHead);
			NPC.aiStyle = -1;
			NPC.lifeMax = Main.rand.Next(120, 330);
			NPC.damage = 65;
			NPC.defense = 15;
			NPC.value = 50000;
            NPC.HitSound = SoundID.NPCHit13;
            //NPC.DeathSound = Mod.GetLegacySoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/BoneCrush1"); //will go into sounds in a youtube video probably, not explaining those in a text file.

        }

		
        
		public override void Init()
		{
			base.Init();
			head = true;
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

		public override void CustomBehavior()
		{
			if (Main.netMode != NetmodeID.MultiplayerClient)
			{
				if (attackCounter > 0)
				{
					attackCounter--;
				}

				Player target = Main.player[NPC.target];
				if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
				{
					/* 
					Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));
					int projectile = Projectile.NewProjectile(IEntitySource 0, Vector2 position, Vector2 velocity, int Type, int Damage, float KnockBack, int Owner = 255, float ai0 = 0, float ai1 = 0);
					Main.projectile[projectile].timeLeft = 5;

					attackCounter = 1;
					NPC.netUpdate = true;*/
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.Player.ZoneRockLayerHeight) //these are also specified on the tmodloader's spawning github. They are important so your mob doesn't spawn anywhere or all over the place.
            {
				return 0.09f;
            }
			if (NPC.AnyNPCs(Mod.Find<ModNPC>("Tsuchinoko").Type)) //this makes it to where if 1 already exists, another won't spawn
			{
				return 0;
            }
			else 
            {
                return 0.001f;
            }
        }
    }

	public class TsuchinokoBody : Tsuchinoko
	{


		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.lifeMax = Main.rand.Next(100, 300);
			NPC.damage = 12;
			NPC.defense = 12;
            NPC.HitSound = SoundID.NPCHit13;
            NPC.DeathSound = SoundID.NPCDeath19;

        }
	}

	public class TsuchinokoTail : Tsuchinoko
	{

		public override void SetDefaults()
		{
			NPC.CloneDefaults(NPCID.DiggerBody);
			NPC.aiStyle = -1;
			NPC.lifeMax = 100;
			NPC.damage = 100;
			NPC.defense = 10000;
            NPC.HitSound = SoundID.NPCHit13;
            NPC.DeathSound = SoundID.NPCDeath19;

        }

		public override void Init()
		{
			base.Init();
			tail = true;
		}
	}

	// I made this 2nd base class to limit code repetition.
	public abstract class Tsuchinoko : Worm
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Tsuchinoko");
		}

		public override void Init()
		{
			minLength = 8;
			maxLength = 45;
			tailType = NPCType<TsuchinokoTail>();
			bodyType = NPCType<TsuchinokoBody>();
			headType = NPCType<TsuchinokoHead>();
			speed = 3f;
			turnSpeed = 0.05f;
			flies = true;
			
		}
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.CursedFlame, 20, 1, 9));
			npcLoot.Add(ItemDropRule.Common(ItemID.WormTooth, 100, 3, 10));
		}

	}
}