using NUnit.Framework;
using System;
using HoboTacticsCodeTest.Cards;

namespace HoboTacticsCodeTest
{
    [TestFixture()]
    public class CardTests
    {
        Deck testDeck = new Deck();

        [SetUp]
        public void SetUp()
        {
            for (int x = 0; x < 52; x++) {
                testDeck.PutCardRandom (new Card(x.ToString()));
            }

            Assert.AreEqual (52, testDeck.Count);
        }

        [TearDown()]
        public void TearDown()
        {
            while(testDeck.Count > 0) {
                testDeck.RemoveCard (testDeck.DrawCard ());
            }
        }

        [Test()]
        public void PutCardTest ()
        {
            testDeck.PutCard (new Card ("testcard"));
            Assert.AreEqual (testDeck.DrawCard ().CardID, "testcard");
        }

        [Test()]
        public void PutCardBottomTest ()
        {
            testDeck.PutCardBottom (new Card ("testcard2"));
            Assert.AreEqual (testDeck.DrawCardBottom ().CardID, "testcard2");
        }
    }
}

