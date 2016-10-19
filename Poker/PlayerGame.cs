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
            WinStrategies = new List<IHandWinStrategy>();
            Hand = new SortedSet<Card>(new CardComparer());
        }

        public void Deal(Card card)
        {
            if (Hand.Count >= HandSize) throw new ArgumentException("Hand full.", nameof(card));
            Hand.Add(card);
        }

        // Win Strategies to be injected.
        public IList<IHandWinStrategy> WinStrategies { get; private set; }

        public SortedSet<Card> Hand { get; private set; }

        public WinCondition CalculateHighestWin()
        {
            WinCondition highestWin = WinCondition.NoWin;
            IList<Card> cards = Hand.ToList();
            foreach ( var strategy in WinStrategies)
            {
                strategy.InitializeWinSession(cards);
            }
            for (int i = 0; i < cards.Count; i++)
            {
                foreach (var strategy in WinStrategies)
                {
                    WinCondition cardCondition = strategy.CheckPerCardWin(i);
                    if (cardCondition > highestWin)
                    {
                        highestWin = cardCondition;
                    }
                }
            }
            foreach (var strategy in WinStrategies)
            {
                WinCondition overallCondition = strategy.CheckOverallWin();
                if (overallCondition > highestWin)
                {
                    highestWin = overallCondition;
                }
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
