using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyBall
{
    class Paddle
    {
        Rectangle paddleBox;

        Rectangle mainCanvis;

        public enum Directions { Left, Right }



        // x ad y 
        // size


        public Paddle(Rectangle mainCanvas)
        {

            this.mainCanvis = mainCanvis;

            //set the size of the paddle
            paddleBox.Height = 10;
            paddleBox.Width = 100;

            int checkX = paddleBox.X = mainCanvas.Width / 2 - paddleBox.Width / 2;
            int checkY = paddleBox.Y = (int) (mainCanvas.Height * 0.9);


        }



        //Move
        public void Move(Directions direction)
        {

            switch (direction)
            {

                case Directions.Left:
                    {
                        if(paddleBox.X > 25)
                        {
                            paddleBox.X -= 25;
                        }
                        else
                        {
                            paddleBox.X = 0;
                        }

                        break;

                    }

                case Directions.Right:
                    {
                        if (mainCanvis.Right - paddleBox.Right < 25)
                        {
                            paddleBox.X += 25;

                        }
                        else
                        {
                            paddleBox.X += mainCanvis.Width - paddleBox.Width;
                        }
                        break;

                    }

            }

        }


        public void Draw(Graphics graphics)
        {

            //needs the graphics object to draw


            graphics.FillRectangle(Brushes.Pink, paddleBox);
        }

    }
}
