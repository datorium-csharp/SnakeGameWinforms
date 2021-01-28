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
        private Game game = null;
        private List<PictureBox> pixels = new List<PictureBox>();

        public Snake(Game gameref)
        {
            InitializeSnake();
            game = gameref;
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

    }
}
