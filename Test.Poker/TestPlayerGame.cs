using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;

namespace Test.Poker
{
    [TestClass]
    public class TestPlayerGame
    {
        [TestMethod]
        public void TestFlushOverStraight()
        {
            var sut = new PlayerGame();
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 9 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 10 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 12 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 13 });

            Assert.AreEqual(WinCondition.Flush, sut.CalculateHighestWin(), "Wrong highest win.");
        }

        [TestMethod]
        public void TestFlush()
        {
            var sut = new PlayerGame();
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 7 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 2 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 5 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 12 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 13 });

            Assert.AreEqual(WinCondition.Flush, sut.CalculateHighestWin(), "Wrong highest win.");
        }

        [TestMethod]
        public void TestStraight()
        {
            var sut = new PlayerGame();
            sut.Deal(new Card { Suit = Suit.Hearts,   Face = 9 });
            sut.Deal(new Card { Suit = Suit.Clubs,    Face = 10 });
            sut.Deal(new Card { Suit = Suit.Diamonds, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts,   Face = 12 });
            sut.Deal(new Card { Suit = Suit.Hearts,   Face = 13 });

            Assert.AreEqual(WinCondition.Straight, sut.CalculateHighestWin(), "Wrong highest win.");
        }

        [TestMethod]
        public void TestPair()
        {
            var sut = new PlayerGame();
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 9 });
            sut.Deal(new Card { Suit = Suit.Clubs, Face = 10 });
            sut.Deal(new Card { Suit = Suit.Diamonds, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 2 });

            Assert.AreEqual(WinCondition.Pair, sut.CalculateHighestWin(), "Wrong highest win.");
        }

        [TestMethod]
        public void TestTwoPair()
        {
            var sut = new PlayerGame();
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 9 });
            sut.Deal(new Card { Suit = Suit.Clubs, Face = 9 });
            sut.Deal(new Card { Suit = Suit.Diamonds, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 2 });

            Assert.AreEqual(WinCondition.TwoPair, sut.CalculateHighestWin(), "Wrong highest win.");
        }

        [TestMethod]
        public void TestThreeNotTwoPair()
        {
            var sut = new PlayerGame();
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 9 });
            sut.Deal(new Card { Suit = Suit.Clubs, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Diamonds, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 2 });

            Assert.AreEqual(WinCondition.Pair, sut.CalculateHighestWin(), "Wrong highest win.");
        }

        [TestMethod]
        public void TestFlushOverPair()
        {
            var sut = new PlayerGame();
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 9 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 10 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 2 });

            Assert.AreEqual(WinCondition.Flush, sut.CalculateHighestWin(), "Wrong highest win.");
        }

        [TestMethod]
        public void TestFlushOverTwoPair()
        {
            var sut = new PlayerGame();
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 9 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 9 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 11 });
            sut.Deal(new Card { Suit = Suit.Hearts, Face = 2 });

            Assert.AreEqual(WinCondition.Flush, sut.CalculateHighestWin(), "Wrong highest win.");
        }

    }
}
