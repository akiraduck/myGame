using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MFDoomShooter.Models;

public class Sprite
{
    private readonly Texture2D texture;
    private readonly Vector2 origin;
    public Vector2 Position { get; set; }
    protected int Speed { get; init; }
    public float Rotation { get; protected set; }

    public Sprite(Texture2D texture, Vector2 position)
    {
        this.texture = texture;
        Position = position;
        Speed = 300;
        origin = new(texture.Width / 2, texture.Height / 2);
    }

    public void Draw()
    {
        Globals.SpriteBatch.Draw(texture, Position, null, Color.White, Rotation, origin, 1, SpriteEffects.None, 1);
    }
}