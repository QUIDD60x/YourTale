using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yourtale.NPCs.Evil.Boss;

namespace yourtale.Items.Consumables.Summoning
{
    public class Slime_Crown : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
            item.height = 22;
            item.maxStack = 20;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Crown");
            Tooltip.SetDefault("\nSummons the King Slime \nNot consumable");
        }


        public override bool CanUseItem(Player player)
        {
           return !NPC.AnyNPCs(NPCID.KingSlime);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddIngredient(ItemID.GoldCrown, 1);
            recipe.AddIngredient(null, "ManuscriptSlime", 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();

            /*recipe.AddRecipe();
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddIngredient(ItemID.PlatinumCrown);
            recipe.AddIngredient(null, "ManuscriptSlime", 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);*/
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.KingSlime);
            }
            return true;
        }
    }
}