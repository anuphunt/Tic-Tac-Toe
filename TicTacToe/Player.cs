using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    interface IPlayer
    {
        Coordinates play(int[,] matrix);
        int Symbol { get; set; }
    }
}
