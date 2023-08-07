using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Buffs.Bad;
using yourtale.Rarities;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class RubySword : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 35;
            Item.crit = 4;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 2;
            Item.value = 3000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(player, target, hit, 35);
            player.AddBuff(BuffID.RapidHealing, 360);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Ruby, 8);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}