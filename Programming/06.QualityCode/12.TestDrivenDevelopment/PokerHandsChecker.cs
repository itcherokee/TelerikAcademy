using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        private bool IsSerial(IHand hand)
        {
            bool result = true;
            List<ICard> currentHand = hand.Cards.ToList<ICard>();
            currentHand.Sort();
            Card currentCard = (Card)currentHand[0];
            for (int index = 1; index < hand.Cards.Count; index++)
            {
                if (currentCard.Face - 1 != currentHand[index].Face)
                {
                    result = false;
                }

                currentCard = (Card)currentHand[index];
            }

            return result;
        }

        private int CountSuits(IHand hand)
        {
            int count = 0;
            int clubs = 0;
            int diamonds = 0;
            int hearts = 0;
            int spades = 0;
            List<ICard> currentHand = hand.Cards.ToList<ICard>();
            Card currentCard = null;
            for (int index = 0; index < hand.Cards.Count; index++)
            {
                currentCard = (Card)currentHand[index];
                switch (currentCard.Suit)
                {
                    case CardSuit.Clubs:
                        if (clubs == 0)
                        {
                            clubs = 1;
                        }
                        break;
                    case CardSuit.Diamonds:
                        if (diamonds == 0)
                        {
                            diamonds = 1;
                        }
                        break;
                    case CardSuit.Hearts:
                        if (hearts == 0)
                        {
                            hearts = 1;
                        }
                        break;
                    case CardSuit.Spades:
                        if (spades == 0)
                        {
                            spades = 1;
                        }
                        break;
                }
            }

            return clubs + diamonds + hearts + spades;
        }

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
            // пет карти от една боя, поредни
            bool result = true;
            if (this.IsFlush(hand))
            {
                result = this.IsSerial(hand);
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            // 4 еднотипни карти от различни бои без значение каква е последната карта
            int numberOfEqualCards = 1;
            for (int outer = 0; outer < 2; outer++)
            {
                for (int inner = outer + 1; inner < hand.Cards.Count; inner++)
                {
                    if (hand.Cards[outer].Face == hand.Cards[inner].Face)
                    {
                        numberOfEqualCards++;
                    }
                }

                if (numberOfEqualCards == 4)
                {
                    return true;
                }
                else
                {
                    numberOfEqualCards = 1;
                }
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            // 2 x 3 карти 
            List<ICard> currentHand = hand.Cards.ToList<ICard>();
            currentHand.Sort();
            bool result = true;
            Card currentCard = (Card)currentHand[0];
            int firstPair = 1;
            for (int index = 1; index < hand.Cards.Count; index++)
            {
                if (currentCard.Face == currentHand[index].Face)
                {
                    firstPair++;
                }
            }

            currentCard = (Card)currentHand[hand.Cards.Count - 1];
            int secondPair = 1;
            for (int index = hand.Cards.Count - 2; index > 1; index--)
            {
                if (currentCard.Face == currentHand[index].Face)
                {
                    secondPair++;
                }
            }

            if (firstPair + secondPair == 5)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool IsFlush(IHand hand)
        {
            // 5 карти от една боя, но не е задължително да са поредни - до 4 поредни може, иначе е StrightFlush или RoyalFlush. 
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
            // 5 поредни карти от поне 2 бои, боята не се ползва да  ги разделя

            bool result = true;
            // проверка дали са поредни
            if (this.IsSerial(hand))
            {
                // проверка дали са поне две бои
                if (this.CountSuits(hand) < 2)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            // 3 еднотипни карти от различни бои без значение какви са последните две карти
            int numberOfEqualCards = 1;
            for (int outer = 0; outer < 1; outer++)
            {
                for (int inner = outer + 1; inner < hand.Cards.Count; inner++)
                {
                    if (hand.Cards[outer].Face == hand.Cards[inner].Face)
                    {
                        numberOfEqualCards++;
                    }
                }

                if (numberOfEqualCards == 3)
                {
                    return true;
                }
                else
                {
                    numberOfEqualCards = 1;
                }
            }

            return false;
        }

        public bool IsTwoPair(IHand hand)
        {
            // 2 x 2

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
