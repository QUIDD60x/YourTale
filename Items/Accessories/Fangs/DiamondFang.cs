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
using rail;
using yourtale.Items;

namespace yourtale.Items.Accessories.Fangs
{
    public class DiamondFang : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This diamond-imbued fang gives up to 20 defense, minus the defense you have.");
        }

        public override void SetDefaults()
        {
            Item.width = 1;
            Item.accessory = true;
            Item.height = 1;
            Item.maxStack = 1;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.UseSound = SoundID.Item1;
            Item.rare = ItemRarityID.Green;
        }

        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);
            player.statDefense += 20 - player.statDefense;


        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddIngredient(ItemType<CrackedWolfFang>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}