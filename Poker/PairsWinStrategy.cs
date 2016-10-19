using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class PairsWinStrategy : IHandWinStrategy
    {
        int firstPairIndex = -1, secondPairIndex = -1;
        private IList<Card> cards = null;

        public WinCondition CheckOverallWin()
        {
            return WinCondition.NoWin;
        }

        public WinCondition CheckPerCardWin(int cardIndex)
        {
            // List is sorted, so pairs are next to each other.
            if (cardIndex > 0 && firstPairIndex == -1 && cards[cardIndex].Face == cards[cardIndex - 1].Face)
            {
                firstPairIndex = cardIndex;
                return WinCondition.Pair;
            }
            // Only look for second pair after the first pair
            if (firstPairIndex != -1 && secondPairIndex == -1 && cardIndex > (firstPairIndex + 1) && cards[cardIndex].Face == cards[cardIndex - 1].Face)
            {
                secondPairIndex = cardIndex;
                return WinCondition.TwoPair;
            }
            return WinCondition.NoWin;
        }

        public void InitializeWinSession(IList<Card> cards)
        {
            firstPairIndex = -1;
            secondPairIndex = -1;
            this.cards = cards;
        }
    }
}
