﻿using System;
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

        }
    }
}