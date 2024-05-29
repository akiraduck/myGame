using MFDoomShooter.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter.Controllers;

public static class UIController
{
    private static Texture2D bulletTexture;

    public static void Init(Texture2D texture)
    {
        bulletTexture = texture;
    }

    public static void Draw(Player player)
    {
        var c = player.Weapon.Reloading ? Color.Red : Color.White;

        for (var i = 0; i < player.Weapon.Ammo; i++)
        {
            Vector2 position = new(0, i * bulletTexture.Height * 2);
            Globals.SpriteBatch.Draw(bulletTexture, position, null, c * 0.75f, 0, Vector2.Zero, 2, SpriteEffects.None, 1);
        }
    }
}