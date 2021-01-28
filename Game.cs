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
        
        public Game()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void InitializeGame()
        {
            //adding game zone to the game
            gameZone = new GameZone { 
                Left = 40,
                Top = 40
            };
            this.Controls.Add(gameZone);

            //adding snake to the game


            //adding food to the game


        }
    }
}
