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
    public class StarShard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Star Shard");
            Tooltip.SetDefault("It radiates a small amount of warm energy..."); // \n = new line
        }

        public override void SetDefaults()
        {
            Item.width = 1;
            Item.height = 1;
            Item.maxStack = 999;
            Item.useStyle = 2;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item25;
            Item.rare = ItemRarityID.Blue;
            Item.flame = true;
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

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            if (Main.rand.Next(3) == 0)
                Dust.NewDust(new Vector2(player.position.X, player.position.Y), player.Hitbox.Width, player.Hitbox.Height, Mod.Find<ModDust>("StarShine").Type);
            return base.UseItem(player);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(10);//can add recipe.SetResult(this, number here) for making multiple
            recipe.AddIngredient(ItemID.FallenStar, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}