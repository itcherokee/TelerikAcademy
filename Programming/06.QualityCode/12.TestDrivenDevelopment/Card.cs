using System;

namespace Poker
{
    public class Card : ICard, IComparable<Card>, IComparable
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string suit = string.Empty;
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    suit = (char)5 + "";
                    break;
                case CardSuit.Diamonds:
                    suit = (char)4 + "";
                    break;
                case CardSuit.Hearts:
                    suit = (char)3 + "";
                    break;
                case CardSuit.Spades:
                    suit = (char)6 + "";
                    break;
            }

            return string.Format("{0} {1}", this.Face, suit);
        }


        /// <summary>
        /// Compare cards by Face in descending order.
        /// </summary>
        /// <param name="card">Card that is going to be compared to current card object.</param>
        /// <returns>Returns -1, 0 1 depending on position of card that is compared to card in <paramref name="obj"/></returns>
        public int CompareTo(Card card)
        {
            if (this.Face.CompareTo(card.Face) < 0)
            {
                return 1;
            }
            else if (this.Face.CompareTo(card.Face) > 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
        
        public int CompareTo(object obj)
        {
            Card card = (Card)obj;
            if (this.Face.CompareTo(card.Face) < 0)
            {
                return 1;
            }
            else if (this.Face.CompareTo(card.Face) > 0)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
