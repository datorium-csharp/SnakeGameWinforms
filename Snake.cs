using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGameWinforms
{
    class Snake
    {
        private int step = 20;
        private int horVelocity = 0;
        private int verVelocity = 0;

        private Timer timerMove = null; //creating empty timer variable

        private Game game = null;
        private List<PictureBox> pixels = new List<PictureBox>();

        public Snake(Game gameref)
        {
            game = gameref;

            InitializeSnake();
            InitializeTimerMove();            
        }

        private void InitializeSnake()
        {
            var pixel = new PictureBox
            {
                BackColor = Color.Red,
                Width = 20,
                Height = 20
            };
            pixels.Add(pixel);            
        }

        public void Render()
        {
            pixels[0].Left = 240;
            pixels[0].Top = 240;
            game.Controls.Add(pixels[0]);
            pixels[0].BringToFront();
        }

        private void InitializeTimerMove()
        {
            timerMove = new Timer();
            timerMove.Tick += TimerMove_Tick;
            timerMove.Interval = 400;
            timerMove.Start();
        }

        private void TimerMove_Tick(object sender, EventArgs e)
        {
            this.Move();
        }

        private void Move()
        {
            pixels[0].Left += horVelocity * step;
            pixels[0].Top += verVelocity * step;

            //make your own code
            //use for loop
        }
        
        public void MoveLeft()
        {
            horVelocity = -1;
            verVelocity = 0;
        }

        public void MoveRight()
        {
            horVelocity = 1;
            verVelocity = 0;
        }

        public void MoveUp()
        {
            horVelocity = 0;
            verVelocity = -1;
        }

        public void MoveDown()
        {
            horVelocity = 0;
            verVelocity = 1;
        }

        public void Grow()
        {
            var pixel = new PictureBox
            {
                BackColor = Color.Red,
                Width = 20,
                Height = 20
            };
            pixels.Add(pixel);
            pixel.Location = pixels[0].Location;
            game.Controls.Add(pixel);
            pixel.BringToFront();
        }

    }
}
