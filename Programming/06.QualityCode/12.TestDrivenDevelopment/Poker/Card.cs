namespace Poker
{
    using System;

    public class Card : ICard, IComparable<Card>, IComparable
    {
        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public CardFace Face { get; private set; }

        public CardSuit Suit { get; private set; }

        /// <summary>
        /// Format Card instance state as an string representation.
        /// </summary>
        /// <returns>Sting representation of current instance of Card class.</returns>
        public override string ToString()
        {
            char suit = default(char);
            switch (this.Suit)
            {
                case CardSuit.Clubs:
                    suit = (char)5;
                    break;
                case CardSuit.Diamonds:
                    suit = (char)4;
                    break;
                case CardSuit.Hearts:
                    suit = (char)3;
                    break;
                case CardSuit.Spades:
                    suit = (char)6;
                    break;
            }

            return string.Format("{0} {1}", this.Face, suit);
        }

        /// <summary>
        /// Compare cards by Face in descending order.
        /// </summary>
        /// <param name="card">Card that is going to be compared to current card object.</param>
        /// <returns>Returns -1, 0 1 depending on position of card that is compared to card in <paramref name="card"/></returns>
        public int CompareTo(Card card)
        {
            int result = 0;
            if (this.Face.CompareTo(card.Face) < 0)
            {
                result = 1;
            }
            else if (this.Face.CompareTo(card.Face) > 0)
            {
                result = -1;
            }
            else
            {
                result = 0;
            }

            return result;
        }

        public int CompareTo(object obj)
        {
            int result = 0;
            var card = (Card)obj;
            if (this.Face.CompareTo(card.Face) < 0)
            {
                result = 1;
            }
            else if (this.Face.CompareTo(card.Face) > 0)
            {
                result = -1;
            }
            else
            {
                result = 0;
            }

            return result;
        }
    }
}
