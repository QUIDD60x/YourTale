using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Items
{
    public class KnowledgeBook : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Extremely small Book of Knowledge");
            Tooltip.SetDefault("The only legible thing on this says... check the github for a tutorial?"); // \n = new line
        }

        public override void SetDefaults()
        {
            item.width = 1;
            item.height = 1;
            item.maxStack = 1;
            item.useStyle = 1;
            item.useTime = 20;
            item.useAnimation = 20;
            item.useTurn = true;
            item.autoReuse = false;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.Red;
        }

        /*public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("TMMCDust"));
        }

        public override bool UseItem(Player player)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.Hitbox.Width, player.Hitbox.Height, mod.DustType("TMMCDust"));
            return base.UseItem(player);
        }*/
    }
}