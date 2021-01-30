﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SnakeGameWinforms
{
    class Snake
    {
        public List<PictureBox> body = new List<PictureBox>();
        public Snake()
        {
            InitializeSnake();
        }

        private void InitializeSnake()
        {
            PictureBox pixel = new PictureBox();
            pixel.BackColor = Color.Red;
            pixel.Width = 20;
            pixel.Height = 20;
            pixel.Left = 200;
            pixel.Top = 200;

            body.Add(pixel);
        }
    }
}
