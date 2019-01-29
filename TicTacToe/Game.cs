using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToe.Properties;

namespace TicTacToe
{
    public partial class Game : Form
    {
        Player player1 = new Player();
        Player player2 = new Player();
        Player CurrentPlayer { get; set; }
        int clickedBoxes = 0;
        int Draws = 0;
        
        
        public Game()
        {
            InitializeComponent();
        }

        public void NewGame(string Pl1, string Pl2)
        {
            player1.Name = Pl1;
            player1.Wins = 0;
            player2.Name = Pl2;
            player2.Wins = 0;

            CurrentPlayer = FirstPlayer(player1, player2);

            label1.Text = player1.Name;
            label3.Text = player2.Name;
            label6.Text = player1.Wins.ToString();
            label7.Text = player2.Wins.ToString();
            label9.Text = Draws.ToString();
            label5.Text = "Current player:  " + CurrentPlayer.Name;
        }

        
        


        //Returns which player plays first
        public Player FirstPlayer(Player Pl1, Player Pl2)
        {
            Random rndm = new Random();
            int firstPlayer = rndm.Next(1, 3);

            if (firstPlayer == 1)
            {
                return Pl1;
            }
            else
                return Pl2;
        }

        public void ChangePlayerOnEachTurn(Player player)
        {
            if (player == player1)
            {
                CurrentPlayer = player2;
            }
            if (player == player2)
            {
                CurrentPlayer = player1;
            }
        }

        //Insert X or O symbol depending on the current player that clicked on a button.
        private Bitmap Box_Click(Player player)
        {
            if (player == player1)
            {
                Bitmap img = Resources.X;
                return img;
            }
            else
            {
                Bitmap img = Resources.O;
                return img;
            }
        }

        //Check if there is a winner on each turn.
        public void IsThereAWinner(Player player)
        {
            if(player.ClickedButtons.Contains(1) && player.ClickedButtons.Contains(2) && player.ClickedButtons.Contains(3))
            {
                player.Wins += 1;
                ChangeLabelValues(player);
                LockGrid();
                ResultScreen(player);
            }

            else if (player.ClickedButtons.Contains(4) && player.ClickedButtons.Contains(5) && player.ClickedButtons.Contains(6))
            {
                player.Wins += 1;
                ChangeLabelValues(player);
                LockGrid();
                ResultScreen(player);
            }

            else if (player.ClickedButtons.Contains(7) && player.ClickedButtons.Contains(8) && player.ClickedButtons.Contains(9))
            {
                player.Wins += 1;
                ChangeLabelValues(player);
                LockGrid();
                ResultScreen(player);
            }

            else if (player.ClickedButtons.Contains(1) && player.ClickedButtons.Contains(4) && player.ClickedButtons.Contains(7))
            {
                player.Wins += 1;
                ChangeLabelValues(player);
                LockGrid();
                ResultScreen(player);
            }

            else if (player.ClickedButtons.Contains(2) && player.ClickedButtons.Contains(5) && player.ClickedButtons.Contains(8))
            {
                player.Wins += 1;
                ChangeLabelValues(player);
                LockGrid();
                ResultScreen(player);
            }

            else if (player.ClickedButtons.Contains(3) && player.ClickedButtons.Contains(6) && player.ClickedButtons.Contains(9))
            {
                player.Wins += 1;
                ChangeLabelValues(player);
                LockGrid();
                ResultScreen(player);
            }

            else if (player.ClickedButtons.Contains(1) && player.ClickedButtons.Contains(5) && player.ClickedButtons.Contains(9))
            {
                player.Wins += 1;
                ChangeLabelValues(player);
                LockGrid();
                ResultScreen(player);
            }

            else if (player.ClickedButtons.Contains(3) && player.ClickedButtons.Contains(5) && player.ClickedButtons.Contains(7))
            {
                player.Wins += 1;
                ChangeLabelValues(player);
                LockGrid();
                ResultScreen(player);
            }

            else
            {
                if (clickedBoxes == 9)
                {
                    int oldValue = int.Parse(label9.Text);
                    oldValue += 1;
                    label9.Text = oldValue.ToString();
                    LockGrid();
                    ResultScreen();
                }
            }
        }

        public void ResultScreen(Player player)
        {
            RoundResult roundResult = new RoundResult();
            roundResult.label1.Text = player.Name;
            roundResult.Show();
        }

        public void ResultScreen()
        {
            RoundResult roundResult = new RoundResult();
            roundResult.label1.Text = "It's a draw..";
            roundResult.label2.Visible = false;
            roundResult.Show();
        }

        //Change scores on the board if any player wins or if there is a draw
        public void ChangeLabelValues(Player player)
        {
            if (player == player1)
            {
                int oldValue = int.Parse(label6.Text);
                oldValue += 1;
                label6.Text = oldValue.ToString();
            }

            if (player == player2)
            {
                int oldValue = int.Parse(label7.Text);
                oldValue += 1;
                label7.Text = oldValue.ToString();
            }
        }

        //Adds the clicked button to the current player's list of clicked buttons.
        public void AddClickToList(Player player, int buttonNum)
        {
            if (player == player1)
            {
                player1.ClickedButtons.Add(buttonNum);
            }
            else
            {
                player2.ClickedButtons.Add(buttonNum);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 1);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox1.Enabled = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 2);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox2.Enabled = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 3);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox3.Enabled = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 4);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox4.Enabled = false;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 5);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox5.Enabled = false;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox6.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 6);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox6.Enabled = false;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox7.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 7);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox7.Enabled = false;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            pictureBox8.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 8);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox8.Enabled = false;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            pictureBox9.Image = Box_Click(CurrentPlayer);
            AddClickToList(CurrentPlayer, 9);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            pictureBox9.Enabled = false;
        }
        
        private void LockGrid()
        {
            pictureBox1.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;
            pictureBox6.Enabled = false;
            pictureBox7.Enabled = false;
            pictureBox8.Enabled = false;
            pictureBox9.Enabled = false;
        }

        //Reset Game's Grid
        private void NewRound()
        {
            pictureBox1.Image = null;
            pictureBox1.Enabled = true;
            pictureBox2.Image = null;
            pictureBox2.Enabled = true;
            pictureBox3.Image = null;
            pictureBox3.Enabled = true;
            pictureBox4.Image = null;
            pictureBox4.Enabled = true;
            pictureBox5.Image = null;
            pictureBox5.Enabled = true;
            pictureBox6.Image = null;
            pictureBox6.Enabled = true;
            pictureBox7.Image = null;
            pictureBox7.Enabled = true;
            pictureBox8.Image = null;
            pictureBox8.Enabled = true;
            pictureBox9.Image = null;
            pictureBox9.Enabled = true;

            player1.ClickedButtons.Clear();
            player2.ClickedButtons.Clear();
            clickedBoxes = 0;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            NewRound();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        
    }
}
