using Terraria;
using Terraria.Audio;
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
            Item.width = 24;
            Item.height = 22;
            Item.maxStack = 20;
            Item.rare = 0;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = 4;
            Item.consumable = false;
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
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddIngredient(ItemID.GoldCrown, 1);
            recipe.AddIngredient(null, "ManuscriptSlime", 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();

            /*recipe.AddRecipe();
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddIngredient(ItemID.PlatinumCrown);
            recipe.AddIngredient(null, "ManuscriptSlime", 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);*/
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.KingSlime);
            }
            return true;
        }
    }
}