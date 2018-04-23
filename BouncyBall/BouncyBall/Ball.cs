using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BouncyBall
{
    class Ball
    {

        private Rectangle ballBox;

        private Rectangle mainCavis;

        private int size = 40;

        public Ball(Rectangle mainCavis)
        {

            this.mainCavis = mainCavis;

            ballBox.Height = size;

            ballBox.Width = size;


        }



        public void Move()
        {



        }


        public void Draw(Graphics graphics)
        {



        }
    }
}
