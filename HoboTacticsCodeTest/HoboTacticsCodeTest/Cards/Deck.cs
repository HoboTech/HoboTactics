using System;
using System.Collections.Generic;

namespace HoboTacticsCodeTest.Cards
{
    public class Deck
    {
        private List<Card> _cards = new List<Card>();
        protected Random _rGen = new Random ((int)DateTime.Now.Ticks);

        /// <summary>
        /// Gets a list of the cards in the deck.
        /// Used internally.
        /// </summary>
        /// <value>The cards.</value>
        protected List<Card> Cards {
            get {
                return this._cards;
            }
        }

        /// <summary>
        /// Gets the card count of the deck.
        /// </summary>
        /// <value>The count.</value>
        public int Count {
            get {
                return Cards.Count;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HoboTacticsCodeTest.Cards.Deck"/> class.
        /// </summary>
        public Deck ()
        {
        }

        /// <summary>
        /// Shuffles the deck.
        /// Takes top card from deck, and reinserts at random position in deck.
        /// </summary>
        /// <param name="numCardsToShuffle">Number of top cards to shuffle back into the deck.</param>
        public void ShuffleDeck(int numCardsToShuffle) {
            for(int x = 0; x < numCardsToShuffle; x++) {
                Card sCard = this.DrawCard ();
                this.PutCardRandom (sCard);
            }
        }

        /// <summary>
        /// Draws a card from the top of the deck.
        /// </summary>
        /// <returns>The card.</returns>
        public Card DrawCard() {
            return this.DrawCardTop ();
        }

        /// <summary>
        /// Draws a card from the top of the deck.
        /// </summary>
        /// <returns>The card top.</returns>
        public Card DrawCardTop() {
            return this._drawCard(this.Cards.Count - 1);
        }

        /// <summary>
        /// Draws a card from the bottom of the deck.
        /// </summary>
        /// <returns>The card bottom.</returns>
        public Card DrawCardBottom() {
            return this._drawCard (0);
        }

        /// <summary>
        /// Draws a card randomly from inside the deck.
        /// </summary>
        /// <returns>The card.</returns>
        public Card DrawCardRandom() {
            return this._drawCard ((int)(this._rGen.NextDouble () * this.Cards.Count));
        }

        /// <summary>
        /// Draws a card from a specific position inside the deck.
        /// </summary>
        /// <returns>The card.</returns>
        /// <param name="at">Position to draw from.</param>
        public Card DrawCardAt(int at) {
            return this._drawCard (at);
        }

        /// <summary>
        /// Puts a card into the deck, on the top.
        /// </summary>
        /// <param name="card">Card.</param>
        public void PutCard(Card card) {
            this.PutCardTop (card);
        }

        /// <summary>
        /// Puts a card into the deck, on the top.
        /// </summary>
        /// <param name="card">Card.</param>
        public void PutCardTop(Card card) {
            this._putCard (card, this.Cards.Count);
        }

        /// <summary>
        /// Puts a card into the deck, on the bottom.
        /// </summary>
        /// <param name="card">Card.</param>
        public void PutCardBottom(Card card) {
            this._putCard (card, 0);
        }

        /// <summary>
        /// Puts a card into the deck, at random position.
        /// </summary>
        /// <param name="card">Card.</param>
        public void PutCardRandom(Card card) {
            this._putCard (card, (int)(this._rGen.NextDouble () * this.Cards.Count));
        }

        /// <summary>
        /// Puts a card into the deck, at specified position.
        /// </summary>
        /// <param name="card">Card.</param>
        /// <param name="at">Position.</param>
        public void PutCardAt(Card card, int at) {
            this._putCard (card, at);
        }

        /// <summary>
        /// Removes card from deck.
        /// </summary>
        /// <param name="card">Card.</param>
        public void RemoveCard(Card card) {
            this.Cards.Remove (card);
        }

        protected Card _drawCard(int at) {
            this.Cards[at].Deck = null; // disassociate the card from the deck
            Card RequestedCard = this.Cards[at];
            this.Cards.RemoveAt(at); // remove the card from the deck
            return RequestedCard;


        }

        protected void _putCard(Card card, int at) {
            card.Deck = this; // associate the card to the deck
            this.Cards.Insert(at, card); // add the card to the deck
        }

        /// <summary>
        /// Draws a card from the deck by it's CardID value
        /// </summary>
        /// <param name="cardname">Card.CardID</param>
        public Card DrawCardByName(string cardname)
        {
            //find index location for name, pass that to _drawcard
            int namedlocation;
            namedlocation = Cards.FindIndex(i => i.CardID == cardname);
            return this._drawCard(namedlocation);
            //return Cards.Find(i => i.CardID == cardname);   
            //throw new NotImplementedException();
        }
    }
}

