using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Poker
{
    public enum Suit
    {
        Hearts   = 0,
        Clubs    = 1,
        Spades   = 2,
        Diamonds = 3
    }

    public struct Card
    {
        public Suit Suit;
        public int Face;
    }
}
