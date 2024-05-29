﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter;

public static class Globals
{
    public static float TotalSeconds { get; set; }
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
    public static Point Bounds { get; set; }

    public static void Update(GameTime time)
    {
        TotalSeconds = (float)time.ElapsedGameTime.TotalSeconds;
    }
}