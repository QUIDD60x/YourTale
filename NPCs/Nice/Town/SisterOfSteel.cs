using yourtale.Dusts;
using yourtale.Items;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using YourTale.Items.Weapons.Melee.Sword;
using YourTale.Items;
using yourtale.Items.Placeables;

namespace yourtale.NPCs.Nice.Town
{
    // [AutoloadHead] and NPC.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
	public class SisterOfSteel : ModNPC
	{
		public int NumberOfTimesTalkedTo = 0;

		public override void SetStaticDefaults()
		{
			// DisplayName automatically assigned from localization files, but the commented line below is the normal approach.
			// DisplayName.SetDefault("Example Person");
			Main.npcFrameCount[Type] = 23; // The amount of frames the NPC has

			NPCID.Sets.ExtraFramesCount[Type] = 9; // Generally for Town NPCs, but this is how the NPC does extra things such as sitting in a chair and talking to other NPCs.
			NPCID.Sets.AttackFrameCount[Type] = 4;
			NPCID.Sets.DangerDetectRange[Type] = 1; // The amount of pixels away from the center of the npc that it tries to attack enemies.
			NPCID.Sets.AttackType[Type] = 1;
			NPCID.Sets.AttackTime[Type] = 80; // The amount of time it takes for the NPC's attack animation to be over once it starts.
			NPCID.Sets.AttackAverageChance[Type] = 20;
			NPCID.Sets.HatOffsetY[Type] = 4; // For when a party is active, the party hat spawns at a Y offset.

			// Influences how the NPC looks in the Bestiary
			NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new(0)
			{
				Velocity = 1f, // Draws the NPC in the bestiary as if its walking +1 tiles in the x direction
				Direction = 1 // -1 is left and 1 is right. NPCs are drawn facing the left by default but ExamplePerson will be drawn facing the right
							  // Rotation = MathHelper.ToRadians(180) // You can also change the rotation of an NPC. Rotation is measured in radians
							  // If you want to see an example of manually modifying these when the NPC is drawn, see PreDraw
			};

			NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

			// Set Example Person's biome and neighbor preferences with the NPCHappiness hook. You can add happiness text and remarks with localization (See an example in ExampleMod/Localization/en-US.lang).
			// NOTE: The following code uses chaining - a style that works due to the fact that the SetXAffection methods return the same NPCHappiness instance they're called on.
			NPC.Happiness
				.SetBiomeAffection<HallowBiome>(AffectionLevel.Like)
				.SetBiomeAffection<ForestBiome>(AffectionLevel.Dislike)
				.SetBiomeAffection<SnowBiome>(AffectionLevel.Love)
				.SetNPCAffection(NPCID.Steampunker, AffectionLevel.Love)
				.SetNPCAffection(NPCID.Dryad, AffectionLevel.Like)
				.SetNPCAffection(NPCID.Princess, AffectionLevel.Dislike)
				.SetNPCAffection(NPCID.Guide, AffectionLevel.Hate)
			; // < Mind the semicolon!
		}

		public override void SetDefaults()
		{
			NPC.townNPC = true; // Sets NPC to be a Town NPC
			NPC.friendly = true; // NPC Will not attack player
			NPC.width = 18;
			NPC.height = 40;
			NPC.aiStyle = 7;
			NPC.damage = 225;
			NPC.defense = 40;
			NPC.lifeMax = 250;
			NPC.HitSound = SoundID.FemaleHit;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = 0.5f;

			AnimationType = NPCID.Guide;
		}

