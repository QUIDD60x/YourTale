using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using yourtale.Rarities;
using yourtale.Tiles.Furniture;

namespace YourTale.Items.Weapons.Melee.Sword
{
    public class HerosEnd : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hero's End");
            Tooltip.SetDefault("Once weilded by the feigned hero, it has a small chance to instantly kill an enemy.\n" +
                "''[c/FF0000:A hero has to win every time, a villan just has to win once.]''");
        }

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.NightsEdge);
            Item.crit = 0;
            Item.damage = 1;
            Item.rare = ModContent.RarityType<Black2Red>();
        }

        public override void HoldItem(Player player)
        {
            base.HoldItem(player);
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = Main.LocalPlayer.Center;
            dust = Dust.NewDustDirect(position, 0, 0, DustID.Granite, 0f, 0f, 0, new Color(255, 255, 255), 0.1f);
            dust.noGravity = false;
            dust.fadeIn = 1.4302325f;
        }

        public override void OnHitNPC(Player player, NPC target, int damage, float knockBack, bool crit)
        {
            base.OnHitNPC(player, target, damage, knockBack, crit);

            if (Main.rand.NextBool(50))
            {
                Item.damage = 25056;
                //Item.crit = 100; Overkill tbh -Quidd
            }
            if (Main.rand.NextBool(2))
            {
                Item.damage = 1;
                //Item.crit = 0;
            }
        }

        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Dust dust;
            // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
            Vector2 position = Main.LocalPlayer.Center;
            dust = Dust.NewDustDirect(position, 0, 0, DustID.Granite, 0f, 0f, 0, new Color(255, 255, 255), 1f);
            dust.noGravity = true;
            dust.fadeIn = 1.4302325f;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.NightsEdge, 1);
            recipe.AddIngredient(ItemID.TissueSample, 15);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard"), 1);
            recipe.AddTile(Mod.Find<ModTile>("AncientAnvil").Type);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.NightsEdge, 1);
            recipe.AddIngredient(ItemID.ShadowScale, 15);
            recipe.AddIngredient(Mod.Find<ModItem>("AncientShard"), 1);
            recipe.AddTile(Mod.Find<ModTile>("AncientAnvil").Type);
            recipe.Register();
        }
    }
}