using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Consumables.Summoning
{
    public class Slime_Crown : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 22;
            Item.maxStack = 20;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slime Crown");
            Tooltip.SetDefault("Summons the King Slime.\nNot consumable.");
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

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Gel, 20);
            recipe.AddIngredient(ItemID.PlatinumCrown);
            recipe.AddIngredient(null, "ManuscriptSlime", 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.KingSlime);
            }
            return true;
        }
    }
}