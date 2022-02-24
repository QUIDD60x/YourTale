using Terraria.GameContent.Dyes;
using Terraria.GameContent.UI;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Social;
using Terraria.UI;
using Terraria.UI.Chat;
using static Terraria.ID.Colors;
using yourtale.NPCs.Evil.Boss;
using yourtale.Items.Accessories;
using yourtale.Items.Placeables;
using yourtale.Items.Armor.Cryolite;
using yourtale.Items.Weapons.Mana;
using yourtale.Items;

namespace yourtale
{
    public class yourtale : Mod
    {
        public override void PostSetupContent()
        {

            Mod bossChecklist = ModLoader.GetMod("BossChecklist");
            if (bossChecklist != null)
            {                                                                                                                                                                                                                                                                                                                                                                                                                               //[i:" + ItemType("summon item here") + "]
                bossChecklist.Call("AddBoss", 3f, NPCType("Cryolisis"), this, "Cryolisis", (Func<bool>)(() => YourWorld.downedCryolisis), ItemType("flint"), new List<int> { }, new List<int> { ModContent.ItemType<IceHeart>(), ModContent.ItemType<Cryolite>(), ModContent.ItemType<CryoliteHelmet>(), ModContent.ItemType<CryoliteBreastplate>(), ModContent.ItemType<CryoliteLeggings>(), ModContent.ItemType<IceStaff>() }, "Currently unspawnable :(");
            }
        }



        private bool isValidWorldName(string name)
        { 
            if(name == "") { return false; }
            foreach (WorldFileData wfd in Main.WorldList)
            {
                if(wfd.Name == name) { return false; }

            }
            return true;     
        }

        public override void AddRecipes()
        { //custom crafting recipes, the one below this is a base for ez copy pasting of the main bits.
            /*recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.);
            recipe.AddIngredient(this.ItemType(""));
            recipe.AddTile(TileID.);
            recipe.SetResult(ItemID.);*/

            ModRecipe recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HellstoneBar, 10);
            recipe.AddIngredient(ItemID.ObsidianSkinPotion, 3);
            recipe.AddIngredient(ItemID.LavaBucket, 6);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.LavaCharm);
            
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.HellstoneBar, 3);
            recipe.AddIngredient(ItemID.ObsidianSkull);
            recipe.AddIngredient(ItemID.LavaBucket, 2);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.ObsidianRose);
            
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.GoldBar, 5);
            recipe.AddIngredient(ItemID.Bone, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.GoldenKey, 5);
            
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Cloud, 12);
            recipe.AddIngredient(ItemID.RainCloud, 7);
            recipe.AddIngredient(ItemID.SunplateBlock, 15);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddIngredient(ItemID.IronBar, 8);
            recipe.AddIngredient(ItemID.LeadBar, 8);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.LuckyHorseshoe);
            
            recipe.AddRecipe();
            recipe.AddIngredient(ItemID.LeadBar, 8);
            recipe.AddIngredient(ItemID.Cloud, 12);
            recipe.AddIngredient(ItemID.RainCloud, 7);
            recipe.AddIngredient(ItemID.SunplateBlock, 15);
            recipe.AddIngredient(ItemID.Feather, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.LuckyHorseshoe);

            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddIngredient(ItemID.PinkDye);
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ItemID.PinkGel, 50);

            /*recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Gel, 50);
            recipe.AddIngredient(ItemID.RedDye);
            recipe.AddIngredient(this.ItemType("WhiteDye"));
            recipe.AddTile(TileID.DyeVat);
            recipe.SetResult(ItemID.PinkGel, 50);*/ //dye doesn't work yet.
            
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Book, 20);
            recipe.AddIngredient(ItemID.WaterBucket, 5);
            recipe.AddIngredient(this.ItemType("StarShard"), 6);
            recipe.AddTile(TileID.Bookcases);
            recipe.SetResult(ItemID.WaterBolt);
            
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.SunplateBlock, 10);
            recipe.AddIngredient(ItemID.Cloud, 5);
            recipe.AddIngredient(ItemID.RainCloud, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.SkyMill);
            
            recipe.AddRecipe();
            recipe = new ModRecipe(this);
            recipe.AddIngredient(ItemID.Shackle, 2);
            recipe.AddIngredient(ItemID.ManaCrystal, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(ItemID.CelestialMagnet);
            recipe.AddRecipe();

        }



    }
}