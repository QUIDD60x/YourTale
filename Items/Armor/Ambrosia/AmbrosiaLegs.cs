using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace yourtale.Items.Armor.Ambrosia
{
    [AutoloadEquip(EquipType.Legs)]
    public class AmbrosiaLegs : ModItem
    {
        public override void SetDefaults()
        {
            // Item properties
            Item.width = 25;
            Item.height = 700;
            Item.defense = 8;
            // Item value
            Item.value = 20000;
            Item.rare = ItemRarityID.LightRed;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Generic) *= 1.04f;
            player.moveSpeed *= 1.05f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("Ambrosia").Type, 4);
            recipe.AddIngredient(Mod.Find<ModItem>("LegMold"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
