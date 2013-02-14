/* Name: Snake Game
 * Author:Joshua David Alfaro
 * 
 * Desciption:
 * Snake class for Snake Game
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
        // class variables
        private Rectangle[] snakeRec;
        private SolidBrush brush;
        private int x, y, width, height;

        // Read Only Property
        public Rectangle[] SnakeRec
        {
            get
            {
                return snakeRec;
            }
        }

        // Snake Constructor
        public Snake()
        {
            snakeRec = new Rectangle[3];
            brush = new SolidBrush(Color.Red);

            x = 20;
            y = 150;
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

        public void drawSnake()
        {
            for (int i = snakeRec.Length - 1; i > 0; i = i - 1)
            {
                snakeRec[i] = snakeRec[i - 1];
            }
        }

        public void moveDown()
        {
            drawSnake();
            snakeRec[0].Y = snakeRec[0].Y + 10;
        }

        public void moveUp()
        {
            drawSnake();
            snakeRec[0].Y = snakeRec[0].Y - 10;
        }

        public void moveRight()
        {
            drawSnake();
            snakeRec[0].X = snakeRec[0].X + 10;
        }

        public void moveLeft()
        {
            drawSnake();
            snakeRec[0].X = snakeRec[0].X - 10;
        }

        public void growSnake()
        {
            List<Rectangle> rec = snakeRec.ToList();
            rec.Add(new Rectangle(snakeRec[snakeRec.Length - 1].X, snakeRec[snakeRec.Length -1].Y, width, height));
            snakeRec = rec.ToArray();
        }
    }
}
