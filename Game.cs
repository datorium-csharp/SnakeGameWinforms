using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGameWinforms
{
    public partial class Game : Form
    {
        GameZone gameZone = null;
        Snake snake = null;
        
        public Game()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            //adding event handlers
            this.KeyDown += Game_KeyDown;

            //adding game zone to the game
            gameZone = new GameZone { 
                Left = 40,
                Top = 40
            };
            this.Controls.Add(gameZone);

            //adding snake to the game
            snake = new Snake(this);
            snake.Render();

            //adding food to the game

        }

        private void Game_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left)
            {
                snake.MoveLeft();
            }
            else if(e.KeyCode == Keys.Right)
            {
                snake.MoveRight();
            }
            else if (e.KeyCode == Keys.Up)
            {
                snake.MoveUp();
            }
            else if (e.KeyCode == Keys.Down)
            {
                snake.MoveDown();
            }
            else if (e.KeyCode == Keys.Q)
            {
                snake.Grow();
            }
        }


    }
}
