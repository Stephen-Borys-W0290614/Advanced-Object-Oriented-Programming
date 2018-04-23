using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyBall2018
{
    class Ball
    {
        public Rectangle ballBox;
        private Rectangle mainCanvas;
        private int size = 64;

        private int XVelocity;
        private int YVelocity;

        private Random random = new Random();

        private Color color;
        private Image image = Image.FromFile("images/Aqua-Ball-icon.png");

        public Ball(Rectangle mainCanvas)
        {
            this.mainCanvas = mainCanvas;

            //set the size of our ballbox
            ballBox.Height = size;
            ballBox.Width = size;

            //set initial position of ball
            ballBox.X = random.Next(0, 1500);
            ballBox.Y = random.Next(0, 500);

            //set the x and y velocity
            while (XVelocity > -3 && XVelocity < 3)
                XVelocity = random.Next(-15, 15);


            while (YVelocity > -3 && YVelocity < 3)
                YVelocity = random.Next(-15, 15);

            //set the ball's color
            color = Color.FromArgb(255, random.Next(255), random.Next(255), random.Next(255)); //red

        }

        //create two properties
        public int CurrentX { get { return ballBox.X; } }
        public int CurrentY { get { return ballBox.Y; } }
        public int Size { get { return size;  } }




        public void Move()
        {
            this.ballBox.X += XVelocity;
            this.ballBox.Y += YVelocity;
        }


        public void Draw(Graphics graphics)
        {
            //graphics.FillEllipse(Brushes.White, ballBox);

            //SolidBrush brush = new SolidBrush(color);
            //graphics.FillEllipse(brush, ballBox);

            graphics.DrawImage(image, ballBox);
        }

        public void FlipX()
        {
            XVelocity *= -1;
        }

        public void FlipY()
        {
            YVelocity *= -1;
        }
    }
}
