using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public interface IHandWinStrategy
    {
        void InitializeWinSession(IList<Card> cards);
        WinCondition CheckPerCardWin(int cardIndex);
        WinCondition CheckOverallWin();
    }
}
