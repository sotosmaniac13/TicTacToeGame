using System.Collections.Generic;

namespace TicTacToe
{
    public class Player
    {
        public string Name { get; set; }

        public int Wins { get; set; }

        public List<int> ClickedButtons = new List<int>();
    }
}
