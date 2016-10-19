using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class FlushWinStrategy : IHandWinStrategy
    {
        int[] flushes = null; 
        private IList<Card> cards = null;

        public WinCondition CheckOverallWin()
        {
            return flushes.Any(f => f == cards.Count) ? WinCondition.Flush : WinCondition.NoWin;
        }

        public WinCondition CheckPerCardWin(int cardIndex)
        {
            // Bump the flush count for each suit card found.
            flushes[(int)cards[cardIndex].Suit]++;
            return WinCondition.NoWin;
        }

        public void InitializeWinSession(IList<Card> cards)
        {
            flushes = new int[Enum.GetValues(typeof(Suit)).Length];
            this.cards = cards;
        }
    }
}
