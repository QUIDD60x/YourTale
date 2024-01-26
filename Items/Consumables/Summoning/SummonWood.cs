using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.NPCs.Evil.Boss.TreeGuardian;

namespace Yourtale.Items.Consumables.Summoning
{
public class SummonWood : ModItem
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

    public override bool CanUseItem(Player player)
    {
        return (Main.dayTime) && (player.ZoneForest) && !NPC.AnyNPCs(Mod.Find<ModNPC>("TreeGuardian").Type);
    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.Wood, 40);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }

    public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
    {
        SoundEngine.PlaySound(SoundID.Roar, player.position);
        if (Main.netMode != NetmodeID.MultiplayerClient)
        {
            NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("TreeGuardian").Type);
        }
        return true;
    }
}

}
