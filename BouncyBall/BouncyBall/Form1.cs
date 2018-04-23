using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncyBall
{
    public partial class ParladIsCute : Form
    {
        Paddle paddle;

        public ParladIsCute()
        {
            InitializeComponent();




        }

        private void ParladIsCute_Load(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;
            paddle = new Paddle(this.DisplayRectangle);
        }

        private void ParladIsCute_Paint(object sender, PaintEventArgs e)
        {

            paddle.Draw(e.Graphics);

            

        }

        private void ParladIsCute_KeyDown(object sender, KeyEventArgs e)
        {

            switch (e.KeyData)
            {

                case Keys.Left:
                    {
                        paddle.Move(Paddle.Directions.Left);
                        Invalidate();
                        break;
                    }

                case Keys.Right:
                    {
                        paddle.Move(Paddle.Directions.Right);
                        Invalidate();
                        break;
                    }
            }

        }
    }
}
