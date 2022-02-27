using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yourtale.NPCs.Evil.Boss;

namespace yourtale.Items.Consumables.Summoning
{
    public class Suspicious_Looking_Eye : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 30;
            item.height = 20;
            item.maxStack = 20;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Suspicious Looking Eye");
            Tooltip.SetDefault("\nSummons the Eye of Cthulhu \nNot consumable");
        }


        public override bool CanUseItem(Player player)
        {
            return (!Main.dayTime)  && !NPC.AnyNPCs(NPCID.EyeofCthulhu);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Lens, 6);
            recipe.AddIngredient(null, "ManuscriptEye", 1);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.EyeofCthulhu);
            }
            return true;
        }
    }
}