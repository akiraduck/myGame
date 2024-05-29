using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter.Models;

public class Bullet : Sprite
{
    private Vector2 Direction { get; }
    public float Lifespan { get; private set; }

    public Bullet(Texture2D texture, BulletData data) : base(texture, data.Position)
    {
        Speed = data.Speed;
        Rotation = data.Rotation;
        Direction = new((float)Math.Cos(Rotation), (float)Math.Sin(Rotation));
        Lifespan = data.Lifespan;
    }

    public void Destroy()
    {
        Lifespan = 0;
    }

    public void Update()
    {
        Position += Direction * Speed * Globals.TotalSeconds;
        Lifespan -= Globals.TotalSeconds;
    }
}