using System;
using System.Collections.Generic;
using NUnit.Framework;
using HoboTacticsCodeTest.Cards;


namespace HoboTests
{
    [TestFixture]
    public class CardTest
    {
        // make some things I think I'll need
        Deck StandardDeck = new Deck();
        Deck Hand = new Deck();
        Deck Discard = new Deck();
        List<String> StandardCards = new List<string>() { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };
        List<String> StandardSuits = new List<string>() { "Diamonds", "Spades", "Clubs", "Hearts" };
        List<String> NonStandardCards = new List<String>() { "Joker 1", "Joker 2" };
        List<String> ExpectedDeck = new List<string>();

        [SetUp]
        public void CreateCards()
        {
            // add cards to a deck, and put their names in a list at the same time
            // in general, check the deck matches the list after doing a test
            foreach (String SCard in StandardCards)
            {
                foreach (String SSuit in StandardSuits)
                {
                    StandardDeck.PutCardTop(new Card((SCard + " of " + SSuit)));
                    ExpectedDeck.Add((SCard + " of " + SSuit));
                }
            }
            foreach (String Joker in NonStandardCards)
            {
                StandardDeck.PutCardTop(new Card(Joker));
                ExpectedDeck.Add(Joker);
            }
        }
        [Test]
        public void TestDeckDrawTop()
        {
            String CurrentCard = StandardDeck.DrawCardTop().CardID;
            CollectionAssert.Contains(ExpectedDeck, CurrentCard);
        }
        [Test]
        public void TestDeckConstruction()
        {
            int CardCount = StandardDeck.Count;
            for (int i = 1; i <= CardCount; i++)
            {
                Card CurrentCard = StandardDeck.DrawCardTop();
                Assert.IsTrue(ExpectedDeck.Contains(CurrentCard.CardID));
                StandardDeck.PutCardBottom(CurrentCard);
                
            }
        }
        [Test]
        public void TestShuffle()
        {
            StandardDeck.ShuffleDeck(500);
            TestDeckConstruction();
        }

    }
}
