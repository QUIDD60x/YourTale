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
    public class EmeraldFang : ModItem // IDK what to add for this yet.
    {
        /*public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("This emerald fang will increase your max life and movement speed.");
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
            player.statLifeMax2 += 80 - player.statLifeMax2;


        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Emerald, 3);
            recipe.AddIngredient(ItemType<CrackedWolfFang>(), 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }*/
    }
}