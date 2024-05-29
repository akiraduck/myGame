using System;
using MFDoomShooter.Controllers;

namespace MFDoomShooter.Models.Weapons;

public class Shotgun : Weapon
{
    public Shotgun()
    {
        cooldown = 0.75f;
        maxAmmo = 8;
        Ammo = maxAmmo;
        reloadTime = 3f;
    }
    
    protected override void CreateBullets(Player player)
    {
        const float angleStep = (float)(Math.PI / 16);

        BulletData bd = new()
        {
            Position = player.Position,
            Rotation = player.Rotation - (3 * angleStep),
            Lifespan = 0.5f,
            Speed = 800,
            Damage = 2
        };

        for (var i = 0; i < 5; i++)
        {
            bd.Rotation += angleStep;
            BulletController.AddBullet(bd);
        }
    }
}