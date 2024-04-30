using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Doom.Properties;

namespace Doom
{
    public partial class Form1 : Form
    {
        private bool goUp, goDown, goRight, goLeft, gameOver;
        private string facing = "up";
        private int playerHealth = 100;
        private int speed = 9;
        private int food = 10;
        private int score;
        private int enemySpeed = 2;
        private Random randomNumber = new Random();
        private List<PictureBox> enemiesList = new List<PictureBox>();
        
        public Form1()
        {
            InitializeComponent();
            RestartGame();
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
                player.Image = Resources.dead;
                GameTimer.Stop();
            }
            
            txtFood.Text = "Еда: " + food;
            txtScore.Text = "Убийства: " + score;
            
            if (goLeft && player.Left > 0)
            {
                player.Left -= speed;
            }

            if (goRight && player.Left + player.Width < ClientSize.Width)
            {
                player.Left += speed;
            }
            
            if (goUp && player.Top > 70)
            {
                player.Top -= speed;
            }
            
            if (goDown && player.Top + player.Height < ClientSize.Height)
            {
                player.Top += speed;
            }

            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag == "food")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        food += 6;
                    }
                }
            }
            
            foreach (Control x in Controls)
            {
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        food += 6;
                    }
                }

                if (x is PictureBox && (string)x.Tag == "enemy")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }
                    
                    if (x.Left > player.Left)
                    {
                        x.Left -= enemySpeed; 
                        ((PictureBox)x).Image = Resources.enemy_left;
                    }
                        
                    if (x.Left < player.Left)
                    {
                        x.Left += enemySpeed;
                        ((PictureBox)x).Image = Resources.enemy_right;
                    }

                    if (x.Top > player.Top)
                        x.Top -= enemySpeed;
                    
                    if (x.Top < player.Top)
                        x.Top += enemySpeed;
                }
                
                foreach (Control j in Controls)
                {
                    if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "enemy")
                    {
                        if (x.Bounds.IntersectsWith(j.Bounds))
                        {
                            score++;
                            Controls.Remove(j);
                            ((PictureBox)j).Dispose();
                            Controls.Remove(x);
                            enemiesList.Remove((PictureBox)x);
                            MakeEnemies();
                        }
                    }
                }
            }
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (gameOver)
            {
                return;
            }
            
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
                facing = "left";
                player.Image = Resources.left;
            }
            
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
                facing = "right";
                player.Image = Resources.right;
            }
            
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
                facing = "up";
            }
            
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
                facing = "down";
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
                        
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
                        
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
                        
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            
            if (e.KeyCode == Keys.Space && food > 0 && !gameOver)
            {
                food--;
                ShootBullet(facing);

                if (food < 1)
                {
                    DropFood();
                }
            }

            if (e.KeyCode == Keys.Enter && gameOver)
            {
                RestartGame();
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
            enemy.Image = Resources.enemy_left;
            enemy.Left = randomNumber.Next(0, 1000);
            enemy.Top = randomNumber.Next(70, 700);
            enemy.SizeMode = PictureBoxSizeMode.AutoSize;
            enemiesList.Add(enemy);
            Controls.Add(enemy);
            player.BringToFront();
        }

        private void DropFood()
        {
            var food = new PictureBox();
            food.Image = Resources.food;
            food.SizeMode = PictureBoxSizeMode.AutoSize;
            food.Left = randomNumber.Next(10, ClientSize.Width - food.Width);
            food.Top = randomNumber.Next(80, ClientSize.Height - food.Height);
            food.Tag = "food";
            Controls.Add(food);
            
            food.BringToFront();
            player.BringToFront();
        }
        
        private void RestartGame()
        {
            player.Image = Resources.right;

            foreach (var i in enemiesList)
            {
                Controls.Remove(i);
            }
            
            enemiesList.Clear();

            for (var i = 0; i < 3; i++)
            {
                MakeEnemies();
            }

            goUp = false;
            goDown = false;
            goLeft = false;
            goRight = false;
            gameOver = false;

            playerHealth = 100;
            score = 0;
            food = 10;
            
            GameTimer.Start();
        }
    }
}