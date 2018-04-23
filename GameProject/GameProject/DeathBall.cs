using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class DeathBall
    {
        private Rectangle deathBallBox;

        private Rectangle gameArea;

        private int size = 40;

        private Random random = new Random();

        public int X { get; set; }

        public int Y { get; set; }







        public DeathBall(Rectangle gameArea)
        {

            this.gameArea = gameArea;

            //set the size of out ballBox
            deathBallBox.Height = size;
            deathBallBox.Width = size;

            deathBallBox.X = random.Next(0, 500);
            deathBallBox.Y = random.Next(0, 500);

            X = 0;

            Y = 0;

   

        }



        public void Draw(Graphics graphics)
        {

            Point point1 = new Point(50, 100);
            Point point2 = new Point(100, 110);
            Point point3 = new Point(150, 120);
            Point point4 = new Point(65, 130);
            Point point5 = new Point(70, 140);
            Point point6 = new Point(75, 50);
            Point point7 = new Point(80, 50);
            Point[] curvePoints = { point1, point2, point3 };

            graphics.FillPolygon(Brushes.Red, curvePoints);

        }

    }
}
