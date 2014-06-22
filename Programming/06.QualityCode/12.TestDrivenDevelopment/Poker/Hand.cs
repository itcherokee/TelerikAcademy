namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Hand : IHand
    {
        private IList<ICard> cards;

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public IList<ICard> Cards
        {
            get
            {
                return this.cards;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Hand can not be null!");
                }

                this.cards = value;
            }
        }

        public override string ToString()
        {
            var result = new StringBuilder();
            int cardCount = this.Cards.Count;
            for (int index = 0; index < cardCount; index++)
            {
                result.Append(this.Cards[index].ToString());
                if (index < cardCount - 1)
                {
                    result.Append(" / ");
                }
            }

            return result.ToString();
        }
    }
}
