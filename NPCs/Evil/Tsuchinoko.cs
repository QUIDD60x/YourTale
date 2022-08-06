using yourtale.NPCs.Evil;
using yourtale.NPCs.Banners;
using yourtale.Projectiles.Misc;
using Microsoft.Xna.Framework;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using yourtale.Projectiles.Evil;

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
            NPC.DeathSound = Mod.GetLegacySoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/BoneCrush1"); //will go into sounds in a youtube video probably, not explaining those in a text file.

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
					/* you can mark these off if needed, might get it working though.*/
					Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));
					int projectile = Projectile.NewProjectile(NPC.Center, direction * 100, ProjectileType<PoisonSpit>(), NPC.damage / 4, 0, Main.myPlayer);
					Main.projectile[projectile].timeLeft = 5;

					attackCounter = 1;
					NPC.netUpdate = true;
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
		public override void OnKill() //do mod.ItemType instead of ItemID for modded items
		{
			/*Will make NPC always drop entered loot
            Item.NewItem(npc.position, ItemID.Gel, 100);*/
			if (Main.rand.Next(0) == 0)
			{
				Item.NewItem(NPC.position, ItemID.WormTooth, Main.rand.Next(3, 9));
			}
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem(NPC.position, ItemID.BandofRegeneration, 1);
			}
			if (Main.rand.Next(7) == 0)
			{
				Item.NewItem(NPC.position, ItemID.ShadowOrb, 1);
			}
            if (Main.rand.Next(10) == 0)
			{
				Item.NewItem(NPC.position, ItemID.WhoopieCushion, 1);
			}
		}

	}
}