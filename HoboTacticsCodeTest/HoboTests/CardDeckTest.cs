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

        private Deck _createStandardDeck(Deck AnotherDeck)
        {
            foreach (String SCard in StandardCards)
            {
                foreach (String SSuit in StandardSuits)
                {
                    AnotherDeck.PutCardTop(new Card((SCard + " of " + SSuit)));
                    //ExpectedDeck.Add((SCard + " of " + SSuit));
                }
            }
            foreach (String Joker in NonStandardCards)
            {
                AnotherDeck.PutCardTop(new Card(Joker));
                //ExpectedDeck.Add(Joker);
            }
            return (AnotherDeck);
        }
        
        [TestFixtureSetUp]
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
        //[Ignore]
        public void TestDeckDrawTop()
        {
            Card CurrentCard = StandardDeck.DrawCardTop();
            String CurrentCardID = CurrentCard.CardID;
            StandardDeck.PutCardRandom(CurrentCard);
            CollectionAssert.Contains(ExpectedDeck, CurrentCardID);
        }
        [Test]
        //[Ignore]
        public void TestDeckConstruction()
        {
            int CardCount = StandardDeck.Count;
            StandardDeck.ShuffleDeck(500);
            for (int i = 1; i <= CardCount; i++)
            {
                Card CurrentCard = StandardDeck.DrawCardTop();
                StandardDeck.PutCardBottom(CurrentCard); 
                //ExpectedDeck.Remove(
                Assert.IsTrue(ExpectedDeck.Contains(CurrentCard.CardID));
                Assert.AreEqual(54,StandardDeck.Count);
                
            }
        }
        [Test]
        //[Ignore]
        public void TestPutDrawPutTop()
        {
            //PutCardTop will add a card to the deck, DrawCardTop shows you but leaves it in the deck
            int Expected_Deck_Size = 1;
            Deck TestDeck = new Deck();
            Card TestCard = new Card("uno");
            TestDeck.PutCardTop(TestCard);
            //Assert.AreEqual(Expected_Deck_Size,TestDeck.Count);
            TestDeck.DrawCardTop();
            //Assert.AreEqual(Expected_Deck_Size,TestDeck.Count);
            TestDeck.PutCardTop(TestCard);
            Assert.AreEqual(Expected_Deck_Size,TestDeck.Count);
        }
        [Test]
        //[Ignore]
        public void TestPutDrawPutBottom()
        {
            //PutCardTop will add a card to the deck, DrawCardTop shows you but leaves it in the deck
            int Expected_Deck_Size = 1;
            Deck TestDeck = new Deck();
            Card TestCard = new Card("uno");
            TestDeck.PutCardBottom(TestCard);
            //Assert.AreEqual(Expected_Deck_Size,TestDeck.Count);
            TestDeck.DrawCardBottom();
            //Assert.AreEqual(Expected_Deck_Size,TestDeck.Count);
            TestDeck.PutCardBottom(TestCard);
            Assert.AreEqual(Expected_Deck_Size, TestDeck.Count);
        }
        [Test]
        //[Ignore]
        public void TestDrawPutBottomDrawTopPutBottom()
        {
            //PutCardTop will add a card to the deck, DrawCardTop shows you but leaves it in the deck
            int Expected_Deck_Size = 1;
            Deck TestDeck = new Deck();
            Card TestCard = new Card("uno");
            TestDeck.PutCardBottom(TestCard);
            //Assert.AreEqual(Expected_Deck_Size,TestDeck.Count);
            TestDeck.DrawCardTop();
            //Assert.AreEqual(Expected_Deck_Size,TestDeck.Count);
            TestDeck.PutCardBottom(TestCard);
            Assert.AreEqual(Expected_Deck_Size, TestDeck.Count);
        }
        [Test]
        //[Ignore]
        public void TestShuffle()
        {
            StandardDeck.ShuffleDeck(500);
            TestDeckConstruction();
        }
        [Test]
        //[Ignore]
        public void TestDrawCardByName()
        {
            //basic proof
            //Deck tempdeck = new Deck();
            //Card tempcard = new Card("catch me if you can");
            //tempdeck.PutCardTop(tempcard);
            //tempdeck.DrawCardByName("catch me if you can");

            //more involved proof
            int CardCount = StandardDeck.Count;
            Assert.AreEqual(54, StandardDeck.Count);
            for (int i = 0; i < CardCount; i++)
            {
                Card CurrentCard = StandardDeck.DrawCardByName(ExpectedDeck[i]);
                StandardDeck.PutCardBottom(CurrentCard);
                Assert.AreEqual(CurrentCard.CardID, ExpectedDeck[i]);
                //Assert.IsTrue(ExpectedDeck.Contains(CurrentCard.CardID));
            }
        }
        [Test]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PutCardTooHigh()
        {
            Deck TestDeck = new Deck();
            Card DeckStarter = new Card("DeckStarter");
            Card DeckBreaker = new Card("DeckBreaker");
            TestDeck.PutCardTop(DeckStarter);
            int CardCount = StandardDeck.Count;
            int CardCountPlus = CardCount + 1;
            TestDeck.PutCardAt(DeckBreaker,CardCountPlus);                  
        }
        [Test]
        //[ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PutCardTooLow()
        {
            Deck TestDeck = new Deck();
            Card DeckStarter = new Card("DeckStarter");
            Card DeckBreaker = new Card("DeckBreaker");
            TestDeck.PutCardTop(DeckStarter);
            int CardCount = StandardDeck.Count;
            int CardCountMinus = CardCount - CardCount - 1;
            TestDeck.PutCardAt(DeckBreaker, CardCountMinus);
        }
        [Test]
        public void MergeDecks()
        {
            Deck TestDeck1 = new Deck();
            this._createStandardDeck(TestDeck1);
            Deck TestDeck2 = new Deck();
            this._createStandardDeck(TestDeck1);
            int CardCount1 = TestDeck1.Count;
            int CardCount2 = TestDeck2.Count;
            TestDeck1.AbsorbDeck(TestDeck2);
            Assert.AreEqual((CardCount1 + CardCount2), TestDeck1.Count);            
        }

    }
}
