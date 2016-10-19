using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public enum WinCondition
    {
        Flush = 4,
        Straight = 3,
        TwoPair = 2,
        Pair = 1,
        NoWin = 0
    }
}
