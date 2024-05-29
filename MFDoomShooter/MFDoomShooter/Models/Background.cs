using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter.Models;

public class Background
{
    private readonly Point mapSize = new(3, 2);
    private readonly Sprite[,] tiles;

    public Background()
    {
        tiles = new Sprite[mapSize.X, mapSize.Y];

        var textures = new List<Texture2D>(5);
        for (var i = 1; i < 6; i++) textures.Add(Globals.Content.Load<Texture2D>("background"));

        var tileSize = new Point(textures[0].Width, textures[0].Height);
        var random = new Random();
        for (var y = 0; y < mapSize.Y; y++)
        {
            for (var x = 0; x < mapSize.X; x++)
            {
                var r = random.Next(0, textures.Count);
                tiles[x, y] = new(textures[r], new((x + 0.5f) * tileSize.X, (y + 0.5f) * tileSize.Y));
            }
        }
    }

    public void Draw()
    {
        for (var y = 0; y < mapSize.Y; y++)
        {
            for (var x = 0; x < mapSize.X; x++) tiles[x, y].Draw();
        }
    }
}