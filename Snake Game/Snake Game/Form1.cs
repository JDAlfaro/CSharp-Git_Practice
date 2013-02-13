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
        Graphics paper;
        Snake snake = new Snake();

        bool left = false;
        bool right = false;
        bool down = false;
        bool up = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            paper = e.Graphics;
            snake.drawSnake(paper);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Down && up == false)
            {
                down = true;
                up = false;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Up && down == false)
            {
                down = false;
                up = true;
                right = false;
                left = false;
            }
            if (e.KeyData == Keys.Right && left == false)
            {
                down = false;
                up = false;
                right = true;
                left = false;
            }
            if (e.KeyData == Keys.Left && right == false)
            {
                down = false;
                up = false;
                right = false;
                left = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
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

            this.Invalidate();
        }
    }
}
