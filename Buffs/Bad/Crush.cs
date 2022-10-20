using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace yourtale.Buffs.Bad
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
			npc.defense = 0;
			npc.knockBackResist = 100;
			npc.velocity = Vector2.Zero;
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