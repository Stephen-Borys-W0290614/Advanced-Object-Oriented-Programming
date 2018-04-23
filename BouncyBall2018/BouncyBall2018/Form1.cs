using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncyBall2018
{
    public partial class gameCanvas : Form
    {
        Paddle paddle;
        HashSet<Ball> balls = new HashSet<Ball>();

        int score = 1000;

        int count = 0;

        MciPlayer pop = new MciPlayer("sounds/pop.mp3", "1");
        MciPlayer boing = new MciPlayer("sounds/boing.wav", "2");
        MciPlayer music = new MciPlayer("sounds/music.mp3", "3");


        public gameCanvas()
        {
            InitializeComponent();            
            
        }

        private void gameCanvas_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            //create our paddle and ball
            paddle = new Paddle(this.DisplayRectangle);
            balls.Add(new Ball(this.DisplayRectangle));
        }

        private void gameCanvas_Paint(object sender, PaintEventArgs e)
        {
            //draw any game objects here
            paddle.Draw(e.Graphics);

            foreach(Ball ball in balls)
            {
                ball.Draw(e.Graphics);
            }

            DisplayBallCount(e.Graphics);
            
        }

        /// <summary>
        /// Capture any keystrokes and determine what to move
        /// or do when certain keys are pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.Left:
                    {
                        //move the paddle left
                        paddle.Move(Paddle.Direction.Left);
                        //Invalidate(); //force the paint event to redraw
                        break;
                    }
                case Keys.Right:
                    {
                        //move the paddle right
                        paddle.Move(Paddle.Direction.Right);
                        //Invalidate();
                        break;
                    }
                case Keys.Space:
                    {
                        music.PlayLoop();
                        animationTimer.Enabled = !animationTimer.Enabled;
                        break;
                    }
                case Keys.N:
                    {
                        balls.Add(new Ball(this.DisplayRectangle));
                        break;
                    }
               
            }
        }

        /// <summary>
        /// With a timer we can cause the screen to be redrawn
        /// continuously and therefore animate any objects
        /// on the screen (such as the ball)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animationTimer_Tick(object sender, EventArgs e)
        {
            //tell the ball to move
            foreach(Ball ball in balls)
            {
                ball.Move();
            }
            
            //check for any new collisions
            CheckForCollisions();

            //tell the form to redraw itself
            Invalidate();
        }

        private void CheckForCollisions()
        {
            //first remove any ball objects that miss the paddle
            if(balls.RemoveWhere(BallMissesPaddle) > 0)
            {
                pop.PlayFromStart();
            }
 
            foreach(Ball ball in balls)
            {
                //collision with left wall
                
                

                if (ball.CurrentX <= this.DisplayRectangle.Left)
                {
                    score += 100;
                    ball.FlipX();
                    boing.PlayFromStart();
                }

                //collision with right wall
                if (ball.CurrentX + ball.Size >= this.DisplayRectangle.Right)
                {
                    ball.FlipX();
                    boing.PlayFromStart();

                }

                //collision with ceiling
                if (ball.CurrentY <= this.DisplayRectangle.Top)
                {
                    ball.FlipY();
                    boing.PlayFromStart();

                }


                //collision with paddle
                //check if the ball's bounding box intersects
                //with the paddle's bounding box
                if (paddle.paddleBox.IntersectsWith(ball.ballBox))
                {
                    score += 100;
                    count += 1;
                    ball.FlipY();
           

                }

            }
        }

        private bool BallMissesPaddle(Ball ball)
        {
            return ball.ballBox.Y > paddle.paddleBox.Y;
        }



        public void DisplayBallCount(Graphics graphics)
        {
            
            //ask the hashset for it's current count
            string display = String.Format("Ball Count: {0}", balls.Count);

            string bounceCount = String.Format("Ball Bounce Count: " + count);

            string gameScore = String.Format("Score: " + score);

            Font font = new Font("Verdana", 20);

            graphics.DrawString(display, font, Brushes.White, 20, 20);

            graphics.DrawString(gameScore, font, Brushes.White, 200, 20);

            graphics.DrawString(bounceCount, font, Brushes.White, 800, 20);


            while (balls.Count == 0)
            {
                
                {


                    balls.Add(new Ball(this.DisplayRectangle));

                    string gameEnd = String.Format("End Of Game, Press N to Continue");

                    graphics.DrawString(gameEnd, font, Brushes.White, 100, 100);

                    score -= 100;

                    break;


                }

            }
        }
    }
}
