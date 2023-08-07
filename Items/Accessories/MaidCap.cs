using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;

namespace yourtale.Items.Accessories
{
    //Showcases a beard vanity item that uses a greyscale sprite which gets its' color from the players' hair
    //Requires ArmorIDs.Beard.Sets.UseHairColor and Item.color to be used properly
    //For a beard with a fixed color, remove the above mentioned code
    [AutoloadEquip(EquipType.Head)]
    public class MaidCap : ModItem
    {
        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 14;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1);
            Item.accessory = true;
            Item.vanity = true;
            Item.rare = ItemRarityID.Orange;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.moveSpeed *= 1.35f;
            player.maxRunSpeed *= 1.11f;
            player.jumpSpeedBoost *= 1.15f;
            player.GetDamage(DamageClass.Generic) *= 1.1f;
            player.GetAttackSpeed(DamageClass.Generic) *= 1.1f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.Obsidian, 15);
            recipe.AddIngredient(ItemID.PlatinumWatch, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Silk, 20);
            recipe.AddIngredient(ItemID.Obsidian, 15);
            recipe.AddIngredient(ItemID.GoldWatch, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}