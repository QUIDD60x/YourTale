using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace YourTale.Buffs.Good
{
    public class StoneMan : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false; //Debuffs cannot be canceled, buffs can. Make sure to include this
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            //This is the dust it will spawn on you if hit.

            int DustID = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width + 1, npc.height + 1, 273, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 120, default, 2f);
            Main.dust[DustID].noGravity = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 36;
            player.endurance *= 5;
            player.statDefense *= 5;
            player.AddBuff(BuffID.Stoned, 6);
        }
    }
}
