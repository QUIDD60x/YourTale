using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Localization;
using YourTale.Common;
using Terraria.ModLoader.Config;

namespace YourTale
{
    [Label("Yourtale's game configuration.")]
    class ServerConfig : ModConfig
    {
        [JsonIgnore]
        public const string ConfigName = "sapo asop samslapmsa polm";

        public override bool Autoload(ref string name)
        {
            name = ConfigName;
            return base.Autoload(ref name);
        }

        public override ConfigScope Mode => ConfigScope.ServerSide;

        [Label("$ToolTweaks")]
        [Tooltip("Will disable the copper tools nerf (you will need to quit to menu and rejoin).")]
        [DefaultValue(true)]
        public bool ToolTweaks;


        [Label("$Placeholder Slider")]
        [Tooltip("$Placeholder slider thingy")]
        [Range(1f, 5f)]
        [DefaultValue(5f)]
        public float PlaceholderSlide;

        [Label("$Placeholder Button")]
        [Tooltip("$Placeholder button.")]
        [ReloadRequired]
        [Range(0, 100)]
        [DefaultValue(69f)]
        public int PlaceholderButton;

        [Label("$Enable Monet")]
        [Tooltip("$This currently does not do anything yet, but will enable a custom currency once implemented.")]
        [ReloadRequired]
        [DefaultValue(true)]
        public bool CoinRecipesAtEndofList;
    }

}
