using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class StartScreen : Form
    {
        public StartScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            Game newGame = new Game();
            newGame.Show();

            //Players enter their names in the textboxes.
            //If they don't enter anything, default names will be provided.
            string Player1 = textBox1.Text;
            string Player2 = textBox2.Text;

            if (String.IsNullOrWhiteSpace(Player1))
            {
                Player1 = "Player1";
            }

            if (String.IsNullOrWhiteSpace(Player2))
            {
                Player2 = "Player2";
            }

            newGame.NewGame(Player1, Player2);
        }
    }
}
