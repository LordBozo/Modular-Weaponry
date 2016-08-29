using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.UI;

public delegate bool ApplyModule(ref Item weapon);
public class Modular_Weaponry : ModItem
{
    public int moduleType;
    public ApplyModule applyModule;
}