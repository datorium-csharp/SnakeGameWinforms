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
        Food food = null;

        private Timer timerMove = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeTimerMove();
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
            food = new Food(this);
            food.Render();            
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

        private void SnakeFoodCollision()
        {
            if (snake.pixels[0].Bounds.IntersectsWith(food.Bounds))
            {
                //collision detected
                MessageBox.Show("Collision detected");
            }
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
            snake.Move();
            SnakeFoodCollision();
        }

        //- InitialiseSnake() adds 3 pixels, instead of just one head.
        //- Add scoring(with scoring label in the game window)
        //- Add food spawning logic, so that food is generated on the grid, but **not on the snake body**! 
        //- Every 5 collisions, the speed of snake increases
        //- Border collision check and logic
        //- Add count-up timer to your game
        //- Block it from moving in the opposite direction(optional)
        //- add enemies :)

    }
}
