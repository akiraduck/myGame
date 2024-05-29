using MFDoomShooter.Controllers;

namespace MFDoomShooter.Models.Weapons;

public class MachineGirl : Weapon
{
    public MachineGirl()
    {
        cooldown = 0.1f;
        maxAmmo = 30;
        Ammo = maxAmmo;
        reloadTime = 2f;
    }

    protected override void CreateBullets(Player player)
    {
        var bd = new BulletData
        {
            Position = player.Position,
            Rotation = player.Rotation,
            Lifespan = 2f,
            Speed = 600,
            Damage = 1
        };
        
        BulletController.AddBullet(bd);
    }
}