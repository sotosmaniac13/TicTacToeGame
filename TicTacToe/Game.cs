using System;
using System.Drawing;
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

        
        public Game()
        {
            InitializeComponent();
        }
        

        public void NewGame(string Pl1, string Pl2)
        {
            player1.Name = Pl1;
            player2.Name = Pl2;

            CurrentPlayer = FirstPlayer(player1, player2);

            label1.Text = player1.Name;
            label3.Text = player2.Name;

            label5.Text = "Current player:  " + CurrentPlayer.Name;
        }
        

        //Returns which player plays first.
        private Player FirstPlayer(Player Pl1, Player Pl2)
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


        //Changes Player On Each Turn.
        private void ChangePlayerOnEachTurn(Player player)
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


        //Inserts X or O symbol depending on the current player that clicked on a button.
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


        //Checks if there is a winner on each turn.
        private void IsThereAWinner(Player winner)
        {
            if(winner.ClickedButtons.Contains(1) && winner.ClickedButtons.Contains(2) && winner.ClickedButtons.Contains(3))
            {
                WinnerFound(winner);
            }

            else if (winner.ClickedButtons.Contains(4) && winner.ClickedButtons.Contains(5) && winner.ClickedButtons.Contains(6))
            {
                WinnerFound(winner);
            }

            else if (winner.ClickedButtons.Contains(7) && winner.ClickedButtons.Contains(8) && winner.ClickedButtons.Contains(9))
            {
                WinnerFound(winner);
            }

            else if (winner.ClickedButtons.Contains(1) && winner.ClickedButtons.Contains(4) && winner.ClickedButtons.Contains(7))
            {
                WinnerFound(winner);
            }

            else if (winner.ClickedButtons.Contains(2) && winner.ClickedButtons.Contains(5) && winner.ClickedButtons.Contains(8))
            {
                WinnerFound(winner);
            }

            else if (winner.ClickedButtons.Contains(3) && winner.ClickedButtons.Contains(6) && winner.ClickedButtons.Contains(9))
            {
                WinnerFound(winner);
            }

            else if (winner.ClickedButtons.Contains(1) && winner.ClickedButtons.Contains(5) && winner.ClickedButtons.Contains(9))
            {
                WinnerFound(winner);
            }

            else if (winner.ClickedButtons.Contains(3) && winner.ClickedButtons.Contains(5) && winner.ClickedButtons.Contains(7))
            {
                WinnerFound(winner);
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


        //What to do when a winner is found.
        private void WinnerFound(Player player)
        {
            player.Wins += 1;
            ChangeLabelValues(player);
            LockGrid();
            ResultScreen(player);
        }


        //Shows ResultScreen if a turn ends.
        private void ResultScreen(Player player)
        {
            RoundResult roundResult = new RoundResult();
            roundResult.label1.Text = player.Name;
            roundResult.Show();
        }
        private void ResultScreen()
        {
            RoundResult roundResult = new RoundResult();
            roundResult.label1.Text = "It's a draw..";
            roundResult.label2.Visible = false;
            roundResult.Show();
        }


        //Changes scores on the board if any player wins or if there is a draw.
        private void ChangeLabelValues(Player player)
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
        private void AddClickToList(Player player, int buttonNum)
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


        //Locks the grid so no more buttons can be pressed when the round ends.
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


        //Resets Game's grid for a new round.
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



        //CLICK EVENTS

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            PictureBoxClicked(sender, e);
        }
        

        //Runs on every user's Click on the grid
        private void PictureBoxClicked(object sender, EventArgs e)
        {
            PictureBox clickedPictureBox = (PictureBox)sender;
            AddClickToList(CurrentPlayer, Convert.ToInt16(clickedPictureBox.Tag));
            clickedPictureBox.Image = Box_Click(CurrentPlayer);
            clickedBoxes += 1;
            IsThereAWinner(CurrentPlayer);
            ChangePlayerOnEachTurn(CurrentPlayer);
            label5.Text = "Current player:  " + CurrentPlayer.Name;
            clickedPictureBox.Enabled = false;
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
