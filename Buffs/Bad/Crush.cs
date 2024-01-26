using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;

namespace YourTale.Buffs.Bad
{
	public class Crush : ModBuff
	{
		public override void SetStaticDefaults()
		{
            Main.debuff[Type] = true;
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<CrushDebuffNPC>().markedWithCrush = true;
			npc.velocity = Vector2.Zero;
			npc.defense /= 2;
			npc.defense--;

            Dust dust;
			Vector2 position = npc.Center; 
			dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, DustID.DungeonBlue, 0f, -0.4651165f, 160, new Color(255,255,255), 1f)]; 
			dust.fadeIn = 0.627907f;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            base.Update(player, ref buffIndex);
			player.statDefense += 10;
        }
    }

	public class CrushDebuffNPC : GlobalNPC
	{
		// This is required to store information on entities that isn't shared between them.
		public override bool InstancePerEntity => true;

		public bool markedWithCrush;

		public override void ResetEffects(NPC npc)
		{
			markedWithCrush = false;
		}

		// TODO: Inconsistent with vanilla, increasing damage AFTER it is randomised, not before. Change to a different hook in the future.
	}
}