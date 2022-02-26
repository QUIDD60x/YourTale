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
    public class flint : ModItem
    {
        public override void SetStaticDefaults() 
        {
            DisplayName.SetDefault("Flint Shard");
            Tooltip.SetDefault("I can probably make tools with this if I can find some stone nearby..."); // \n = new line
        }

        public override void SetDefaults()
        {
            item.width = 1;
            item.height = 1;
            item.maxStack = 999;
            item.useStyle = 1;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.rare = ItemRarityID.White;
            item.createTile = TileType<Tiles.Ores.FlintDeposit>();
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("nothinghereyeteither"));
        }

        public override bool UseItem(Player player)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.Hitbox.Width, player.Hitbox.Height, mod.DustType("nothinghereyet"));
            return base.UseItem(player);
        }
    }
}