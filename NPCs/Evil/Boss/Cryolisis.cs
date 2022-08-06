/*using System.IO;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Projectiles.Evil;
using yourtale;						//Too lazy to update Cryolisis RN, will fix everything with it once i get 1.4 working.

namespace yourtale.NPCs.Evil.Boss
{
	public class Cryolisis : ModNPC
	{
		private static int hellLayer
		{
			get
			{
				return Main.maxTilesY - 200;
			}
		}

		private const int sphereRadius = 300;

		private int subCool
		{
			get
			{
				return (int)NPC.ai[0];
			}
			set
			{
				NPC.ai[0] = (float)value;
			}
		}

		private float coolDown
		{
			get
			{
				return NPC.ai[1];
			}
			set
			{
				NPC.ai[1] = value;
			}
		}

		private float rotationSpeed
		{
			get
			{
				return NPC.ai[2];
			}
			set
			{
				NPC.ai[2] = value;
			}
		}

		private float currentMove
		{
			get
			{
				return NPC.ai[3];
			}
			set
			{
				NPC.ai[3] = value;
			}
		}

		private int moveTime = 60;
		private int moveTimer = 60;
		private bool currentlyImmune = false;
		private int lastStage = 0;
		internal int laserTimer = 0;
		internal int laser1 = -1;
		internal int laser2 = -1;
		private Vector2 targetPos;
		private int stage;
		private int[] receivedDamage = new int[5];

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cryolisis");
		}

		public override void SetDefaults()
		{
			NPC.aiStyle = -1;
			NPC.lifeMax = 2700;
			NPC.damage = 35;
			NPC.defense = 13;
			NPC.knockBackResist = 0f;
			NPC.width = 180;
			NPC.height = 180;
			Main.npcFrameCount[NPC.type] = 1;
			NPC.value = Item.buyPrice(0, 20, 0, 0);
			NPC.npcSlots = 15f;
			NPC.boss = true;
			NPC.lavaImmune = false;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
			NPC.HitSound = SoundID.NPCHit3;
			NPC.DeathSound = SoundID.Thunder;
			NPC.buffImmune[24] = true;
			//Music = Mod.GetSoundSlot(SoundType.Music, "Sounds/Music/MultiMelody");
		}

		public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
		{
			bossLifeScale = 1.2f;
			NPC.lifeMax = 4500;
			NPC.damage = 50;
		}

		public override void AI()
		{
			if(Main.netMode != 1 && NPC.localAI[0] == 0f)
			{
				NPC.netUpdate = true;
				NPC.localAI[0] = 1f;
			}
			coolDown--;
			Player player = Main.player[NPC.target];

			if(coolDown <= 0)
			{
				if(!currentlyImmune)
				{
					currentlyImmune = true;
					currentMove = 0;
					coolDown = 120;
					if(ClearNebula(player))
					{
						int a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("CryoDust").Type, 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(-2f, -2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("Sparkle").Type, 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(-2f, 2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("CryoDust").Type, 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(2f, -2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("Sparkle").Type, 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(2f, 2f);

						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("CryoDust").Type, 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(0f, 2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("Sparkle").Type, 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(0f, -2f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("CryoDust").Type, 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(2f, 0f);
						a = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("Sparkle").Type, 0f, 0f, 0, default(Color), 1f);
						Main.dust[a].velocity = new Vector2(-2f, 0f);
						player.statMana = player.statManaMax2 / 2;
					}
				}
				else
				{
					currentlyImmune = false;
					getNextMove();
					subCool = 60;
				}
			}
			NPC.rotation += rotationSpeed;
			if(!player.active || player.dead || player.position.Y < hellLayer)
			{
				NPC.TargetClosest(false);
				player = Main.player[NPC.target];
				if(!player.active || player.dead || player.position.Y < hellLayer)
				{
					NPC.velocity = new Vector2(0f, 5f);
					if(NPC.timeLeft > 10)
					{
						NPC.timeLeft = 10;
					}
					return;
				}
			}
			if(player.name != "Quiddev")
			{
				Main.NewText("You're dealing too much damage!", 255, 32, 32);
				player.statDefense = 0;
				player.endurance = 0;
				player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " was cheating a little."), 9999, -player.direction,
					false, false, true, -1);
				BitLightning(player.Center);
			}

			if(currentlyImmune)
			{
				if(rotationSpeed > 0f)
				{
					rotationSpeed += 0f;
				}
				NPC.velocity = new Vector2((player.Center.X - NPC.Center.X) / 100, (player.Center.Y - NPC.Center.Y) / 100);
			}
			else
			{
				if(rotationSpeed < 0.1f)
				{
					rotationSpeed += 0.1f;
				}
			}

			UpdateStage();

			if(stage == 1 && lastStage == 0)
			{
				Main.NewText("The air is getting colder around you...", 41, 84, 153);
				//Music = Mod.GetSoundSlot(SoundType.Music, "Sounds/Music/Chaotic");
				NPC.defense += 8;
				NPC.damage += 20;
			}
			if(stage == 2 && lastStage != 2)
			{
				Main.NewText("It's begining to melt!", 66, 135, 245);
				NPC.damage -= 15;
				NPC.defense -= 10;
				NPC.AddBuff(BuffID.Wet, -1);
			}
			// -------------------------------------------------------------------------- ATTACKS
			subCool--;
			if(currentMove == 1)
			{
				rotationSpeed = 0.22f;
				if(subCool <= 0 && stage >= 2)
				{
					NPC.velocity = new Vector2((player.Center.X - NPC.Center.X) / 30, (player.Center.Y - NPC.Center.Y) / 30);
				}
			}
			if(currentMove == 2)
			{
				NPC.velocity = new Vector2((player.Center.X - NPC.Center.X) / 200, (player.Center.Y - NPC.Center.Y) / 200);
				BitStorm(player.Center);
			}
			if(currentMove == 3)
			{
				NPC.velocity = new Vector2((player.Center.X - NPC.Center.X) / 150, (player.Center.Y - NPC.Center.Y) / 150);
				BitBeam(player.Center);
			}
			if(currentMove == 4)
			{
				NPC.velocity = new Vector2((player.Center.X - NPC.Center.X) / 300, (player.Center.Y - NPC.Center.Y) / 300);
				rotationSpeed = 0.3f;
				if(subCool <= 0)
				{
					BitExplosion(player.Center);
				}
			}
			if(currentMove == 5)
			{
				NPC.velocity = new Vector2((player.Center.X - NPC.Center.X) / 250, (player.Center.Y - NPC.Center.Y) / 250);
				rotationSpeed = 0.2f;
				if(subCool == 25)
				{
					targetPos = player.Center;
					for(int i = 0; i < 20; i++)
					{
						int dust = Dust.NewDust(new Vector2(player.Center.X, player.Center.Y), 5, 5, Mod.Find<ModDust>("CryoDust").Type, 0f, 0f, 0, default(Color), 1f);
						int x = 0;
						int y = 0;
						while(x == 0 && y == 0)
						{
							x = Main.rand.Next(-6, 6);
							y = Main.rand.Next(-6, 6);
						}
						Main.dust[dust].velocity = new Vector2(x, y);
						Main.dust[dust].color = new Color(0, 255, 255);
					}
				}
				if(subCool <= 0)
				{
					Vector2 sum = Vector2.Zero;
					sum.X = Main.rand.Next(-120, 121);
					BitLightning(targetPos + sum);
					subCool = 30;
				}
			}
			if(subCool <= 0)
			{
				subCool = 60;
			}
			// -------------------------------------------------------------------------- ATTACKS

			if(Main.netMode != 1)
			{
				NPC.TargetClosest(false);
				player = Main.player[NPC.target];
				NPC.netUpdate = true;
			}
			lastStage = stage;
		}

		private bool ClearNebula(Player player)
		{
			bool cleared = false;
			for(int i = 0; i < 22; i++)
			{
				int t = player.buffType[i];
				if(t == BuffID.NebulaUpLife1 || t == BuffID.NebulaUpLife2 || t == BuffID.NebulaUpLife3 || t == BuffID.NebulaUpDmg1 || t == BuffID.NebulaUpDmg2 || t == BuffID.NebulaUpDmg3)
				{
					player.DelBuff(i);
					cleared = true;
				}
			}
			return cleared;
		}

		private void BitLightning(Vector2 pos)
		{
			int damage = (int)(NPC.damage);
			if(Main.expertMode)
			{
				damage = (int)(damage * 1.8f);
			}
			for(int i = 0; i < 3; i++)
			{
				int a2 = Projectile.NewProjectile(pos.X + Main.rand.Next(-9, 10), 50, 0, 10, Mod.Find<ModProjectile>("EvilCryolisisProj").Type, damage, 0, 0);
			}
		}

		private void BitStorm(Vector2 pos)
		{
			for(int i = -5; i <= 5; i++)
			{										//was 15
				Dust.NewDust(new Vector2(pos.X - (i * 6f), pos.Y - 300f + Main.rand.Next(-16, 17)), 12, 16, Mod.Find<ModDust>("CryoDust").Type);
			}
			int fallSpeed = 2;
			if(Main.expertMode)
			{
				fallSpeed = 2;
			}
			int a2 = Projectile.NewProjectile(pos.X - (Main.rand.Next(-5, 6)*15f), pos.Y-300f+Main.rand.Next(-16,17), 0, fallSpeed, Mod.Find<ModProjectile>("EvilCryolisisProj").Type, (int)(NPC.damage * 0.3f), 0, 0);
			Main.projectile[a2].timeLeft = 9999;
		}

		private void BitBeam(Vector2 pos)
		{
			Vector2 vector2 = NPC.Center;
			float num200 = (float)pos.X - vector2.X;
			float num201 = (float)pos.Y - vector2.Y;
			num200 += (float)Main.rand.Next(-999, 41) * 2f;
			num201 += (float)Main.rand.Next(-999, 33) * 2f;
			Vector2 vector12 = vector2 + Vector2.Normalize(new Vector2(num200, num201).RotatedBy((double)(-1.5f * (float)NPC.direction), default(Vector2))) * 3f;
			int a2 = Projectile.NewProjectile(vector12.X, vector12.Y, num200, num201, Mod.Find<ModProjectile>("EvilCryolisisProj").Type, (int)(NPC.damage * 0.3f), 0, 0);
			Main.projectile[a2].tileCollide = true;
			Main.projectile[a2].timeLeft = 270;
		}

		private void BitExplosion(Vector2 pos)
		{
			int range = 9, count = 25;
			if(Main.expertMode)
			{
				range = 24;
				count = 70;
			}
			for(int i = 0; i < count; i++)
			{
				int a2 = Projectile.NewProjectile(NPC.Center.X, NPC.Center.Y, Main.rand.Next(-range, range+1), Main.rand.Next(-range, range+1), Mod.Find<ModProjectile>("EvilCryolisisProj").Type, (int)(NPC.damage * 0.8f), 0, 0);
				Main.projectile[a2].tileCollide = true;
				Main.projectile[a2].timeLeft = 100;
			}
		}

		private Vector2 getAttackPosition()
		{
			Player player = Main.player[NPC.target];
			return new Vector2(player.Center.X, player.Center.Y);
		}

		private void getNextMove()
		{
			targetPos = Main.player[NPC.target].Center;
			int nextAtk = Main.rand.Next(0, 101);
			if(nextAtk <= 30 || stage == 0)
			{
				currentMove = 1;
				coolDown = 120;
				int divisor = 45;
				if(stage >= 1)
				{
					divisor = 30;
					coolDown = 90;
				}
				NPC.velocity = new Vector2((targetPos.X - NPC.Center.X) / divisor, (targetPos.Y - NPC.Center.Y) / divisor);
			}
			else if(nextAtk > 30 && nextAtk <= 50)
			{
				currentMove = 2;
				coolDown = 240;
			}
			else if(nextAtk > 50 && nextAtk <= 70)
			{
				currentMove = 3;
				coolDown = 120;
			}
			else if(nextAtk > 70)
			{
				if(stage == 2 && nextAtk > 85)
				{
					currentMove = 5;
					coolDown = 185;
				}
				else
				{
					currentMove = 4;
					coolDown = 180;
				}
			}
		}

		public override bool CheckDead()
		{
			if(!NPC.lavaImmune)
			{
				NPC.lavaImmune = true;
				NPC.life = NPC.lifeMax;
				return false;
			}
			return true;
		}

		public override void SendExtraAI(BinaryWriter writer)
		{
			writer.Write((short)moveTime);
			writer.Write((short)moveTimer);
			if(Main.expertMode)
			{
				//
			}
		}

		public override void ReceiveExtraAI(BinaryReader reader)
		{
			moveTime = reader.ReadInt16();
			moveTimer = reader.ReadInt16();
			if(Main.expertMode)
			{
				//
			}
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frame.Y = 0;
		}

		private void UpdateStage()
		{
			float hp = (float)(NPC.life);
			float hpM = (float)(NPC.lifeMax);
			float hpP = hp/hpM;
			if(!NPC.lavaImmune)
			{
				stage = 0;
			}
			else if(NPC.lavaImmune && hpP > 0.8f)
			{
				stage = 1;
			}
			else
			{
				stage = 2;
			}
		}

		/*public override Color? GetAlpha(Color drawColor)
		{
			if(currentlyImmune)
			{
				return Color.White;
			}
			if(stage == 2)
			{
				return Color.MidnightBlue;
			}
			/*if(stage == 1)
			{
				return Color.MidnightBlue;
			}
			return null;
		}*/ /*

		public override void HitEffect(int hitDirection, double damage)
		{
			for(int k = 0; k < damage / NPC.lifeMax * 50.0; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, Mod.Find<ModDust>("CryoDust").Type, hitDirection, -1f, 0, default(Color), 1f);
			}
		}

		public override void OnHitPlayer(Player player, int damage, bool crit)
		{
			if(Main.expertMode || Main.rand.Next(2) == 0)
			{
				player.AddBuff(BuffID.Frostburn, 300);
			}
		}

		public override void OnKill()
		{
			YourWorld.downedCryolisis = true;
			if (Main.rand.Next(5) == 0)
            {
                Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("CryoliteBar").Type, Main.rand.Next(9, 15));
            }
			if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("IceHeart").Type, 1);
            }
			if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("CryoliteHelmet").Type, 1);
            }
			if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("CryoliteBreastplate").Type, 1);
            }
			if (Main.rand.Next(2) == 0)
            {
                Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("CryoliteLeggings").Type, 1);
            }
			if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("IceStaff").Type, 1);
            }
			if (Main.rand.Next(1) == 0)
            {
				Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("ManuscriptCryo").Type, 1);
            }
			if (Main.rand.Next(1) == 0)
            {
				Item.NewItem(NPC.getRect(), Mod.Find<ModItem>("CorExitio").Type, Main.rand.Next(4, 10));
            }
		}

		public int GetHighestDamage()
		{
			int max = receivedDamage[0];
			int bestType = 0;
			for(int i = 1; i < 5; i++)
			{
				if(receivedDamage[i] > max)
				{
					max = receivedDamage[i];
					bestType = i;
				}
			}
			return bestType;
		}

		/*public override void BossLoot(ref string name, ref int potionType)
		{
			name = "The " + npc.TypeName;
			potionType = ItemID.HealingPotion;
			if (choice == 0)
			{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("CryoliteBar", 12));
			}
			else if (choice == 1)
		}*/ /*

		private int DropLoot(int x, int y, int w, int h, int itemId, int stack = 1, bool broadcast = false, int prefix = 0, bool nodelay = false)
		{
			return Item.NewItem(x, y, w, h, itemId, stack, broadcast, prefix, nodelay);
		}

		public override void ModifyHitByItem(Player player, Item item, ref int damage, ref float knockback, ref bool crit)
		{
			float mult = 1f;
			if(item.CountsAsClass(DamageClass.Melee))
			{
				receivedDamage[0] += damage;
				mult = 0.75f;
			}
			else if(item.CountsAsClass(DamageClass.Magic))
			{
				receivedDamage[1] += damage;
				mult = 0.6f;
			}
			else if(item.CountsAsClass(DamageClass.Ranged))
			{
				receivedDamage[2] += damage;
				mult = 0.75f;
			}
			else if(item.CountsAsClass(DamageClass.Summon))
			{
				receivedDamage[3] += damage;
				mult = 0.75f;
			}
			else if(item.CountsAsClass(DamageClass.Throwing))
			{
				receivedDamage[4] += damage;
				mult = 1.2f;
			}
			if(damage >= 5000)
			{
				Main.NewText("You're dealing too much damage!", 255, 32, 32);
				player.statDefense = 0;
				player.endurance = 0;
				player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " was frostbitten."), 9999, -player.direction,
					false, false, true, -1);
				BitLightning(player.Center);
				mult = 0f;
			}
			damage = (int)(damage * mult);
		}

		public override void ModifyHitByProjectile(Projectile projectile, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			Player player = Main.player[projectile.owner];
			float mult = 1f;
			if(projectile.CountsAsClass(DamageClass.Melee))
			{
				receivedDamage[0] += damage;
				mult = 0.75f;
			}
			else if(projectile.CountsAsClass(DamageClass.Magic))
			{
				receivedDamage[1] += damage;
				mult = 0.6f;
			}
			else if(projectile.CountsAsClass(DamageClass.Ranged))
			{
				receivedDamage[2] += damage;
				mult = 0.75f;
			}
			else if(projectile.minion)
			{
				receivedDamage[3] += damage;
				mult = 0.75f;
			}
			else if(projectile.CountsAsClass(DamageClass.Throwing))
			{
				receivedDamage[4] += damage;
				mult = 1.2f;
			}
			if(damage >= 5000)
			{
				Main.NewText("You're dealing too much damage!", 255, 32, 32);
				player.statDefense = 0;
				player.endurance = 0;
				player.Hurt(PlayerDeathReason.ByCustomReason(player.name + " was frostbitten"), 9999, -player.direction,
					false, false, true, -1);
				BitLightning(player.Center);
				mult = 0f;
			}
			damage = (int)(damage * mult);
		}

		public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
		{
			if(currentlyImmune)
			{
				damage *= 0.1f;
				SoundEngine.PlaySound(3, (int)NPC.position.X, (int)NPC.position.Y, NPC.HitSound.SoundId);
				return false;
			}
			if(stage == 0)
			{
				damage *= 4f;
			}
			return true;
		}

		public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
		{
			scale = 0f;
			return false;
		}
	}
} */