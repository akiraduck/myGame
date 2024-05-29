using Microsoft.Xna.Framework;

namespace MFDoomShooter.Models;

public class BulletData
{
    public Vector2 Position { get; set; }
    public float Rotation { get; set; }
    public float Lifespan { get; set; }
    public int Speed { get; set; }
    public int Damage { get; set; }
}