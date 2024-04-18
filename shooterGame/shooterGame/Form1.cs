using System;
using System.Collections.Generic;
using System.Timers;
using System.Windows.Forms;
using shooterGame.Properties;

namespace shooterGame
{
    public partial class Form1 : Form
    {
        private bool goUp, goDown, goRight, goLeft, gameOver;
        private string facing = "up";
        private int playerHealth = 100;
        private int speed = 10;
        private int ammo = 10;
        private int score;
        private int enemiesSpeed = 3;
        private Random randomNumber = new Random();
        private List<PictureBox> enemiesList = new List<PictureBox>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void player_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MainTimerEvent(object sender, ElapsedEventArgs e)
        {
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }

            else
            {
                gameOver = true;
            }

            txtAmmo.Text = "Пули: " + ammo;
            txtScore.Text = "Убийства: " + score;

            if (goLeft && player.Left > 0)
            {
                player.Left -= speed;
            }

            if (goRight && player.Left + player.Width < this.ClientSize.Width)
            {
                player.Left += speed;
            }
            
            if (goUp && player.Top > 92)
            {
                player.Top -= speed;
            }
            
            if (goDown && player.Top + player.Height < this.ClientSize.Height)
            {
                player.Top += speed;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
                        
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }
                        
            if (e.KeyCode == Keys.W)
            {
                goUp = false;
            }
                        
            if (e.KeyCode == Keys.S)
            {
                goDown = false;
            }
            
            if (e.KeyCode == Keys.Space && ammo > 0)
            {
                ammo--;
                ShootBullet(facing);

                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = true;
                facing = "left";
                player.Image = Resources.left;
            }
            
            if (e.KeyCode == Keys.D)
            {
                goRight = true;
                facing = "right";
                player.Image = Resources.right;
            }
            
            if (e.KeyCode == Keys.W)
            {
                goUp = true;
                facing = "up";
                player.Image = Resources.up;
            }
            
            if (e.KeyCode == Keys.S)
            {
                goDown = true;
                facing = "down";
                player.Image = Resources.down;
            }
        }

        private void ShootBullet(string direction)
        {
            var shootBullet = new Bullet();
            shootBullet.direction = direction;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(this);
        }

        private void MakeEnemies()
        {
            var enemy = new PictureBox();
            enemy.Tag = "enemy";
            enemy.Image = Resources.enemy;
            enemy.Left = randomNumber.Next(0, 1200);
            enemy.Top = randomNumber.Next(92, 700);
            enemy.SizeMode = PictureBoxSizeMode.AutoSize;
            enemiesList.Add(enemy);
            Controls.Add(enemy);
            player.BringToFront();
        }

        private void DropAmmo()
        {
            var ammo = new PictureBox();
            ammo.Image = Resources.bullet;
            ammo.SizeMode = PictureBoxSizeMode.Normal;
            ammo.Left = randomNumber.Next(10, ClientSize.Width - ammo.Width);
            ammo.Top = randomNumber.Next(82, ClientSize.Height - ammo.Height);
            ammo.Tag = "ammo";
            Controls.Add(ammo);
            
            ammo.BringToFront();
            player.BringToFront();
        }

        private void RestartGame()
        {
            
        }

        private void txtScore_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}