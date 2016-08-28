using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Modular_Weaponry
{
    public class Modular_Weaponry : Mod
    {
        public Modular_Weaponry()
        {
            this.Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
    }
}
