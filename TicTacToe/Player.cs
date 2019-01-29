using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Player
    {
        public string Name { get; set; }

        public int Wins { get; set; }

        public List<int> ClickedButtons = new List<int>();
    }
}
