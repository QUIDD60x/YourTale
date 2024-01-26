using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Graphics.Shaders;

namespace YourTale.Items.Armor.Ambrosia
{
    [AutoloadEquip(EquipType.Head)]
    public class AmbrosiaHead : ModItem
    {

        public override void SetStaticDefaults()
        {
            ArmorIDs.Head.Sets.DrawFullHair[Item.headSlot] = true;
            ArmorIDs.Head.Sets.UseAltFaceHeadDraw[Item.headSlot] = true;

        }
        public override void SetDefaults()
        {
            Item.width = 25;
            Item.height = 700;

            Item.value = 15000;
            Item.rare = ItemRarityID.LightRed;

            Item.defense = 7;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.manaCost *= 0.75f;
            player.maxFallSpeed *= 2.45f;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(Mod.Find<ModItem>("Ambrosia").Type, 3);
            recipe.AddIngredient(Mod.Find<ModItem>("HelmMold"), 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == Mod.Find<ModItem>("AmbrosiaChest").Type && legs.type == Mod.Find<ModItem>("AmbrosiaLegs").Type;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "Set bonus: You gain an incredibly fast and agile dash, for every direction!";
            player.GetModPlayer<DashPlayer>().AmbrosicDash = true;
        }
        public class DashPlayer : ModPlayer
        {
            public const int DashDown = 0;
            public const int DashUp = 1;
            public const int DashRight = 2;
            public const int DashLeft = 3;

            public const int DashCooldown = 48;
            public const int DashDuration = 30;

            public const float DashVelocity = 14.3f;

            public int DashDir = -1;

            public bool AmbrosicDash;
            public int DashDelay = 0;
            public int DashTimer = 0;

            public override void ResetEffects()
            {
                AmbrosicDash = false;
                if (Player.controlDown && Player.releaseDown && Player.doubleTapCardinalTimer[DashDown] < 15)
                {
                    DashDir = DashDown;
                }
                else if (Player.controlUp && Player.releaseUp && Player.doubleTapCardinalTimer[DashUp] < 15)
                {
                    DashDir = DashUp;
                }
                else if (Player.controlRight && Player.releaseRight && Player.doubleTapCardinalTimer[DashRight] < 15)
                {
                    DashDir = DashRight;
                }
                else if (Player.controlLeft && Player.releaseLeft && Player.doubleTapCardinalTimer[DashLeft] < 15)
                {
                    DashDir = DashLeft;
                }
                else
                {
                    DashDir = -1;
                }
            }

            public override void PreUpdateMovement()
            {
                if (CanUseDash() && DashDir != -1 && DashDelay == 0)
                {
                    Vector2 newVelocity = Player.velocity;

                    switch (DashDir)
                    {
                        case DashUp when Player.velocity.Y > -DashVelocity:
                        case DashDown when Player.velocity.Y < DashVelocity:
                            {
                                float dashDirection = DashDir == DashDown ? 1 : -0.9f;
                                newVelocity.Y = dashDirection * DashVelocity;
                                break;
                            }
                        case DashLeft when Player.velocity.X > -DashVelocity:
                        case DashRight when Player.velocity.X < DashVelocity:
                            {
                                float dashDirection = DashDir == DashRight ? 1 : -1.2f;
                                newVelocity.X = dashDirection * DashVelocity;
                                break;
                            }
                        default:
                            return;
                    }

                    DashDelay = DashCooldown;
                    DashTimer = DashDuration;
                    Player.velocity = newVelocity;

                        Dust dust; 
                        Vector2 position = Main.LocalPlayer.Center; 
                        dust = Main.dust[Terraria.Dust.NewDust(position, 30, 30, 107, 0f, 0f, 154, new Color(255,255,255), 1f)]; 
                        dust.shader = GameShaders.Armor.GetSecondaryShader(9, Main.LocalPlayer); 
                        dust.fadeIn = 0.9069767f; 

                }

                if (DashDelay > 0)
                    DashDelay--;

                if (DashTimer > 0)
                {
                    Player.eocDash = DashTimer;
                    Player.armorEffectDrawShadowEOCShield = true;

                    DashTimer--;
                }
            }

            private bool CanUseDash()
            {
                return AmbrosicDash
                    && Player.dashType == 0 // player doesn't have Tabi or EoCShield equipped (give priority to those dashes)
                    && !Player.setSolar
                    && !Player.mount.Active;
            }
        }
    }
}