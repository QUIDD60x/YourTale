using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yourtale.NPCs.Evil.Boss;

namespace yourtale.Items.Consumables.Summoning
{
    public class CryoCube2 : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 32;
            item.height = 32;
            item.maxStack = 20;
            item.rare = 0;
            item.useAnimation = 45;
            item.useTime = 45;
            item.useStyle = 4;
            item.consumable = false;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Cube");
            Tooltip.SetDefault("You can almost see a face in there... \nSummons Cryolisis \nNot consumable");
        }


        public override bool CanUseItem(Player player)
        {
            return player.ZoneSnow && !NPC.AnyNPCs(mod.NPCType("Cryolisis"));
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.IceBlock, 15);
            recipe.AddIngredient(ItemID.Shiverthorn, 2);
            recipe.AddIngredient(null, "LifeShard", 2);
            recipe.AddIngredient(null, "ManuscriptCryo", 1);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, mod.NPCType("Cryolisis"));
            }
            return true;
        }
    }
}