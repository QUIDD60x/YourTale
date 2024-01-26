using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.IO;
using yourtale;
using Yourtale;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using System.IO;
// using YourTale.Items.Consumables.BossBags;
using YourTale.Projectiles.Evil;

namespace YourTale.NPCs.Evil.Boss.TreeGuardian
{
    [AutoloadBossHead]
    public class TreeGuardian : ModNPC
    {
        // These are seperate values used for the AI, on how to give a warning sign before the attack. This was too much work.
        private int delayTimer;
        private int warningTimer;
        private bool warningActivated;

        //[AutoloadBossHead]
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
            NPCID.Sets.MPAllowedEnemies[Type] = true;
            NPCID.Sets.BossBestiaryPriority.Add(Type);

        }
        // I love you github copilot
        // I love you too

        public override void SetDefaults()
        {
            NPC.aiStyle = -1;
            NPC.lifeMax = 900;
            NPC.damage = 11;
            NPC.defense = 5;
            NPC.knockBackResist = 0f;
            NPC.width = 70;
            NPC.height = 100;
            NPC.value = 0;
            NPC.npcSlots = 8f;
            NPC.boss = true;
            NPC.lavaImmune = false;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
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
                new FlavorTextBestiaryInfoElement("A protector of trees. Not the lorax!")
            });
        }
        // set the NPC's loot
        /*
        public override void OnKill()
        {
            if (!Main.expertMode)
            {
                Item.NewItem(NPC.getRect(), ModContent.ItemType<Items.Consumables.Summoning.SummonWood>(), 1);
            }
            else
            {
                Item.NewItem(NPC.getRect(), ModContent.ItemType<Items.Consumables.Summoning.SummonWood>(), 2);
            }
        }*/

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = ImmunityCooldownID.Bosses;
            return true;
        }

        public int bolt = ModContent.ProjectileType<TreeBlast>();

        public override void AI()
        {
            Player target = Main.player[NPC.target];
            float fixedDistance = 30f;
            float randomX = Main.rand.NextFloat(-150f, 150f);
            Vector2 spawnPosition = new Vector2(target.Center.X + randomX, target.Center.Y + fixedDistance);
            Vector2 direction = -Vector2.UnitY;

            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (delayTimer > 0)
                {
                    delayTimer--;
                    // You can add any other logic or effects during the delay here
                }
                else
                {
                    if (warningTimer > 0)
                    {
                        // Warning phase
                        warningTimer--;

                        // Spawn warning dust particles at the calculated position (where the projectile will spawn)
                            Dust dust;
                            dust = Main.dust[Terraria.Dust.NewDust(spawnPosition, 23, 116, 291, 0f, -7.44186f, 0, new Color(255, 255, 255), 1.1046512f)];
                            dust.fadeIn = 1.0813954f;

                    }
                    else if (!warningActivated)
                    {
                        // Spawn the projectile at the calculated position
                        int projectile = Projectile.NewProjectile(target.GetSource_FromThis(), spawnPosition, Vector2.UnitY, bolt, 20, 2);

                        // Set projectile timeLeft
                        Main.projectile[projectile].timeLeft = 300;

                        // Set the delay timer to 120 frames (2 seconds at 60 frames per second)
                        delayTimer = 240;
                        // Reset the warning timer for subsequent uses
                        warningTimer = 240;

                        NPC.netUpdate = true;
                    }
                }
            }
        }

    }
}