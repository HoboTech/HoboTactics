using System;
using HoboTacticsCodeTest.Cards;

namespace HoboTacticsCodeTest
{
    class MainClass
    {
        public static void Main (string[] args)
        {
            Deck deck = new Deck ();
            int cardsInDeck = 52;

            // A hand is just a deck.
            // ...A discard pile would just be a deck as well.
            // New classes can be made for hands and discards
            // inherting from deck with specific functions
            // required by hands and discards.
            Deck hand = new Deck ();

            for (int x = 0; x < cardsInDeck; x++) {
                deck.PutCardTop (new Card (""+x));
            }

            deck.ShuffleDeck (2000);

            for (int x = 0; x < 5; x++) {
                hand.PutCard (deck.DrawCard ());
            }

            Console.WriteLine ("Your Hand:");
            for (int x = 0; x < hand.Count; x++) {
                Card dCard = hand.DrawCardAt (x);
                Console.WriteLine ("Card ID: " + dCard.CardID);
            }
            Console.WriteLine ("Cards Left In Deck: " + deck.Count);

            Console.Read();
        }
    }
}
