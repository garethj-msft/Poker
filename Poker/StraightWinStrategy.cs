using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class StraightWinStrategy : IHandWinStrategy
    {
        private int straightCount = 0;
        private IList<Card> cards = null;

        public WinCondition CheckOverallWin()
        {
            return straightCount == cards.Count ? WinCondition.Straight : WinCondition.NoWin;
        }

        public WinCondition CheckPerCardWin(int cardIndex)
        {
            // Bump the straightCount if we're one more than the last card
            if (cardIndex > 0 && cards[cardIndex].Face == cards[cardIndex - 1].Face + 1)
            {
                straightCount++;
            }
            return WinCondition.NoWin;
        }

        public void InitializeWinSession(IList<Card> cards)
        {
            this.straightCount = 1;
            this.cards = cards;
        }
    }
}
