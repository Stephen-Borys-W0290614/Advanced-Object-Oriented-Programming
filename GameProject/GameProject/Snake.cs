using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject
{
    public class Snake
    {
        public Rectangle snakeBox;

        Rectangle gameArea;

        public enum Direction { Left, Right, Up, Down }

        private Image image = Image.FromFile("images/player-icon.png");



        //X and Y coordinate

        //size

        /// <summary>
        /// This makes the setteing for the snake
        /// </summary>
        /// <param name="gameArea">This is the gameArea aka the form</param>
        public Snake(Rectangle gameArea)
        {
            this.gameArea = gameArea;

            //Set size of snake
            snakeBox.Height = 50;
            snakeBox.Width = 50;

            snakeBox.Y = (int) (gameArea.Height * 0.5);

            snakeBox.X = (int)(gameArea.Width * 0.5);


        }


        //Make snake move
        /// <summary>
        /// This function will move the screen
        /// </summary>
        /// <param name="direction">This is what let the snake know what key was pressed</param>
        public void Move(Direction direction)
        {

            switch (direction)
            {

                case Direction.Left:
                    {
                        if (snakeBox.X > 25)
                        {
                            snakeBox.X -= 25;
                        }
                        else
                        {
                            snakeBox.X = 0;
                        }

                        break;

                    }
                case Direction.Right:
                    {
                        if(snakeBox.Right > gameArea.Right - 25)
                        {
                            snakeBox.X = gameArea.Width - snakeBox.Width;
                        }
                        else
                        {
                            snakeBox.X += 25;
                        }
                        break;
                    }
                case Direction.Up:
                    {

                        if (snakeBox.Y > 25)
                        {
                            snakeBox.Y -= 25;
                        }
                        else
                        {
                            snakeBox.Y = 0;
                        }

                        break;
                        
                    }
                case Direction.Down:
                    {
                        if (snakeBox.Bottom > gameArea.Bottom - 25)
                        {
                            snakeBox.Y = gameArea.Height - snakeBox.Height;
                        }
                        else
                        {
                            snakeBox.Y += 25;
                        }
                        break;
                    }

            }

        }

        //Draw Snake
        /// <summary>
        /// This function will draw the snake
        /// </summary>
        /// <param name="graphics">This is Graphics</param>
        public void Draw(Graphics graphics)
        {

            graphics.FillRectangle(Brushes.Green, snakeBox);

            //graphics.DrawImage(image, snakeBox);


        }
    }
}
