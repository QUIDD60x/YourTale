using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace yourtale.Items.Placeables
{
    public class CryoliteBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryolite Bar");
            Tooltip.SetDefault("I can barely touch this, it's colder than dry ice!"); // \n = new line
        }
        public override void SetDefaults()
        {
            Item.height = 12;
            Item.width = 12;
            Item.rare = ItemRarityID.Blue;
            Item.value = 300;

            Item.autoReuse = true;
            Item.useTurn = true;
            Item.useTime = 10;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing;

            Item.consumable = true;
            Item.maxStack = 999;

            Item.createTile = TileType<Tiles.Bars.CryoliteBar>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("Cryolite").Type, 4);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}