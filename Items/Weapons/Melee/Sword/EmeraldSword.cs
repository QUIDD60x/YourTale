using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using YourTale.Buffs.Bad;
using YourTale.Rarities;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class EmeraldSword : ModItem
    {

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.crit = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 48;
            Item.height = 48;
            Item.useTime = 19;
            Item.useAnimation = 19;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 0.2f;
            Item.value = 2000;
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }

        public override void OnHitNPC(Player player, NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(player, target, hit, Item.damage);
            player.AddBuff(BuffID.Swiftness, 360);
            player.AddBuff(BuffID.Lifeforce, 180);
            player.statLife += 60;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Emerald, 8);
            recipe.AddIngredient(ItemID.IronBar, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}