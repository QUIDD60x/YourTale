using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.DamageClasses;

namespace YourTale.Items.Weapons.Melee.Claws
{
    public class  EmptyClaw : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 1;
            Item.crit = 1;
            Item.DamageType = ModContent.GetInstance<BansheeClass>();
            Item.width = 34;
            Item.height = 32;
            Item.scale *= 1.25f;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.22f;
            Item.value = 335;
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
    }
}