using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter.Models;

public class Enemy : Sprite
{
    public int HP { get; private set; }
    
    public Enemy(Texture2D texture, Vector2 position) : base(texture, position)
    {
        Speed = 100;
        HP = 2;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
    }

    public void Update(Player player)
    {
        var toPlayer = player.Position - Position;
        Rotation = (float)Math.Atan2(toPlayer.Y, toPlayer.X);

        if (toPlayer.Length() > 4)
        {
            var direction = Vector2.Normalize(toPlayer);
            Position += direction * Speed * Globals.TotalSeconds;
        }
    }
}