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
using yourtale.Dusts;

namespace yourtale.Items
{
    public class LifeShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Shard");
            Tooltip.SetDefault("Very unpure, how could I filter it?"); // \n = new line
        }

        public override void SetDefaults()
        {
            item.width = 1;
            item.height = 1;
            item.maxStack = 999;
            item.useStyle = 2;
            item.useTime = 10;
            item.useAnimation = 10;
            item.useTurn = true;
            item.autoReuse = true;
            item.UseSound = SoundID.Item25;
            item.rare = ItemRarityID.Blue;
            item.flame = true;
        }
        public override void HoldItem(Player player)
        {
            if (Main.rand.Next(player.itemAnimation > 0 ? 40 : 80) == 0)
            {
                Dust.NewDust(new Vector2(player.itemLocation.X + 1f * player.direction, player.itemLocation.Y - 1f * player.gravDir), 1, 1, ModContent.DustType<LifeStaffDust>());
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, mod.DustType("LifeStaffDust"));
        }

        public override bool UseItem(Player player)
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.Hitbox.Width, player.Hitbox.Height, mod.DustType("LifeStaffDust"));
            return base.UseItem(player);
        }
        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 5); //can add recipe.SetResult(this, number here) for making multiple
            recipe.AddRecipe();
        }
    }
}