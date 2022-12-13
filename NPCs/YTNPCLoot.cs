using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Items;
using YourTale.Items.Weapons.Melee.Sword;
using YourTale.DropConditions;
using yourtale.Items.Placeables;

namespace yourtale.NPCs
{
	// This file shows numerous examples of what you can do with the extensive NPC Loot lootable system.
	// You can find more info on the wiki: https://github.com/tModLoader/tModLoader/wiki/Basic-NPC-Drops-and-Loot-1.4
	// Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
	public class YTNPCLoot : GlobalNPC
	{
		// ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
		// Here we go through all of them, and how they can be used.
		// There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.

		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (!NPCID.Sets.CountsAsCritter[npc.type])
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LifeShard>(), 80, 1));
			}

			if (npc.type == NPCID.Skeleton || npc.type == NPCID.SkeletonArcher || npc.type == NPCID.ArmoredSkeleton || npc.type == NPCID.ArmoredViking)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AncientShard>(), 1, 4, 9));
			}

			if (npc.type == NPCID.EyeofCthulhu || npc.type == NPCID.KingSlime || npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.BrainofCthulhu || npc.type == NPCID.QueenBee || npc.type == NPCID.SkeletronHead || npc.type == NPCID.Deerclops || npc.type == NPCID.WallofFlesh || npc.type == NPCID.QueenSlimeBoss || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism || npc.type == NPCID.SkeletronPrime || npc.type == NPCID.Plantera || npc.type == NPCID.Golem || npc.type == NPCID.DukeFishron || npc.type == NPCID.EmpressButterfly || npc.type == NPCID.CultistBoss || npc.type == NPCID.MoonLordCore)
            {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CorExitio>(), 1, 9, 15));
            }
			if (npc.type == NPCID.Retinazer)
            {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<YellowBall>(), 1));
            }
			if (npc.type == NPCID.TheDestroyer)
            {
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GreenBall>(), 1));
            }
			if (npc.type == NPCID.Spazmatism)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BlueBall>(), 1));
			}
			if (npc.type == NPCID.SkeletronPrime)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<OrangeBall>(), 1));
			}
			if (npc.type == NPCID.Werewolf || npc.type == NPCID.Wolf)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrackedWolfFang>(), 4, 1));
			}



		}

		public override void SetupShop(int type, Chest shop, ref int nextSlot)
		{
			// This example does not use the AppliesToEntity hook, as such, we can handle multiple npcs here by using if statements.
			if (type == NPCID.Dryad)
			{
				// Adding an item to a vanilla NPC is easy:
				// This item sells for the normal price.
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<CorpseSeeds>());
				shop.item[nextSlot].shopCustomPrice = 550;
				nextSlot++; // Don't forget this line, it is essential.
			}
		}

		// ModifyGlobalLoot allows you to modify loot that every NPC should be able to drop, preferably with a condition.
		// Vanilla uses this for the biome keys, souls of night/light, as well as the holiday drops.
		// Any drop rules in ModifyGlobalLoot should only run once. Everything else should go in ModifyNPCLoot.
		public override void ModifyGlobalLoot(GlobalLoot globalLoot)
		{
			// If the ExampleSoulCondition is true, drop ExampleSoul 5% of the time. See Common/ItemDropRules/DropConditions/ExampleSoulCondition.cs for how it's determined
			globalLoot.Add(ItemDropRule.ByCondition(new YTSoulCondition(), ModContent.ItemType<CorExitio>(), 5, 1, 1));
		}
	}
}