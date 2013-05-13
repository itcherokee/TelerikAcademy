using System;

namespace Poker
{
    public class Card : ICard
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
    }
}
