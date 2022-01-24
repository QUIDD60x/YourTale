using Terraria;
using yourtale.Dusts;
using Terraria.ModLoader;
using Terraria.ID;
using yourtale.Items.Placeables;
using yourtale.Items.Accessories;

namespace yourtale.NPCs.Evil
{
    public class IcePixie : ModNPC // ModNPC is used for Custom NPCs
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ice Pixie");
        }

        public override void SetDefaults()
        {
            /* Removed as of 0.10
            //npc.name = "Tutorial Zombie";
            //npc.displayName = "Tutorial Zombie";
            */
            npc.width = 18;
            npc.height = 40;
            npc.damage = 7;
            npc.defense = 6;
            npc.lifeMax = 85;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath2;
            npc.value = 388f; //how much money is dropped (why is it a float? Change soon please)
            npc.knockBackResist = 0.4f;
            npc.aiStyle = 22; //basic walker AI
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.Pixie]; //Main.npcFrameCount[3];
            aiType = NPCID.Pixie; // aiType = 3;
            animationType = NPCID.Pixie; // animationType = 3;
            banner = Item.NPCtoBanner(NPCID.Pixie); //Gets NPC to banner
            bannerItem = Item.BannerToItem(banner);
            npc.noGravity = true;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return (Main.tile[spawnInfo.playerFloorX, spawnInfo.playerFloorY].type == TileID.SnowBlock).ToInt() * 0.5f;

            float chance = 10f;
            if (!Main.dayTime)
            {
                chance += 5f;
                if (spawnInfo.player.ZoneSnow)
                {    
                    {
                        chance += 8f;
                    }
                }
            }
            return chance;
        }
        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            {
                int dustType = mod.DustType("IceDust");
                int dustIndex = Dust.NewDust(npc.position, npc.width, npc.height, dustType);
                Dust dust = Main.dust[dustIndex];
                dust.velocity.X = dust.velocity.X + Main.rand.Next(-50, 51) * 0.01f;
                dust.velocity.Y = dust.velocity.Y + Main.rand.Next(-50, 51) * 0.01f;
                dust.scale *= 1f + Main.rand.Next(-30, 31) * 0.01f;
            }

        }
        public override void NPCLoot() //do mod.ItemType instead of ItemID for modded items
        {
            /*Will make NPC always drop entered loot
            Item.NewItem(npc.position, ItemID.Gel, 100);*/
            if (Main.rand.Next(4) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("Cryolite"), Main.rand.Next(3, 9));
            }
            if (Main.rand.Next(6) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("IceHeart"));
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("CryoliteBreastplate"), 1);
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("CryoliteHelmet"), 1);
            }
            if (Main.rand.Next(10) == 0)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("CryoliteLeggings"), 1);
            }
            
        }
    }
}