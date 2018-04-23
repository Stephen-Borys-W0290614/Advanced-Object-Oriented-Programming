using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject
{
    public partial class gameCanvas : Form
    {

        int score = 10000;

        int timer = 1000;

        Boolean gameOver = false;

        Boolean gameWin = false;

        Boolean gameStart = false;

        string diffuclity;

        Snake snake;

        HashSet<PointBall> pointBalls = new HashSet<PointBall>();



        public gameCanvas()
        {
            InitializeComponent();


        }

        /// <summary>
        /// This is what loads the canvas
        /// </summary>
        /// <param name="sender">This is the object</param>
        /// <param name="e">This is the EventArgs</param>
        private void Form1_Load(object sender, EventArgs e)
        {

            //this.WindowState = FormWindowState.Maximized;

            this.Size = new Size(875, 700);

            snake = new Snake(this.DisplayRectangle);


        }

        /// <summary>
        /// This will paint the gameCanvas
        /// </summary>
        /// <param name="sender">This is the object</param>
        /// <param name="e">This is the PaintEventArgs</param>
        private void gameCanvas_Paint_1(object sender, PaintEventArgs e)
        {

            //draw any game objects here

            if (gameStart == false)
            {

                DisplayGameStart(e.Graphics);


            } 

            else if (gameStart == true)
            {

                if (gameOver == false && gameWin == false)
                {

                    DisplayScore(e.Graphics);

                    snake.Draw(e.Graphics);

                    MakePointBall(e.Graphics);

                    DisplayGameTime(e.Graphics);

                }
                else if (gameOver != false)
                {

                    DisplayGameOver(e.Graphics);


                }
                else if (gameWin == true)
                {

                    DisplayGameWin(e.Graphics);


                }

            }



        }



        /// <summary>
        /// This is the function that tells what key is pressed and then what to do
        /// </summary>
        /// <param name="sender">This is the object </param>
        /// <param name="e">This is the KeyEventArgs</param>
        private void gameCanvas_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {

                case Keys.Left:
                    {

                        //Move snake left

                        snake.Move(Snake.Direction.Left);
                        break;

                    }

                case Keys.Right:
                    {

                        //Move snake right

                        snake.Move(Snake.Direction.Right);
                        break;

                    }
                case Keys.Up:
                    {

                        //Move snake up

                        snake.Move(Snake.Direction.Up);
                        break;

                    }
                case Keys.Down:
                    {

                        //Move snake down

                        snake.Move(Snake.Direction.Down);
                        break;

                    }
                case Keys.N:
                    {


                        if(gameOver == true)
                        {
                            pointBalls.Clear();

                            gameOver = false;

                            if(diffuclity == "easy")
                            {

                                EasyMode();

                            }
                            else if(diffuclity == "med")
                            {

                                MediumMode();

                            }
                            else if (diffuclity == "hard")
                            {

                                HardMode();

                            }



                            pointBalls.Add(new PointBall(this.DisplayRectangle));
                            snake = new Snake(this.DisplayRectangle);



                        }
                        else if (gameWin == true)
                        {

                            gameWin = false;

                            if (diffuclity == "easy")
                            {

                                EasyMode();

                            }
                            else if (diffuclity == "med")
                            {

                                MediumMode();

                            }
                            else if (diffuclity == "hard")
                            {

                                HardMode();

                            }

                            pointBalls.Add(new PointBall(this.DisplayRectangle));
                            snake = new Snake(this.DisplayRectangle);


                        }
                        break;

                    }
                case Keys.Space:
                    {

                        //Add a ball 
                        pointBalls.Add(new PointBall(this.DisplayRectangle));

                        break;

                    }
                case Keys.Q:
                    {

                        if (gameStart == false)
                        {

                            diffuclity = "easy";

                            gameStart = true;

                            gameWin = false;

                            EasyMode();


                        }

                        pointBalls.Add(new PointBall(this.DisplayRectangle));

                        snake = new Snake(this.DisplayRectangle);

                        break;

                    }
                case Keys.W:
                    {
                        if (gameStart == false)
                        {

                            diffuclity = "med";

                            gameStart = true;

                            gameWin = false;

                            MediumMode();

                        }

                        pointBalls.Add(new PointBall(this.DisplayRectangle));

                        snake = new Snake(this.DisplayRectangle);

                        break;

                    }
                case Keys.E:
                    {

                        if (gameStart == false)
                        {

                            diffuclity = "hard";

                            gameStart = true;

                            gameWin = false;

                            HardMode();

                        }

                        pointBalls.Add(new PointBall(this.DisplayRectangle));

                        snake = new Snake(this.DisplayRectangle);

                        break;

                    }
                case Keys.M:
                    {

                        if (gameWin == true)
                        {

                            gameWin = false;

                            gameStart = false;

                            pointBalls.Clear();


                        }
                        else if(gameOver == true)
                        {

                            gameOver = false;

                            gameStart = false;

                            pointBalls.Clear();


                        }


                        break;

                    }

            }

        }
        
        /// <summary>
        /// This is the function that is a timer and preforms 10 times a second
        /// </summary>
        /// <param name="sender">This is the object</param>
        /// <param name="e">This is the EventArgs</param>
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            //Tell the ball to move

            foreach(PointBall pointBall in pointBalls)
            {

                pointBall.Move();

            }

            //Check if the snake touches any balls
            CheckForCollision();

            //Effect the game timer
            EffectGameTimer();

            //Repaint 
            Invalidate();

        }


        /// <summary>
        /// This function will check what the pointBalls collides with
        /// </summary>
        private void CheckForCollision()
        {
            int countOfBalls = pointBalls.Count;           

            foreach (PointBall pointBall in pointBalls)
            {


                //Check collision with left wall

                if (pointBall.CurrentX <= this.DisplayRectangle.Left)
                {

                    pointBall.FlipX();

                }


                //Check collision with right wall

                if (pointBall.CurrentX + pointBall.size >= this.DisplayRectangle.Right)
                {

                    pointBall.FlipX();

                }


                //Check collision with top wall

                if (pointBall.CurrentY <= this.DisplayRectangle.Top)
                {

                    pointBall.FlipY();

                }


                //Check collision with bottom wall

                if (pointBall.CurrentY + pointBall.size >= this.DisplayRectangle.Bottom)
                {

                    pointBall.FlipY();

                }


                //Check collision with snake
                if (snake.snakeBox.IntersectsWith(pointBall.ballBox))
                {

                    score -= 100;

                    if (score == 0)
                    {

                        gameOver = true;


                    }

                }

            }

        }

        /// <summary>
        /// This function will effect the game timer and will make the timer speed up for every ball that is spawned
        /// </summary>
        private void EffectGameTimer()
        {
            if (timer > 0)
            {

                int effectTime = pointBalls.Count;

                timer -= 1 * effectTime;

            }
            else if (timer == 0 || timer < 0)
            {

                gameWin = true;

                pointBalls.Clear();

            }

        }

        /// <summary>
        /// This is the function that will display the score 
        /// on the screen
        /// </summary>
        /// <param name="graphics">This is Graphics</param>
        public void DisplayScore(Graphics graphics)
        {

            string displayScore = String.Format("Score: " + score);

            Font font = new Font("Verdana", 20);

            graphics.DrawString(displayScore, font, Brushes.White, 20, 20);

        }

        /// <summary>
        /// This is the function that will display when the game is over
        /// </summary>
        /// <param name="graphics">This is Graphics</param>
        public void DisplayGameOver(Graphics graphics)
        {

            string displayScore = String.Format("GAME OVER!!!! You Loose!!! Press N To Try Again");

            string displayMenuOption = String.Format("Or Press M to Return to main menu");

            Font font = new Font("Verdana", 20);

            graphics.DrawString(displayScore, font, Brushes.White,60, 300);

            graphics.DrawString(displayMenuOption, font, Brushes.White,60, 360);

        }

        /// <summary>
        /// This is the function that will display when the user won
        /// </summary>
        /// <param name="graphics">This is Graphics</param>
        public void DisplayGameWin(Graphics graphics)
        {

            string displayScore = String.Format("GAME WIN!!!! Congrats you won!!! Press N For New Game");

            string displayMenuOption = String.Format("Or Press M to Return to main menu");

            Font font = new Font("Verdana", 20);

            graphics.DrawString(displayScore, font, Brushes.White, 25, 300);

            graphics.DrawString(displayMenuOption, font, Brushes.White, 60, 360);


        }


        /// <summary>
        /// This is the function that will display on screen the game time
        /// </summary>
        /// <param name="graphics">This is Graphics</param>
        public void DisplayGameTime(Graphics graphics)
        {

            string displayScore = String.Format("Game timer: " + timer);

            Font font = new Font("Verdana", 20);

            graphics.DrawString(displayScore, font, Brushes.White, 300, 20);

        }


        /// <summary>
        /// This is the function that will display on screen the game tiitle
        /// </summary>
        /// <param name="graphics">This is Graphics</param>
        public void DisplayGameStart(Graphics graphics)
        {

            string displayWelcome = String.Format("Hello and welcome to the best game ever");

            string displayInfo = String.Format("Try to avoid the balls until the clock runs out");

            string displayHurry = String.Format("You can spawn more balls to make the");

            string displayHurry2 = String.Format("time run faster by pressing (Space)");

            string displaySelect = String.Format("Press Q for easy, W for medium, Or E for hard");



            Font font = new Font("Verdana", 20);

            graphics.DrawString(displayWelcome, font, Brushes.White, 20, 20);
            graphics.DrawString(displayInfo, font, Brushes.White, 20, 80);
            graphics.DrawString(displayHurry, font, Brushes.White, 20, 140);
            graphics.DrawString(displayHurry2, font, Brushes.White, 20, 200);
            graphics.DrawString(displaySelect, font, Brushes.White, 20, 260);



        }


        /// <summary>
        /// This will paint and display the PointBall
        /// </summary>
        /// <param name="graphics">This is Graphics</param>
        void MakePointBall(Graphics graphics)
        {

            foreach(PointBall pointBall in pointBalls)
            {

                pointBall.Draw(graphics);

            }

        }



        /// <summary>
        /// Sets stats for easy mode
        /// </summary>
        void EasyMode()
        {

            timer = 1000;

            score = 10000;

        }



        /// <summary>
        /// Sets stats for medium mode
        /// </summary>
        void MediumMode()
        {

            timer = 5000;

            score = 7500;

        }



        /// <summary>
        /// Sets stats for hard mode
        /// </summary>
        void HardMode()
        {

            timer = 10000;

            score = 5000;

        }
    }
}
