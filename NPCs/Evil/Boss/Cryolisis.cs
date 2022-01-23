/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Modules;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.InteropServices;
using System.IO;
using yourtale.Projectiles.Misc;
using yourtale.Items.Placeables;

namespace yourtale.NPCs.Evil.Boss
{
    [AutoloadBossHead]
    public class Cryolisis : ModNPC
    {
        private Player player;

        private const int CryolisisProj = 80;
        private Vector2 MoveTo;


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryocthulhu");
            Main.npcFrameCount[npc.type] = 16;
        }
        public override void SetDefaults()
        {

            npc.height = 120;
            npc.width = 320;
            npc.aiStyle = -1;
            npc.lifeMax = 6700;
            npc.damage = 20;
            npc.defense = 15;

            npc.value = 10000;
            npc.knockBackResist = 0f;
            npc.noTileCollide = true;
            npc.netAlways = true;
            npc.netUpdate = true;
            npc.noGravity = true;
            npc.boss = true;
            npc.lavaImmune = true;
            npc.ai[0] = 0;
            npc.localAI[2] = 0;
            npc.ai[2] = 0;
            npc.ai[1] = 0;
            //bossBag = mod.ItemType("");
        }
        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            return;
        }
        public override void SendExtraAI(BinaryWriter writer)
        {



            writer.Write((int)MoveTo.X);
            writer.Write((int)MoveTo.Y);
        }
        public override void ReceiveExtraAI(BinaryReader reader)
        {



            MoveTo.X = reader.ReadInt32();
            MoveTo.Y = reader.ReadInt32();

        }


        private void Target()
        {

            npc.TargetClosest(true);
            player = Main.player[npc.target];

        }
        public override void AI()
        {

            Target();

            if (player.dead) { if (npc.timeLeft > 10) { npc.timeLeft = 10; } }
            else { npc.timeLeft = 600; }
            npc.spriteDirection = npc.direction;
            int Max = Main.expertMode ? 75 : 100;
            if (npc.ai[0] == 0)
            {
                if (npc.ai[1] == 0)
                { MoveTo = player.Center + new Vector2((Main.rand.NextBool() ? -1 : 1) * 600, 0); npc.ai[1] = 1; }
                else if (npc.ai[1] == 1)
                { Move(Main.expertMode ? 13f : 10f); }
                else if (npc.ai[1] == 2)
                {
                    SpinAndShoot(Main.expertMode ? 2 : 1);
                }
                else
                {
                    npc.ai[0] = 1; npc.localAI[2] += 5f; npc.ai[1] = 0; npc.ai[2] = 0;
                    if (Main.netMode != 1)
                    {
                        npc.netUpdate = true;
                    }
                }

            }
            if (npc.ai[0] == 1)
            {
                if (npc.ai[1] == 0)
                { MoveTo = player.Center + new Vector2((npc.Center.X > player.Center.X ? -1 : 1) * 600, 0); npc.ai[1] = 1; }
                else if (npc.ai[1] == 1)
                { Move(Main.expertMode ? 13f : 10f); }
                else if (npc.ai[1] == 2)
                {
                    SpinAndShoot(Main.expertMode ? 2 : 1);
                }
                else if (npc.ai[2] < 4)
                { npc.ai[2] += 1; npc.ai[1] = 0; }
                /*else
                {
                    npc.ai[0] = 2; npc.localAI[2] += 5f; npc.ai[1] = 0; npc.ai[2] = 0; if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int projid = Projectile.NewProjectile1(player.Center.X, player.Center.Y - 1000, 0, 5, ModContent.ProjectileType<CryolisisProj>(), 0f);
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, projid);
                        npc.netUpdate = true;
                    }
                }*/

            /*} 
            if (npc.ai[0] == 2)
            {
                if (npc.ai[1] == 0)
                { MoveTo = player.Center + new Vector2((npc.Center.X > player.Center.X ? 1 : -1) * 600, -100); npc.ai[1] = 1; }
                else if (npc.ai[1] == 1)
                { MoveandDropIcicles(Main.expertMode ? 9f : 8f); }
                else if (npc.ai[1] == 2)
                {
                    SpinAndShoot(Main.expertMode ? 3 : 2);
                }
                else
                {
                    npc.ai[0] = 3; npc.ai[1] = 0; npc.ai[2] = 0; npc.localAI[2] += 5f;
                    if (Main.netMode != 1)
                    {
                        npc.netUpdate = true;
                    }
                }

            }
            if (npc.ai[0] == 3)
            {
                if (npc.ai[1] == 0)
                { MoveTo = player.Center + new Vector2((npc.Center.X > player.Center.X ? -1 : 1) * 600, -100); npc.ai[1] = 1; npc.localAI[0] = 0; }
                else if (npc.ai[1] == 1)
                { MoveandDropIcicles(Main.expertMode ? 9f : 8f); }
                else if (npc.ai[1] == 2)
                {
                    SpinAndShoot(Main.expertMode ? 3 : 2);
                }
                else if (npc.ai[2] < 4)
                { npc.ai[2] += 1; npc.ai[1] = 0; }
                else
                {
                    npc.ai[0] = 4; npc.ai[1] = 0; npc.ai[2] = 0; npc.localAI[2] += 5f;
                    if (Main.netMode != 1)
                    {
                        npc.netUpdate = true;
                    }
                }

            }
            if (npc.ai[0] == 4)
            {
                if (npc.ai[1] == 0)
                {

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int projid = Projectile.NewProjectile(player.Center.X, player.Center.Y - 1000, 0, 5, ModContent.ProjectileType<CryolisisProj>(), CryolisisProj, 0f);
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, projid);
                    }

                    MoveTo = player.Center + new Vector2(0, -300);
                    npc.ai[1] = 1;
                }
                else if (npc.ai[1] == 1)
                {
                    MoveandDropIcicles(Main.expertMode ? 9f : 8f);
                }


                else if (npc.ai[1] == 2)
                {
                    SpinAndShoot(Main.expertMode ? 4 : 3);
                }
                else
                {
                    npc.ai[0] = 0; npc.ai[1] = 0; npc.ai[2] = 0; npc.localAI[2] += 20;
                    if (Main.netMode != 1)
                    {
                        npc.netUpdate = true;
                    }
                }

            }
            if (npc.localAI[1] > 0) { npc.localAI[1] -= 1; }
            else { npc.localAI[2] -= 0.5f; }
            if (npc.localAI[2] < 0f) { npc.localAI[2] = 0f; }
            else if (npc.localAI[2] > Max) { npc.localAI[2] = Max; }

        }
        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            if (npc.localAI[1] >= 40) { npc.localAI[2] += 1.2f; }
            npc.localAI[2] += 0.3f;
            npc.localAI[1] = 60;
        }



        public override void FindFrame(int frameHeight)
        {
            int Max = Main.expertMode ? 75 : 100;
            npc.frameCounter += 1;
            npc.frameCounter %= 56;
            int frame;
            if (npc.localAI[2] >= Max)
            {
                // number of frames * tick count
                frame = (int)(npc.frameCounter / 7.0) + 8;  // only change frame every second tick
                if (frame >= Main.npcFrameCount[npc.type]) frame = 0;  // check for final frame

            }
            else
            {
                // number of frames * tick count
                frame = (int)(npc.frameCounter / 7.0);  // only change frame every second tick
                if (frame >= Main.npcFrameCount[npc.type] / 2) frame = 0;  // check for final frame

            }
            npc.frame.Y = frame * frameHeight;

        }
        public override void NPCLoot()
        {
            if (!Main.expertMode)
            {
                Item.NewItem(npc.getRect(), mod.ItemType("Cryolite"), Main.rand.Next(10, 22));
                Item.NewItem(npc.getRect(), mod.ItemType("CryoliteBar"), Main.rand.Next(5, 12));
                int rand = Main.rand.Next(1, 8);
            }
            else { npc.DropBossBags(); }
        }
        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = ItemID.GreaterHealingPotion;
        }


        private void Move(float moveSpeed)
        {
            int Max = Main.expertMode ? 75 : 100;
            // Sets the max speed of the npc.
            if (npc.localAI[2] >= Max) { moveSpeed *= 2; }
            Vector2 moveTo2 = MoveTo - npc.Bottom;
            float magnitude = Magnitude(moveTo2);
            if (magnitude > moveSpeed * 2)
            {
                moveTo2 *= moveSpeed / magnitude;
            }
            else { npc.ai[1] = 2; npc.localAI[0] = 0; }

            npc.velocity.X = (npc.velocity.X * 50f + moveTo2.X) / 51f;
            npc.velocity.Y = (npc.velocity.Y * 50f + moveTo2.Y) / 51f;
        }
        private void MoveandDropIcicles(float moveSpeed)
        {
            int Max = Main.expertMode ? 75 : 100;
            // Sets the max speed of the npc.
            if (npc.localAI[0] > 0) { npc.localAI[0] -= 1; if (npc.localAI[2] >= Max) { npc.localAI[0] -= 2; } }
            Vector2 moveTo2 = MoveTo - npc.Bottom;
            float magnitude = Magnitude(moveTo2);
            if (magnitude > moveSpeed * 2)
            {
                if (npc.localAI[0] <= 0)
                {
                    npc.localAI[0] = (Main.expertMode ? 35 : 50); if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        int projid = Projectile.NewProjectile(npc.Center, Vector2.Zero, (Main.expertMode ? ModContent.ProjectileType<CryolisisProj>() : ModContent.ProjectileType<CryolisisProj>() : ModContent.ProjectileType<CryolisisProj>() : ModContent.ProjectileType<CryolisisProj>()), 0f);
                        NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, projid);
                    }
                }
                moveTo2 *= moveSpeed / magnitude;
            }
            else { npc.ai[1] = 2; npc.localAI[0] = 0; }

            npc.velocity.X = (npc.velocity.X * 50f + moveTo2.X) / 51f;
            npc.velocity.Y = (npc.velocity.Y * 50f + moveTo2.Y) / 51f;
        }
        private void SpinAndShoot(int numTurns)
        {
            int Max = Main.expertMode ? 75 : 100;
            if (npc.localAI[2] >= Max) { numTurns *= 4; }


            npc.rotation += 0.1f;
            npc.velocity *= 0.9f;
            npc.position.X += (float)Math.Cos(npc.rotation) * 10f * npc.direction;
            npc.position.Y += (float)Math.Sin(npc.rotation) * 10f * npc.direction;
            npc.localAI[0] += 0.1f;
            if (npc.localAI[2] >= Max) { npc.rotation += 0.25f; npc.localAI[0] += 0.25f; }
            if (npc.rotation >= numTurns * 6)
            { npc.ai[1] = 3; npc.rotation = 0; npc.localAI[0] = 0; }
            if (npc.localAI[0] >= 2.5f)
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int projid = Projectile.NewProjectile(npc.Center, ShootAtPlayer(Main.expertMode ? 9f : 6f), (Main.expertMode ? ModContent.ProjectileType<CryolisisProj>() : ModContent.ProjectileType<CryolisisProj>()), 0f);
                    NetMessage.SendData(MessageID.SyncProjectile, -1, -1, null, projid);
                }
                npc.localAI[0] = 0;
            }
        }
        private float Magnitude(Vector2 mag)// does funky pythagoras to find distance between two points
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
        private Vector2 ShootAtPlayer(float moveSpeed)
        {
            // Sets the max speed of the npc.
            Vector2 moveTo2 = player.Top - npc.Bottom;
            float magnitude = Magnitude(moveTo2);

            moveTo2 *= moveSpeed / magnitude;
            return moveTo2;



        }
        private void DespawnHandler()
        {
            if (!player.active || player.dead)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                if (!player.active || player.dead)
                {
                    npc.velocity = new Vector2(0f, -10f);
                    if (npc.timeLeft > 2)
                    {
                        npc.timeLeft = 2;
                    }
                    return;
                }
            }
        }
    }
} */