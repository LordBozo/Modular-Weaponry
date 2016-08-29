using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

namespace Modular_Weaponry
{
    public class Modular_Weaponry : Mod
    {
        public static bool moduleInterfaceOpen;

        public Modular_Weaponry()
        {
            this.Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }
        
        Item[] items;
        public override void PostDrawInterface(SpriteBatch spriteBatch)
        {
            // Here we check if we're not in any UI and if the players' inventory is open.            
            if (!Main.ingameOptionsWindow && Main.playerInventory && !Main.inFancyUI && moduleInterfaceOpen)
            {
                if (items == null) items = new Item[2];

                for (int i = 0; i < items.Length; ++i)
                {
                    // We'll probably want to change the drawPos to something... Better,
                    Vector2 drawPos = new Vector2(20 + (i * 56) * Main.inventoryScale, 260 * Main.inventoryScale);

                    // A reaaaally long check to see if the mouse is inside our custom UI, to hijack any input.
                    if (Main.mouseX >= drawPos.X && (double)Main.mouseX <= (double)drawPos.X + (double)Main.inventoryBackTexture.Width * (double)Main.inventoryScale && (Main.mouseY >= drawPos.Y && (double)Main.mouseY <= (double)drawPos.Y + (double)Main.inventoryBackTexture.Height * (double)Main.inventoryScale))
                    {
                        Main.player[Main.myPlayer].mouseInterface = true;

                        if (Main.mouseLeftRelease && Main.mouseLeft)
                        {
                            // IsModule() is going to be an extension method of vanilla items.
                            // That will check if 
                            if (Main.mouseItem.type == 0 || (i == 1 && Main.mouseItem.IsModule()))
                            {
                                ItemSlot.LeftClick(items, 0, i);
                            }
                        }
                        ItemSlot.MouseHover(items, 0, i);
                    }
                }
            }
            else if (moduleInterfaceOpen && items != null)
            {
                // Drop any items that were left in the item spots

                items = null;
            }
        }
    }
    public static class Extensions
    {
        public static bool IsModule(this Item item)
        {
            return item.modItem is Module;
        }
    }
}