		public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
		{
			// We can use AddRange instead of calling Add multiple times in order to add multiple items at once
			bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
				// Sets the preferred biomes of this town NPC listed in the bestiary.
				// With Town NPCs, you usually set this to what biome it likes the most in regards to NPC happiness.
				BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				// Sets your NPC's flavor text in the bestiary.
				new FlavorTextBestiaryInfoElement("A member of the secritive Sisterhood of Steel, she has a keen intrest in you."),

				// You can add multiple elements if you really wanted to
				// You can also use localization keys (see Localization/en-US.lang)
				new FlavorTextBestiaryInfoElement("Mods.ExampleMod.Bestiary.ExamplePerson")
			});
		}

		// The PreDraw hook is useful for drawing things before our sprite is drawn or running code before the sprite is drawn
		// Returning false will allow you to manually draw your NPC
		public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			// This code slowly rotates the NPC in the bestiary
			// (simply checking NPC.IsABestiaryIconDummy and incrementing NPC.Rotation won't work here as it gets overridden by drawModifiers.Rotation each tick)
			if (NPCID.Sets.NPCBestiaryDrawOffset.TryGetValue(Type, out NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers))
			{
				drawModifiers.Rotation += 0.001f;

				// Replace the existing NPCBestiaryDrawModifiers with our new one with an adjusted rotation
				NPCID.Sets.NPCBestiaryDrawOffset.Remove(Type);
				NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);
			}

			return true;
		}

		public override void HitEffect(int hitDirection, double damage)
		{
			int num = NPC.life > 0 ? 1 : 5;

			for (int k = 0; k < num; k++)
			{
				Dust.NewDust(NPC.position, NPC.width, NPC.height, ModContent.DustType<AncientGoldDust>());
			}
		}

		public override bool CanTownNPCSpawn(int numTownNPCs, int money)
		{ // Requirements for the town NPC to spawn.
			for (int k = 0; k < 255; k++)
			{
				Player player = Main.player[k];
				if (!player.active)
				{
					continue;
				}

				// Player has to have either an ExampleItem or an ExampleBlock in order for the NPC to spawn
				if (player.inventory.Any(item => item.type == ModContent.ItemType<SeraphClaws>()))
				{
					return true;
				}
			}

			return false;
		}

		public override ITownNPCProfile TownNPCProfile()
		{
			return new ExamplePersonProfile();
		}

		public override List<string> SetNPCNameList()
		{
			return new List<string>() {
				"Sara",
				"Sarah",
				"Samantha",
				"Katherine",
				"Catherine",
				"Kate",
				"Lyssa",
				"Abigail",
				"Ann"
			};
		}

		public override void FindFrame(int frameHeight)
		{
			/*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
		}

		public override string GetChat()
		{
			WeightedRandom<string> chat = new();

			int stylist = NPC.FindFirstNPC(NPCID.Stylist);
			if (stylist >= 0 && Main.rand.NextBool(4))
			{
				chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.PartyGirlDialogue", Main.npc[stylist].GivenName));
			}
			// These are things that the NPC has a chance of telling you when you talk to it.
			chat.Add(Language.GetTextValue("You know, there weren't a whole let of men at the Sisterhood. There were none at all, actually..."));
			chat.Add(Language.GetTextValue("My bark is nowhere near my bite."));
			chat.Add(Language.GetTextValue("Stop asking to see if I have abs."));
			chat.Add(Language.GetTextValue("If you have any ancient things laying around I could possibly fix them..."));
			chat.Add(Language.GetTextValue("Even our nurse ends up resorting to violence, what world have we come to?"));
			chat.Add(Language.GetTextValue("The sisterhood could use a killer like you."));
			chat.Add(Language.GetTextValue("Our workout techniques from the Sisterhood could be a bit... outlandish."));
			chat.Add(Language.GetTextValue("Why do guys smell so bad?"));
			chat.Add(Language.GetTextValue("How do we keep our numbers high? Recruiting, of course!"));
			chat.Add(Language.GetTextValue("I originally came here to kill that guide guy, but after hearing some rumors about what he is I'm not so sure anymore..."));

			NumberOfTimesTalkedTo++;
			if (NumberOfTimesTalkedTo >= 100)
			{
				//This counter is linked to a single instance of the NPC, so if ExamplePerson is killed, the counter will reset.
				chat.Add(Language.GetTextValue("Why the hell are you talking to me so much? I'm not in ANY kind of mood."));
			}

			return chat; // chat is implicitly cast to a string.
		}

		public override void SetChatButtons(ref string button, ref string button2)
		{ // What the chat buttons are when you open up the chat UI
			button = Language.GetTextValue("LegacyInterface.28");
			button2 = " ";
			if (Main.LocalPlayer.HasItem(Mod.Find<ModItem>("AncientAnvil").Type))
			{
				button = ("Upgrade Anvil");
			}
		}

		public override void OnChatButtonClicked(bool firstButton, ref bool shop)
		{
			if (firstButton)
			{
				// We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.

				if (Main.LocalPlayer.HasItem(Mod.Find<ModItem>("AncientAnvil").Type))
				{
					SoundEngine.PlaySound(SoundID.Item37); // Reforge/Anvil sound

					Main.npcChatText = $"Presto! I upgraded that crappy Ancient Anvil to a Thendric anvil of the highest quality!";

					int AncientAnvilItemIndex = Main.LocalPlayer.FindItem(Mod.Find<ModItem>("AncientAnvil").Type);
					var entitySource = NPC.GetSource_GiftOrReward();

					Main.LocalPlayer.inventory[AncientAnvilItemIndex].TurnToAir();
					Main.LocalPlayer.QuickSpawnItem(entitySource, ModContent.ItemType<AncientAnvil2>());

					return;
				}

				shop = true;
			}
		}

		// Not completely finished, but below is what the NPC will sell

		// public override void SetupShop(Chest shop, ref int nextSlot) {
		// 	shop.item[nextSlot++].SetDefaults(ItemType<ExampleItem>());
		// 	// shop.item[nextSlot].SetDefaults(ItemType<EquipMaterial>());
		// 	// nextSlot++;
		// 	// shop.item[nextSlot].SetDefaults(ItemType<BossItem>());
		// 	// nextSlot++;
		// 	shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleWorkbench>());
		// 	shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleChair>());
		// 	shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleDoor>());
		// 	shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleBed>());
		// 	shop.item[nextSlot++].SetDefaults(ItemType<Items.Placeable.Furniture.ExampleChest>());
		// 	shop.item[nextSlot++].SetDefaults(ItemType<ExamplePickaxe>());
		// 	shop.item[nextSlot++].SetDefaults(ItemType<ExampleHamaxe>());
		//
		//
		//
		//
		//
		// 	// if (!Main.LocalPlayer.GetModPlayer<ExamplePlayer>().examplePersonGiftReceived && GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList != null) {
		// 	// 	foreach (var item in GetInstance<ExampleConfigServer>().ExamplePersonFreeGiftList) {
		// 	// 		if (Item.IsUnloaded) continue;
		// 	// 		shop.item[nextSlot].SetDefaults(Item.Type);
		// 	// 		shop.item[nextSlot].shopCustomPrice = 0;
		// 	// 		shop.item[nextSlot].GetGlobalItem<ExampleInstancedGlobalItem>().examplePersonFreeGift = true;
		// 	// 		nextSlot++;
		// 	// 		//TODO: Have tModLoader handle index issues.
		// 	// 	}
		// 	// }
		// }

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SeraphClaws>()));
		}

		// Make this Town NPC teleport to the King and/or Queen statue when triggered.
		public override bool CanGoToStatue(bool toQueenStatue) => true;

		// Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
		/*public override void OnGoToStatue(bool toKingStatue)
		{
			if (Main.netMode == NetmodeID.Server)
			{
				ModPacket packet = Mod.GetPacket();
				packet.Write((byte)yourtale.MessageType.ExampleTeleportToStatue);
				packet.Write((byte)NPC.whoAmI);
				packet.Send();
			}
			else
			{
				StatueTeleport();
			}
		}*/

		// Create a square of pixels around the NPC on teleport.
		public void StatueTeleport()
		{
			for (int i = 0; i < 30; i++)
			{
				Vector2 position = Main.rand.NextVector2Square(-20, 21);
				if (Math.Abs(position.X) > Math.Abs(position.Y))
				{
					position.X = Math.Sign(position.X) * 20;
				}
				else
				{
					position.Y = Math.Sign(position.Y) * 20;
				}

				Dust.NewDustPerfect(NPC.Center + position, ModContent.DustType<AncientGoldDust>(), Vector2.Zero).noGravity = true;
			}
		}

		public override void TownNPCAttackStrength(ref int damage, ref float knockback)
		{
			damage = 20;
			knockback = 2f;
		}

		public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
		{
			cooldown = 30;
			randExtraCooldown = 30;
		}

		// todo: implement
		// public override void TownNPCAttackProj(ref int projType, ref int attackDelay) {
		// 	projType = ProjectileType<SparklingBall>();
		// 	attackDelay = 1;
		// }

		public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
		{
			multiplier = 12f;
			randomOffset = 2f;
		}

		public override void LoadData(TagCompound tag)
		{
			NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
		}

		public override void SaveData(TagCompound tag)
		{
			tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
		}
	}

	public class ExamplePersonProfile : ITownNPCProfile
	{
		public int RollVariation() => 0;
		public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

		public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
		{
			if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
				return ModContent.Request<Texture2D>("yourtale/NPCs/Nice/Town/SisterOfSteel");

			if (npc.altTexture == 1)
				return ModContent.Request<Texture2D>("yourtale/NPCs/Nice/Town/SisterOfSteel_Party");

			return ModContent.Request<Texture2D>("yourtale/NPCs/Nice/Town/SisterOfSteel");
		}

		public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("yourtale/NPCs/Nice/Town/SisterOfSteel_Head");
	}
}