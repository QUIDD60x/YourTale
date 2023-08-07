using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yourtale.Items.Accessories
{
    public class SpookyHeart : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 31;

            Item.value = Item.sellPrice(gold: 1, silver: 27);
            Item.rare = ItemRarityID.Yellow;

            Item.accessory = true;
            Item.vanity = true;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Melee) *= 1.15f;
            player.endurance *= 1.45f; // shhhhhhh ;)
            player.statDefense -= 5;
        }
    }
}