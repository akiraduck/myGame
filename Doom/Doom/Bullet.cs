﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Doom
{
    public class Bullet
    {
        public string direction;
        public int bulletLeft;
        public int bulletTop;

        private int speed = 10;
        private PictureBox bullet = new PictureBox();
        private Timer bulletTimer = new Timer();

        public void MakeBullet(Form form)
        {
            bullet.BackColor = Color.Black;
            bullet.Size = new Size(5, 5);
            bullet.Tag = "bullet";
            bullet.Left = bulletLeft;
            bullet.Top = bulletTop;
            bullet.BringToFront();
            
            form.Controls.Add(bullet);

            bulletTimer.Interval = speed;
            bulletTimer.Tick += BulletTimerEvent;
            bulletTimer.Start();
        }
        
        private void BulletTimerEvent(object sender, EventArgs e)
        {
            if (direction == "left")
            {
                bullet.Left -= speed;
            }
            
            if (direction == "right")
            {
                bullet.Left += speed;
            }
            
            if (direction == "up")
            {
                bullet.Top -= speed;
            }
            
            if (direction == "down")
            {
                bullet.Top += speed;
            }

            if (bulletLeft < 10 || bullet.Left > 990 || bullet.Top < 60 || bullet.Top > 700)
            {
                bulletTimer.Stop();
                bulletTimer.Dispose();
                bullet.Dispose();
                bulletTimer = null;
                bullet = null;
            }
        }
    }
}