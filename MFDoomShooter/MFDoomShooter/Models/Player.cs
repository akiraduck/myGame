using System;
using System.Collections.Generic;
using MFDoomShooter.Controllers;
using MFDoomShooter.Models.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter.Models;

public class Player : Sprite
{
    public Weapon Weapon { get; set; }
    private Weapon weapon1;
    private Weapon weapon2;
    public bool Dead { get; private set; }
    
    public Player(Texture2D texture) : base(texture, GetStartPosition())
    {
        Reset();
    }

    private static Vector2 GetStartPosition()
    {
        return new(Globals.Bounds.X / 2, Globals.Bounds.Y / 2);
    }

    public void Reset()
    {
        weapon1 = new MachineGirl();
        weapon2 = new Shotgun();
        Dead = false;
        Weapon = weapon1;
        Position = GetStartPosition();
    }

    private void SwapWeapon()
    {
        Weapon = Weapon == weapon1 ? weapon2 : weapon1;
    }

    private void GameOver(List<Enemy> enemies)
    {
        foreach (var e in enemies)
        {
            if (e.HP <= 0) continue;
            if ((Position - e.Position).Length() < 50)
            {
                Dead = true;
                break;
            }
        }
    }

    public void Update(List<Enemy> enemies)
    {
        if (InputController.Direction != Vector2.Zero)
        {
            var direction = Vector2.Normalize(InputController.Direction);
            Position = new(
                MathHelper.Clamp(Position.X + (direction.X * Speed * Globals.TotalSeconds), 0, Globals.Bounds.X),
                MathHelper.Clamp(Position.Y + (direction.Y * Speed * Globals.TotalSeconds), 0, Globals.Bounds.Y)
            );
        }

        var toMouse = InputController.MousePosition - Position;
        Rotation = (float)Math.Atan2(toMouse.Y, toMouse.X);

        Weapon.Update();

        if (InputController.SpacePressed) SwapWeapon();

        if (InputController.MouseLeftDown) Weapon.Fire(this);

        if (InputController.MouseRightClicked) Weapon.Reload();

        GameOver(enemies);
    }
}