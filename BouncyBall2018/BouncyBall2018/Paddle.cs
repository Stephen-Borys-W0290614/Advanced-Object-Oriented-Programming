using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyBall2018
{
    class Paddle
    {

        public Rectangle paddleBox;
        Rectangle mainCanvas;

        public enum Direction { Left, Right}

        //X and Y coordinate
        //size

        public Paddle(Rectangle mainCanvas)
        {
            //this is the main form window area that the paddle
            //will exist in
            this.mainCanvas = mainCanvas;

            //set the size of our paddlebox - the rectangle
            //that we will draw out paddle in
            paddleBox.Height = 10;
            paddleBox.Width = 100;

            //set the initial position of the paddle
            //bottom of screen, in the center
            paddleBox.Y = (int) (mainCanvas.Height * .85);
            paddleBox.X = mainCanvas.Width / 2 - paddleBox.Width / 2;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        public void Move(Direction direction)
        {
            switch(direction)
            {
                case Direction.Left:
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
                case Direction.Right:
                    {
                        //if there's less than 25 left before the wall
                        if(mainCanvas.Right - paddleBox.Right < 25)
                        {
                            //move to the edge of the wall only...don't go past
                            paddleBox.X = mainCanvas.Width - paddleBox.Width;
                        }
                        else
                        {
                            //move the full distance because there's
                            //room
                            paddleBox.X += 25;
                        }                        
                        break;
                    }

                    {
                        //if there's less than 25 left before the wall
                        if (mainCanvas.Right - paddleBox.Right < 25)
                        {
                            //move to the edge of the wall only...don't go past
                            paddleBox.X = mainCanvas.Width - paddleBox.Width;
                        }
                        else
                        {
                            //move the full distance because there's
                            //room
                            paddleBox.X += 25;
                        }
                        break;

                    }
            }
        }

        public void Draw(Graphics graphics)
        {
            //needs the graphics object to draw
            graphics.FillRectangle(Brushes.White, paddleBox);

        }
    }
}
