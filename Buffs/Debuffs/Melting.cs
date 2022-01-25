using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace yourtale.Buffs.Debuffs
{
    public class Melting : ModBuff
    {




        public override void SetDefaults()
        {
            DisplayName.SetDefault("Tsuchinoko Poison");
            Description.SetDefault("Your skin is melting off?!");
            Main.debuff[Type] = true;
           longerExpertDebuff = true;



        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            

            int DustID = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y + 2f), npc.width + 1, npc.height + 1, 273, npc.velocity.X * 0.2f, npc.velocity.Y * 0.2f, 120, default(Color), 2f);
            Main.dust[DustID].noGravity = true;




        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen /= 2;
            player.meleeDamage -= 0.5f;
            player.moveSpeed -= 0.7f;
            player.statLifeMax2 -=20;
        }





    }
}
