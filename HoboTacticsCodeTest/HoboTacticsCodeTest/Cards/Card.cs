using System;

namespace HoboTacticsCodeTest.Cards
{
    public class Card
    {
        private String _cardId;
        private Deck _deck;

        /// <summary>
        /// Gets or sets the card ID.
        /// </summary>
        /// <value>The card ID.</value>
        public String CardID {
            get {
                return this._cardId;
            }
            set {
                this._cardId = value;
            }
        }

        /// <summary>
        /// Gets or sets the deck this card is in.
        /// </summary>
        /// <value>The deck.</value>
        public Deck Deck {
            get {
                return this._deck;
            }
            set {
                this._deck = value;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HoboTacticsCodeTest.Cards.Card"/> class.
        /// </summary>
        /// <param name="cardId">Card identifier.</param>
        public Card (String cardId)
        {
            this._cardId = cardId;
        }
    }
}

