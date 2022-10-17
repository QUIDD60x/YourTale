using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader.Utilities;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using System.IO;

namespace yourtale.NPCs.Evil
{
    public class DuneGolem : ModNPC // ModNPC is used for Custom NPCs
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dune Golem");
        }

        public override void SetDefaults()
        {
            NPC.width = 36;
            NPC.height = 80;
            NPC.damage = 20;
            NPC.defense = 10;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit41;
            NPC.DeathSound = SoundID.NPCDeath43;
            NPC.value = 100f;
            NPC.knockBackResist = 0.75f;
            NPC.aiStyle = 3;
            Main.npcFrameCount[NPC.type] = Main.npcFrameCount[NPCID.RockGolem];
            //AIType = NPCID.RockGolem;
            AnimationType = NPCID.RockGolem;
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return SpawnCondition.OverworldDaySandCritter.Chance * 2f;
        }

        private int attackCounter; //Attack counter and projectile code taken directly from tsuchinoko.
        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(attackCounter);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            attackCounter = reader.ReadInt32();
        }

        public override void AI()
        {
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                if (attackCounter > 0)
                {
                    attackCounter--; // tick down the attack counter.
                }

                Player target = Main.player[NPC.target];
                // If the attack counter is 0, this NPC is less than 12.5 tiles away from its target, and has a path to the target unobstructed by blocks, summon a projectile.
                if (attackCounter <= 0 && Vector2.Distance(NPC.Center, target.Center) < 200 && Collision.CanHit(NPC.Center, 1, 1, target.Center, 1, 1))
                {
                    Vector2 direction = (target.Center - NPC.Center).SafeNormalize(Vector2.UnitX);
                    direction = direction.RotatedByRandom(MathHelper.ToRadians(10));

                    int projectile = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, direction * 1, ProjectileID.Fireball, 14, 0, Main.myPlayer);
                    Main.projectile[projectile].timeLeft = 300;
                    attackCounter = 500;
                    NPC.netUpdate = true;
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 10; i++)
            {
                Dust dust;  
                Vector2 position = Main.LocalPlayer.Center; 
                dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, DustID.DynastyWall, 0f, 0f, 0, new Color(255,255,255), 1f)]; 
                dust.noGravity = true; 
                dust.fadeIn = 1.8139534f;
            }

        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.FossilOre, 1, 1, 7));
            npcLoot.Add(ItemDropRule.Common(ItemID.ZombieArm, 10, 1, 1));
        }
    }
}