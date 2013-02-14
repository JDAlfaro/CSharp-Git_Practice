/* Name: Snake Game
 * Author:Joshua David Alfaro
 * 
 * Desciption:
 * Food class for Snake Game
 * Followed tutorial by TutorialHouseNz on YouTube
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Snake_Game
{
    class Food
    {
        private int x, y, width, height;
        private SolidBrush brush;
        public Rectangle foodRec;

        public Food(Random randFood)
        {
            x = randFood.Next(0, 29) * 10;
            y = randFood.Next(0, 29) *10;

            brush = new SolidBrush(Color.Yellow);

            width = 10;
            height = 10;

            foodRec = new Rectangle(x, y, width, height);
        }

        // generate food
        public void foodLocation(Random randFood)
        {
            x = randFood.Next(0, 29) * 10;
            y = randFood.Next(0, 29) * 10;
        }

        public void drawFood(Graphics paper)
        {
            foodRec.X = x;
            foodRec.Y = y;

            paper.FillRectangle(brush, foodRec);
        }
    }
}
