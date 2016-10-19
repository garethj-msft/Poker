using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    public class PlayerGame
    {
        const int HandSize = 5;

        public PlayerGame()
        {
            Hand = new SortedSet<Card>(new CardComparer());
        }

        public void Deal(Card card)
        {
            if (Hand.Count >= HandSize) throw new ArgumentException("Hand full.", nameof(card));
            Hand.Add(card);
        }

        public SortedSet<Card> Hand { get; private set; }

        public WinCondition CalculateHighestWin()
        {
            WinCondition highestWin = WinCondition.NoWin;

            int[] flushes = new int[Enum.GetValues(typeof(Suit)).Length];
            int straightCount = 1;
            int firstPairIndex = -1, secondPairIndex = -1;

            IList<Card> cards = Hand.ToList();
            for (int i = 0; i < cards.Count; i++)
            {
                // Bump the flush count for each suit card found.
                flushes[(int)cards[i].Suit]++;

                // Bump the straightCount if we're one more than the last card
                if (i > 0 && cards[i].Face == cards[i - 1].Face + 1)
                {
                    straightCount++;
                }

                // List is sorted, so pairs are next to each other.
                if (i > 0 && firstPairIndex == -1 && cards[i].Face == cards[i - 1].Face)
                {
                    firstPairIndex = i;
                    if (WinCondition.Pair > highestWin) highestWin = WinCondition.Pair;
                }
                // Only look for second pair after the first pair
                if (firstPairIndex != -1 && secondPairIndex == -1 && i > (firstPairIndex + 1) && cards[i].Face == cards[i - 1].Face)
                {
                    secondPairIndex = i;
                    if (WinCondition.TwoPair > highestWin) highestWin = WinCondition.TwoPair;
                }
            }
            if (straightCount == Hand.Count)
            {
                if (WinCondition.Straight > highestWin) highestWin = WinCondition.Straight;
            }
            if (flushes.Any(f => f == Hand.Count))
            {
                if (WinCondition.Flush > highestWin) highestWin = WinCondition.Flush;
            }
            return highestWin;
        }

        private class CardComparer : IComparer<Card>
        {
            public int Compare(Card x, Card y)
            {
                var compared = x.Face.CompareTo(y.Face);
                if (compared != 0)
                {
                    return compared;
                }

                // Some order for face dupes
                return x.GetHashCode().CompareTo(y.GetHashCode());
            }
        }
    }
}
