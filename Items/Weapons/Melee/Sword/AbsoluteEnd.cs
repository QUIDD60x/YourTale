using yourtale.DamageClasses;
using yourtale.Tiles.Furniture;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Rarities;
using yourtale.Items;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class AbsoluteEnd : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;        }

        public override void SetDefaults()
        {
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 40;
            Item.height = 40;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.autoReuse = true;
            Item.damage = 150;
            Item.knockBack = 4;
            Item.crit = 6;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ModContent.RarityType<Black2Red>();
            Item.UseSound = new SoundStyle($"{nameof(yourtale)}/Assets/Sounds/Items/RamielScream"); //Test to see if the modded sounds work (they do!)
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<flint>(20)
                .AddTile<AnimanticConvoluter>()
                .Register();
        }
    }
}