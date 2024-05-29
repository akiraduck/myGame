using System;
using System.Collections.Generic;
using MFDoomShooter.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter.Controllers;

public class EnemyController
{
    public static List<Enemy> Enemies { get; } = new();
    private static Texture2D texture;
    private static float spawnCooldown;
    private static float spawnTime;
    private static Random random;
    private static int padding;

    public static void Init()
    {
        texture = Globals.Content.Load<Texture2D>("enemy");
        spawnCooldown = 0.7f;
        spawnTime = spawnCooldown;
        random = new();
        padding = texture.Width / 2;
    }
    
    public static void Reset()
    {
        Enemies.Clear();
        spawnTime = spawnCooldown;
    }

    public static Vector2 RandomPosition()
    {
        var width = Globals.Bounds.X;
        var height = Globals.Bounds.Y;
        Vector2 position = new();

        if (random.NextDouble() < width / (width + height))
        {
            position.X = (int)(random.NextDouble() * width);
            position.Y = random.NextDouble() < 0.5 ? -padding : height + padding;
        }
        else
        {
            position.Y = (int)(random.NextDouble() * height);
            position.X = random.NextDouble() < 0.5 ? -padding : width + padding;
        }

        return position;
    }

    public static void AddEnemy()
    {
        Enemies.Add(new(texture, RandomPosition()));
    }

    public static void Update(Player player)
    {
        spawnTime -= Globals.TotalSeconds;
        if (spawnTime <= 0)
        {
            spawnTime += spawnCooldown;
            AddEnemy();
        }
        
        foreach (var e in Enemies)
        {
            e.Update(player);
        }

        Enemies.RemoveAll(e => e.HP <= 0);
    }

    public static void Draw()
    {
        foreach (var e in Enemies)
        {
            e.Draw();
        }
    }
}