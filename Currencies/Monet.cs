using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Localization;

namespace YourTale.Currencies
{
    public class Monet : CustomCurrencySingleCoin //a custom currency, not yet implemented.
    {
        public Color ExampleCustomCurrencyTextColor = Color.BlueViolet;

        public Monet(int coinItemID, long currencyCap) : base(coinItemID, currencyCap)
        {
        }

        public override void GetPriceText(string[] lines, ref int currentLine, int price)
        {
            Color color = ExampleCustomCurrencyTextColor * (Main.mouseTextColor / 255f);
            lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
                {
                    color.R,
                    color.G,
                    color.B,
                    Language.GetTextValue("LegacyTooltip.50"),
                    price,
                    "faces" //shabookey
                });
        }
    }
}