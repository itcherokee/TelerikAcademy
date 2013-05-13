using System;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            bool result = true;
            if (hand.Cards.Count == 5)
            {
                for (int outer = 0; outer < hand.Cards.Count; outer++)
                {
                    for (int inner = outer + 1; inner < hand.Cards.Count; inner++)
                    {
                        if (hand.Cards[outer].Face == hand.Cards[inner].Face)
                        {
                            if (hand.Cards[outer].Suit == hand.Cards[inner].Suit)
                            {
                                result = false;
                            }
                        }
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool IsStraightFlush(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFourOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFullHouse(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsFlush(IHand hand)
        {
            // пет карти от една боя, но не е задължително да са поредни - до 4 поредни може, иначе е StrightFlush или RoyalFlush. 
            bool result = true;
            for (int outer = 0; outer < hand.Cards.Count; outer++)
            {
                for (int inner = outer + 1; inner < hand.Cards.Count; inner++)
                {
                    if (hand.Cards[outer].Suit != hand.Cards[inner].Suit)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        public bool IsStraight(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsTwoPair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsOnePair(IHand hand)
        {
            throw new NotImplementedException();
        }

        public bool IsHighCard(IHand hand)
        {
            throw new NotImplementedException();
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            throw new NotImplementedException();
        }
    }
}
