using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Consumables.Summoning
{
    public class Suspicious_Looking_Eye : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 20;
            Item.maxStack = 20;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Eye");
            Tooltip.SetDefault("Summons the Eye of Cthulhu.\nNot consumable.");
        }


        public override bool CanUseItem(Player player)
        {
            return (!Main.dayTime)  && !NPC.AnyNPCs(NPCID.EyeofCthulhu);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Lens, 6);
            recipe.AddIngredient(null, "ManuscriptEye", 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
            }
            return true;
        }
    }
}