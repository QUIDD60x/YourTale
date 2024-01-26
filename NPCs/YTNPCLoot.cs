using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.Items;
using YourTale.Items.Weapons.Melee.Sword;
using YourTale.DropConditions;
using YourTale.Items.Placeables;
using System.Collections.Generic;

namespace YourTale.NPCs
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
			if (npc.type == NPCID.AngryBones || npc.type == NPCID.DarkCaster || npc.type == NPCID. CursedSkull || npc.type == NPCID.Skeleton || npc.type == NPCID.SkeletonArcher)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SpiritShard1>(), 10, 1, 7));
			}
			if (npc.type == NPCID.Nymph)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Ambrosia>(), 50, 1, 5));
			}
            if (npc.type == NPCID.Raven)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RavenFeather>(), 1, 3, 7));
            }


        }

        /*public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
		{
			// This example does not use the AppliesToEntity hook, as such, we can handle multiple npcs here by using if statements.
			if (npc.type == NPCID.Dryad)
			{
				// Adding an item to a vanilla NPC is easy:
				// This item sells for the normal price.
				shop.item[nextSlot].SetDefaults(ModContent.ItemType<CorpseSeeds>());
				shop.item[nextSlot].shopCustomPrice = 550;
				nextSlot++; // Don't forget this line, it is essential.
			}
		}*/

		// ModifyGlobalLoot allows you to modify loot that every NPC should be able to drop, preferably with a condition.
		public override void ModifyGlobalLoot(GlobalLoot globalLoot)
		{
			globalLoot.Add(ItemDropRule.ByCondition(new YTSoulCondition(), ModContent.ItemType<LifeShard>(), 5, 1, 1));
		}
	}
}