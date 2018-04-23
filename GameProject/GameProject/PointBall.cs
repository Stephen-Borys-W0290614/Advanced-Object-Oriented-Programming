using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    class PointBall
    {
        public Rectangle ballBox;

        private Rectangle gameArea;

        public int size = 40;

        private Random random = new Random();

        private int XVelocity;

        private int YVelocity;

        private Image image = Image.FromFile("images/char_sea-mine.png");



        /// <summary>
        /// This will make the settings for the PointBall
        /// </summary>
        /// <param name="gameArea">This is the gameArea aka the form</param>
        public PointBall(Rectangle gameArea)
        {

            this.gameArea = gameArea;

            //set the size of out ballBox
            ballBox.Height = size;
            ballBox.Width = size;

            ballBox.X = random.Next(0, 500);
            ballBox.Y = random.Next(0, 500);

            //Set the X and Y velocity

            while (XVelocity > -3 && XVelocity < 3)
                XVelocity = random.Next(-15, 15);


            while (YVelocity > -3 && YVelocity < 3)
                YVelocity = random.Next(-15, 15);
        }


        /// <summary>
        /// This is the function that will draw the PointBall
        /// </summary>
        /// <param name="graphics">This is Graphics</param>
        public void Draw(Graphics graphics)
        {

            //graphics.FillEllipse(Brushes.Red, ballBox);

            graphics.DrawImage(image, ballBox);


        }


        //This will tell you the current X and current Y of the ball
        public int CurrentX { get { return ballBox.X; } }
        public int CurrentY { get { return ballBox.Y; } }

        /// <summary>
        /// This is the function that will move the PointBall
        /// </summary>
        public void Move()
        {

            this.ballBox.X += XVelocity;

            this.ballBox.Y += YVelocity;

        }

        /// <summary>
        /// This will flip the ball's x stat
        /// </summary>
        public void FlipX()
        {

            XVelocity *= -1;

        }

        /// <summary>
        /// This will flip the ball's y stat
        /// </summary> 
        public void FlipY()
        {

            YVelocity *= -1;

        }

    }
}
