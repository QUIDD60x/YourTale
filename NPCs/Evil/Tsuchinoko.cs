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

			npc.CloneDefaults(NPCID.DiggerHead);
			npc.aiStyle = -1;
			npc.lifeMax = Main.rand.Next(120, 330);
			npc.damage = 65;
			npc.defense = 15;
			npc.value = 50000;
            npc.HitSound = SoundID.NPCHit13;
            npc.DeathSound = mod.GetLegacySoundSlot(SoundType.NPCKilled, "Sounds/NPCKilled/BoneCrush1"); //will go into sounds in a youtube video probably, not explaining those in a text file.

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

				Player target = Main.player[npc.target];
				if (attackCounter <= 0 && Vector2.Distance(npc.Center, target.Center) < 200 && Collision.CanHit(npc.Center, 1, 1, target.Center, 1, 1))
				{
					/* you can mark these off if needed, might get it working though.*/
					Vector2 direction = (target.Center - npc.Center).SafeNormalize(Vector2.UnitX);
					direction = direction.RotatedByRandom(MathHelper.ToRadians(10));
					int projectile = Projectile.NewProjectile(npc.Center, direction * 100, ProjectileType<PoisonSpit>(), npc.damage / 4, 0, Main.myPlayer);
					Main.projectile[projectile].timeLeft = 5;

					attackCounter = 1;
					npc.netUpdate = true;
				}
			}
		}
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
			if (spawnInfo.player.ZoneRockLayerHeight) //these are also specified on the tmodloader's spawning github. They are important so your mob doesn't spawn anywhere or all over the place.
            {
				return 0.09f;
            }
			if (NPC.AnyNPCs(mod.NPCType("Tsuchinoko"))) //this makes it to where if 1 already exists, another won't spawn
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
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.lifeMax = Main.rand.Next(100, 300);
			npc.damage = 12;
			npc.defense = 12;
            npc.HitSound = SoundID.NPCHit13;
            npc.DeathSound = SoundID.NPCDeath19;

        }
	}

	public class TsuchinokoTail : Tsuchinoko
	{

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.DiggerBody);
			npc.aiStyle = -1;
			npc.lifeMax = 100;
			npc.damage = 100;
			npc.defense = 10000;
            npc.HitSound = SoundID.NPCHit13;
            npc.DeathSound = SoundID.NPCDeath19;

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
		public override void NPCLoot() //do mod.ItemType instead of ItemID for modded items
		{
			/*Will make NPC always drop entered loot
            Item.NewItem(npc.position, ItemID.Gel, 100);*/
			if (Main.rand.Next(0) == 0)
			{
				Item.NewItem(npc.position, ItemID.WormTooth, Main.rand.Next(3, 9));
			}
			if (Main.rand.Next(10) == 0)
			{
				Item.NewItem(npc.position, ItemID.BandofRegeneration, 1);
			}
			if (Main.rand.Next(7) == 0)
			{
				Item.NewItem(npc.position, ItemID.ShadowOrb, 1);
			}
            if (Main.rand.Next(10) == 0)
			{
				Item.NewItem(npc.position, ItemID.WhoopieCushion, 1);
			}
		}

	}
}