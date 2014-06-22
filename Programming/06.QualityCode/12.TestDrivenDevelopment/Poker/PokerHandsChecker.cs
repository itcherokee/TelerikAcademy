namespace Poker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

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

        public bool IsFlush(IHand hand)
        {
            // 5 cards from same suit, but it is not necessary to be serial in face - up to 4 is OK, 
            // else it is a StrightFlush or RoyalFlush. But we check only for suit, because each StrightFlush 
            // or RoyalFlush is also kind of Flush.
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

            bool result = true;
            CardSuit firstCardSuit = hand.Cards[0].Suit;
            for (int i = 1; i < hand.Cards.Count; i++)
            {
                if (firstCardSuit != hand.Cards[i].Suit)
                {
                    result = false;
                }
            }

            return result;
        }

        public bool IsFourOfAKind(IHand hand)
        {
            // 4 cards with same face and different suit, no matter what is the last card.
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

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

                numberOfEqualCards = 1;
            }

            return false;
        }

        public bool IsHighCard(IHand hand)
        {
            // any 5 cards that do not follow any of the others hand requirements (garbage)
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

            if (this.IsStraightFlush(hand) || this.IsFourOfAKind(hand) || this.IsFullHouse(hand) ||
                this.IsFlush(hand) || this.IsStraight(hand) || this.IsThreeOfAKind(hand) ||
                this.IsTwoPair(hand) || this.IsOnePair(hand))
            {
                return false;
            }

            return true;
        }

        public bool IsOnePair(IHand hand)
        {
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

            return this.FindPairs(hand, 2);
        }

        public bool IsTwoPair(IHand hand)
        {
            // 2 by 2 cards from the same face per pair
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

            return this.FindPairs(hand, 2, 2);
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            // 3 cards from same face, no matter what are other two cards
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

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

                numberOfEqualCards = 1;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            // 2 by 3 cards from the same face per pair 
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

            return this.FindPairs(hand, 3, 2);
        }

        public bool IsStraight(IHand hand)
        {
            // 5 serial cards - suit is of no importance (if same suit -> StraightFlush)
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

            bool result = true;

            // Checks does cards are serial
            if (this.IsSerial(hand))
            {
                // check is there at least two suits
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

        public bool IsStraightFlush(IHand hand)
        {
            // 5 serial cards from one suit
            if (!this.IsValidHand(hand))
            {
                throw new ArgumentException("Invalid hand provided!");
            }

            return this.IsFlush(hand) && this.IsSerial(hand);
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            if (!this.IsValidHand(firstHand) || !this.IsValidHand(secondHand))
            {
                throw new ArgumentException("Invalid hand(s) provided!");
            }

            HandsPower firstHandType = this.DetectHand(firstHand);
            HandsPower secondHandType = this.DetectHand(secondHand);
            int result = 0;
            if (firstHandType < secondHandType)
            {
                result = 1;
            }
            else if (firstHandType > secondHandType)
            {
                result = -1;
            }
            else
            {
                int handOnePoints = this.CalculateHand(firstHand);
                int handTwoPoints = this.CalculateHand(secondHand);
                if (handOnePoints < handTwoPoints)
                {
                    result = 1;
                }
                else if (handOnePoints > handTwoPoints)
                {
                    result = -1;
                }
                else
                {
                    result = 0;
                }
            }

            return result;
        }

        // Helper Methods
        private bool FindPairs(IHand hand, int firstPairCount, int secondPairCount = 0)
        {
            var cardPairs = new Dictionary<CardFace, int>();
            foreach (var card in hand.Cards)
            {
                if (cardPairs.ContainsKey(card.Face))
                {
                    cardPairs[card.Face]++;
                }
                else
                {
                    cardPairs.Add(card.Face, 1);
                }
            }

            var sortedCardPairs = cardPairs.OrderByDescending(x => x.Value).Select(x => x.Value).ToArray();
            bool result = false;
            if (firstPairCount == sortedCardPairs[0])
            {
                if (secondPairCount != 0)
                {
                    result = secondPairCount == sortedCardPairs[1];
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

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
            int clubs = 0;
            int diamonds = 0;
            int hearts = 0;
            int spades = 0;
            List<ICard> currentHand = hand.Cards.ToList<ICard>();
            for (int index = 0; index < hand.Cards.Count; index++)
            {
                var currentCard = (Card)currentHand[index];
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

        private HandsPower DetectHand(IHand hand)
        {
            HandsPower handType;
            if (this.IsStraightFlush(hand))
            {
                handType = HandsPower.StraightFlush;
            }
            else if (this.IsFourOfAKind(hand))
            {
                handType = HandsPower.FourOfaKind;
            }
            else if (this.IsFullHouse(hand))
            {
                handType = HandsPower.FullHouse;
            }
            else if (this.IsFlush(hand))
            {
                handType = HandsPower.Flush;
            }
            else if (this.IsStraight(hand))
            {
                handType = HandsPower.Straight;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                handType = HandsPower.ThreeOfaKind;
            }
            else if (this.IsTwoPair(hand))
            {
                handType = HandsPower.TwoPair;
            }
            else if (this.IsOnePair(hand))
            {
                handType = HandsPower.OnePair;
            }
            else
            {
                handType = HandsPower.HighCard;
            }

            return handType;
        }

        private int CalculateHand(IHand hand)
        {
            int sum = 0;
            for (int i = 0; i < 5; i++)
            {
                sum += (int)hand.Cards[i].Face;
            }

            return sum;
        }
    }
}
