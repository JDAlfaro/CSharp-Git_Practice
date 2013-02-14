/* Name: Snake Game
 * Author:Joshua David Alfaro
 * 
 * Desciption:
 * Form 1 class for Snake Game
 * Followed tutorial by TutorialHouseNz on YouTube
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snake_Game
{
    public partial class Form1 : Form
    {
        Random randFood = new Random();
        Graphics paper;
        Snake snake = new Snake();
        Food food;

        bool left = false;
        bool right = false;
        bool down = false;
        bool up = false;

        bool ingame = false;
        int score = 0;

        public Form1()
        {
            InitializeComponent();
            food = new Food(randFood);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            food.drawFood(paper);
            snake.drawSnake(paper);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Space && !ingame)
            {
                ingame = true;
                timer1.Enabled = true;
                spaceBarLabel.Text = "";
                down = false;
                up = false;
                right = true;
                left = false;
            }

            if (e.KeyData == Keys.Down && snake.SnakeRec[0].Y != snake.SnakeRec[1].Y - 10)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Up && snake.SnakeRec[0].Y != snake.SnakeRec[1].Y + 10)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right && snake.SnakeRec[0].X != snake.SnakeRec[1].X - 10)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Left && snake.SnakeRec[0].X != snake.SnakeRec[1].X + 10)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            snakeScoreLabel.Text = Convert.ToString(score);

            if (down)
            {
                snake.moveDown();
            }
            if (up)
            {
                snake.moveUp();
            }
            if (right)
            {
                snake.moveRight();
            }
            if (left)
            {
                snake.moveLeft();
            }

            for (int i = 0; i < snake.SnakeRec.Length; i = i + 1)
            {
                if (snake.SnakeRec[i].IntersectsWith(food.foodRec))
                {
                    score = score + 25;
                    snake.growSnake();
                    food.foodLocation(randFood);
                }
            }

            collision();

            this.Invalidate();
        }

        // detemines if there has been a collision
        public void collision()
        {
            for (int i = 1; i < snake.SnakeRec.Length; i = i + 1)
            {
                if (snake.SnakeRec[0].IntersectsWith(snake.SnakeRec[i]))
                {
                    restart();
                }
            }

            if (snake.SnakeRec[0].X < 0 || snake.SnakeRec[0].X > 290)
            {
                restart();
            }

            if (snake.SnakeRec[0].Y < 0 || snake.SnakeRec[0].Y > 290)
            {
                restart();
            }
        }

        // sets up initial conditions
        public void restart()
        {
            timer1.Enabled = false;
            MessageBox.Show("No!!!! Snake is DEAD!\r\nYour score: "+ score);
            ingame = false;
            snakeScoreLabel.Text = "0";
            score = 0;
            spaceBarLabel.Text = "Press Space Bar to Start";
            snake = new Snake();
        }

        // enables wraparound
        // not currently being used
        public void wraparound()
        {
            if (snake.SnakeRec[0].X < 0)
            {
                snake.drawSnake();
                snake.SnakeRec[0].X = 290;
            }
            if (snake.SnakeRec[0].X > 290)
            {
                snake.drawSnake();
                snake.SnakeRec[0].X = 0;
            }
            if (snake.SnakeRec[0].Y < 0)
            {
                snake.drawSnake();
                snake.SnakeRec[0].Y = 290;
            }
            if (snake.SnakeRec[0].Y > 290)
            {
                snake.drawSnake();
                snake.SnakeRec[0].Y = 0;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
