using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGameWinforms
{
    class Food : PictureBox
    {
        Game game = null;

        public Food(Game gameInstance)
        {
            game = gameInstance;
            InitializeFood();
        }
        
        private void InitializeFood()
        {
            this.Width = 20;
            this.Height = 20;
            this.BackColor = Color.Green;
        }

        public void Render()
        {
            this.Left = 100;
            this.Top = 100;
            game.Controls.Add(this);
            this.BringToFront();
        }
    }
}
