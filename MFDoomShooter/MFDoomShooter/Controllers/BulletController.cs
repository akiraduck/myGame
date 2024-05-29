using System.Collections.Generic;
using MFDoomShooter.Models;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter.Controllers;

public class BulletController
{
    private static Texture2D texture;
    public static List<Bullet> Bullets { get; } = new();

    public static void Init(Texture2D tex)
    {
        texture = tex;
    }
    
    public static void Reset()
    {
        Bullets.Clear();
    }

    public static void AddBullet(BulletData data)
    {
        Bullets.Add(new(texture, data));
    }

    public static void Update(List<Enemy> enemies)
    {
        foreach (var b in Bullets)
        {
            b.Update();
            foreach (var e in enemies)
            {
                if (e.HP <= 0) continue;

                if ((b.Position - e.Position).Length() < 32)
                {
                    e.TakeDamage(1);
                    b.Destroy();
                    break;
                }
            }
        }

        Bullets.RemoveAll((b) => b.Lifespan <= 0);
    }

    public static void Draw()
    {
        foreach (var b in Bullets)
        {
            b.Draw();
        }
    }
}