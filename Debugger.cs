using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace YourTale
{
    public static class Debugger
    {
        public static void Write(string toWrite)
        {
            Main.NewText(toWrite, Microsoft.Xna.Framework.Color.Red);
        }
    }
}