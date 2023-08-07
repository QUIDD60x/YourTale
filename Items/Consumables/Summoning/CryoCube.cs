using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using yourtale.NPCs.Evil.Boss;

namespace yourtale.Items.Consumables.Summoning
{
    public class CryoCube : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 20;
            Item.rare = ItemRarityID.Orange;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ZoneSnow && !NPC.AnyNPCs(Mod.Find<ModNPC>("CryolisisBody").Type);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 15);
            recipe.AddIngredient(ItemID.Shiverthorn, 2);
            recipe.AddIngredient(null, "AncientShard", 2); // I don't know how this worked but it does? Odd call for an object
            recipe.AddIngredient(ModContent.ItemType<LetharvitalicEssence>(), 6);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }

        public override bool? UseItem(Player player)
        {
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("CryolisisBody").Type);
            }
            return true;
        }
    }
}