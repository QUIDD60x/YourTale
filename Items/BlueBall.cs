using Terraria;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Dusts;

namespace yourtale.Items
{
    public class BlueBall : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = 50;
            Item.useAnimation = 50;
            Item.useTurn = true;
            Item.autoReuse = false;
            Item.UseSound = SoundID.Item25;
            Item.rare = ItemRarityID.Blue;
        }
        public override void HoldItem(Player player)
        {
            if (Main.rand.NextBool(player.itemAnimation > 0 ? 40 : 80))
            {
                Dust.NewDust(new Vector2(player.itemLocation.X + 1f * player.direction, player.itemLocation.Y - 1f * player.gravDir), 4, 4, ModContent.DustType<StarShine>());
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.NextBool(3))
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, Mod.Find<ModDust>("StarShine").Type);
        }
    }
}