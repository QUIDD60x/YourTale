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

namespace YourTale.Items
{
    public class KnowledgeBook : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 1;
            Item.height = 1;
            Item.maxStack = 1;
            Item.useStyle = 1;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useTurn = true;
            Item.autoReuse = false;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Red;
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