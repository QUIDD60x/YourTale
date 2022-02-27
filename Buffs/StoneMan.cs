using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace yourtale.Buffs
{ 
    public class StoneMan : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Rock Solid");
            Description.SetDefault("You're stuck between a rock and a... nother rock.");
            Main.debuff[Type] = false; //Debuffs cannot be canceled, buffs can. Make sure to include this!
            longerExpertDebuff = true; //This will increase the time for the buff if you're in expert mode.
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            //This is the dust it will spawn on you if hit.

            int DustID = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width + 1, npc.height + 1, 273, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 120, default(Color), 2f);
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
