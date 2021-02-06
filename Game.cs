using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameWinforms
{
    public partial class Game : Form
    {
        GameZone gameZone = null;
        Snake snake = null;
        Timer mainTimer = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
        }

        private void InitializeGame()
        {
            this.KeyDown += Game_KeyDown;


            gameZone = new GameZone();
            this.Controls.Add(gameZone);

            snake = new Snake(this);
            this.Controls.Add(snake.body[0]);
            snake.body[0].BringToFront();
        }

        private void InitializeMainTimer()
        {
            mainTimer = new Timer();
            mainTimer.Interval = 500;
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            snake.body[0].Left += snake.HorVelocity * snake.Step;
            snake.body[0].Top += snake.VerVelocity * snake.Step;            
        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    snake.Turn(9);
                    break;
                case Keys.Right:
                    snake.Turn(3);
                    break;
                case Keys.Down:
                    snake.Turn(6);
                    break;
                case Keys.Up:
                    snake.Turn(12);
                    break;
                case Keys.P:
                    snake.Stop();
                    break;
                case Keys.Q:
                    snake.Grow();
                    break;
            }
        }

    }
}
