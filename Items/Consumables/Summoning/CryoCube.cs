﻿using Terraria;
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
            Item.rare = 0;
            Item.useAnimation = 45;
            Item.useTime = 45;
            Item.useStyle = 4;
            Item.consumable = true;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryo Cube");
            Tooltip.SetDefault("You can almost see a face in there... \nSummons Cryolisis");
            DisplayName.AddTranslation(GameCulture.Russian, "Кукла муравьиного льва"); //you can use this to add translated stuff, neat!
            Tooltip.AddTranslation(GameCulture.Russian, "Призывает Королеву муравьиных львов");
        }


        public override bool CanUseItem(Player player)
        {
            return player.ZoneSnow && !NPC.AnyNPCs(Mod.Find<ModNPC>("Cryolisis").Type);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IceBlock, 15);
            recipe.AddIngredient(ItemID.Shiverthorn, 2);
            recipe.AddIngredient(null, "LifeShard", 2);
            recipe.AddTile(TileID.DemonAltar);
            recipe.Register();
        }

        public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
        {
            SoundEngine.PlaySound(SoundID.Roar, player.position);
            if (Main.netMode != 1)
            {
                NPC.SpawnOnPlayer(player.whoAmI, Mod.Find<ModNPC>("Cryolisis").Type);
            }
            return true;
        }
    }
}