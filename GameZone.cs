using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGameWinforms
{
    class GameZone : PictureBox
    {
        public GameZone()
        {
            InitializeGameZone();
        }

        private void InitializeGameZone()
        {
            this.BackColor = Color.SteelBlue;
            this.Width = 400;
            this.Height = 400;
        }
    }
}
