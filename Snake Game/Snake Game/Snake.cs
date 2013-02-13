/*  Joshua David Alfaro
 * Followed tutorial by TutorialHouseNz on YouTube
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    class Snake
    {
        public Rectangle[] snakeRec;
        private SolidBrush brush;
        private int x, y, width, height;

        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Red);

            x = 20;
            y = 0;
            width = 10;
            height = 10;

            for (int i = 0; i < snakeRec.Length; i=i+1)
            {
                snakeRec[i] = new Rectangle(x, y, width, height);
                x = x - 10;
            }
        }

        public void drawSnake(Graphics paper)
        {
            for (int j = 0; j < snakeRec.Length; j = j + 1)
            {
                paper.FillRectangle(brush, snakeRec[j]);
            }
        }
    }
}
