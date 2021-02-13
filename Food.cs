using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeGameWinforms
{
    class Food : PictureBox
    {
        Game game = null;
        Random rand = new Random();

        public Food(Game gameInstance)
        {
            game = gameInstance;
            InitializeFood();
        }

        private void InitializeFood()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.Lime;
        }

        public void Render()
        {
            game.Controls.Add(this);
            this.BringToFront();
            this.Relocate();
        }

        public void Relocate()
        {
            int left = 40 + 20 * rand.Next(0, 20);
            int top  = 40 + 20 * rand.Next(0, 20);
            this.Location = new Point(left, top);


        }

    }
}
