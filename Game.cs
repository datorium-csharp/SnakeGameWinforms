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
        Food food = null;

        public Game()
        {
            InitializeComponent();
            InitializeGame();
            InitializeMainTimer();
        }

        private void InitializeGame()
        {
            //add event handlers
            this.KeyDown += Game_KeyDown;

            //add game zone
            gameZone = new GameZone();
            this.Controls.Add(gameZone);

            //add snake
            snake = new Snake(this);
            this.Controls.Add(snake.body[0]);
            snake.body[0].BringToFront();

            //add food
            food = new Food(this);
            food.Render();

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
            snake.Move();
            SnakeFoodCollision();
            SnakeSelfCollision();
            SnakeBorderCollision();
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

        private void SnakeFoodCollision()
        {
            if (snake.body[0].Bounds.IntersectsWith(food.Bounds))
            {
                //collision detected
                snake.Grow();
                food.Relocate();
                while (FoodSnakeBodyCollide())
                {
                    food.Relocate();
                    DecreseTimeInterval();
                }
            }
        }

        private bool FoodSnakeBodyCollide()
        {
            foreach(var pixel in snake.body)
            {
                if (pixel.Bounds.IntersectsWith(food.Bounds))
                {
                    //collision detected
                    return true;
                }
            }
            return false;
        }

        private void SnakeSelfCollision()
        {
            for(int i = 1; i < snake.body.Count-1; i++)
            {
                if (snake.body[i].Bounds.IntersectsWith(snake.body[0].Bounds))
                {
                    //self collision detected
                    GameOver();
                }
            }
        }

        private void GameOver()
        {

        }

        private void SnakeBorderCollision()
        {

        }

        private void DecreseTimeInterval()
        {
            mainTimer.Interval = (int)(mainTimer.Interval * 0.80);
        }


//Homework:
//1 InitialiseSnake() adds 3 pixels, instead of just one head.
//2 Add scoring(with scoring label in the game window)
//3 Add food spawning logic, so that food is generated on the grid, but **not on the snake body**! 
//4 Every 5 collisions, the speed of snake increases
//5 Border collision check and logic
//6 Add count-up timer to your game
//7 Block it from moving in the opposite direction(optional)
//8 add enemies :)

    }
}
