using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class GoodBall
    {
        private Rectangle goodBallBox;

        private Rectangle gameArea;

        private int size = 40;

        private Random random = new Random();




        public GoodBall(Rectangle gameArea)
        {

            this.gameArea = gameArea;

            //set the size of out ballBox
            goodBallBox.Height = size;
            goodBallBox.Width = size;

            goodBallBox.X = random.Next(0, 500);
            goodBallBox.Y = random.Next(0, 500);
        }



        public void Draw(Graphics graphics)
        {

            graphics.FillEllipse(Brushes.Yellow, goodBallBox);

        }

    }
}
