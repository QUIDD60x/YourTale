using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yourtale.NPCs.Evil.Boss;

namespace yourtale.Items.Consumables.Summoning
{
    public class Bloody_Spine : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 24;
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
            DisplayName.SetDefault("Bloody Spine");
            Tooltip.SetDefault("\nSummons the Brain of Cthulhu \nNot consumable");
        }


        public override bool CanUseItem(Player player)
        {
            return player.ZoneCrimson && !NPC.AnyNPCs(NPCID.BrainofCthulhu);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.ViciousPowder, 30);
            recipe.AddIngredient(ItemID.Vertebrae, 15);
            recipe.AddIngredient(null, "ManuscriptBOC", 1);
            recipe.SetResult(this);
            recipe.AddTile(TileID.DemonAltar);
            recipe.AddRecipe();
        }

        public override bool UseItem(Player player)
        {
            Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, NPCID.BrainofCthulhu);
            }
            return true;
        }
    }
}