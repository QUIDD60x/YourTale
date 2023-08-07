using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Buffs.Bad;
using yourtale.Rarities;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class DiamondSword : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.crit = 12;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.4f;
            Item.value = 3000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(player, target, hit, Item.damage);
            target.AddBuff(ModContent.BuffType<Crush>(), 240);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Diamond, 8);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}