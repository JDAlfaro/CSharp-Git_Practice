/* Name: Click Game
 * Author: Joshua David Alfaro
 * 
 * Desciption:
 * Simple Click Game using a random generator
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

namespace Click_Game
{
    public partial class Form1 : Form
    {
        private Rectangle buttonRec = new Rectangle(0, 0, 50, 50);
        private Random rand = new Random();
        private int score = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            drawButton(e.Graphics);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            int diffX = e.X - buttonRec.X;
            int diffY = e.Y - buttonRec.Y;

            if ((diffX > 0 && diffX < 50) && (diffY > 0 && diffY < 50))
            {
                score = score + 1;
                scoreLabel.Text = score.ToString();
            }
        }

        private void drawButton(Graphics paper)
        {
            buttonRec.X = rand.Next(220);
            buttonRec.Y = rand.Next(220);

            paper.DrawImage(Click_Game.Properties.Resources.button_sounds_3, buttonRec);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // tells to repaint
            this.Invalidate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
