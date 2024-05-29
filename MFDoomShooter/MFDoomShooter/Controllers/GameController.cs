using MFDoomShooter.Models;
using Microsoft.Xna.Framework.Graphics;

namespace MFDoomShooter.Controllers;

public class GameController
{
    private readonly Player player;
    private readonly Background background;
    
    public GameController()
    {
        background = new Background();
        var texture = Globals.Content.Load<Texture2D>("bullet");
        BulletController.Init(texture);
        UIController.Init(texture);

        player = new(Globals.Content.Load<Texture2D>("player"));
        EnemyController.Init();
    }
    
    public void Restart()
    {
        BulletController.Reset();
        EnemyController.Reset();
        player.Reset();
    }


    public void Update()
    {
        InputController.Update();
        player.Update(EnemyController.Enemies);
        EnemyController.Update(player);
        BulletController.Update(EnemyController.Enemies);

        if (player.Dead) Restart();
    }

    public void Draw()
    {
        background.Draw();
        player.Draw();
        BulletController.Draw();
        EnemyController.Draw();
        UIController.Draw(player);
    }
}