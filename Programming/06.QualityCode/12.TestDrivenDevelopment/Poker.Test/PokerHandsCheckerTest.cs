namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    /// <summary>
    /// This is a test class for PokerHandsCheckerTest and is intended
    /// to contain all PokerHandsCheckerTest Unit Tests
    /// </summary>
    [TestClass]
    public class PokerHandsCheckerTest
    {
        #region Task_3_Is_Valid_Hand

        /// <summary>
        /// A test for IsValidHand - Five cards
        /// </summary>
        [TestMethod]
        public void PokerHandsIsValidHandFiveCards()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsValidHand(this.GenerateFlushHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsValidHand - Zero cards
        /// </summary>
        [TestMethod]
        public void PokerHandsIsValidHandZeroCards()
        {
            var target = new PokerHandsChecker();
            var hand = new Hand(new List<ICard>());
            bool actual = target.IsValidHand(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsValidHand - Six cards
        /// </summary>
        [TestMethod]
        public void PokerHandsIsValidHandSixCards()
        {
            var target = new PokerHandsChecker();
            var cards = this.GenerateFlushHand();
            cards.Cards.Add(new Card(CardFace.Two, CardSuit.Hearts));
            bool actual = target.IsValidHand(cards);
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsValidHand - Two identical cards in the hand
        /// </summary>
        [TestMethod]
        public void PokerHandsIsValidHandTwoIdenticalCards()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsValidHand(this.GenerateInvalidHand());
            Assert.IsFalse(actual);
        }

        #endregion

        #region Task_4_Is_Flush

        /// <summary>
        /// A test for IsFlush - Trivial
        /// </summary>
        [TestMethod]
        public void PokerHandsIsFlushTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsFlush(this.GenerateFlushHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsFlush - Different suits
        /// </summary>
        [TestMethod]
        public void PokerHandsIsFlushTwoDifferentSuits()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsFlush(this.GenerateHighCardHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsFlush - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsFlushInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsFlush(hand);
        }

        #endregion

        #region Task_5_Is_Four_Of_a_Kind

        /// <summary>
        /// A test for IsFourOfAKind - Trivial.
        /// </summary>
        [TestMethod]
        public void PokerHandsIsFourOfAKindTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsFourOfAKind(this.GeneratefourOfKindHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsFourOfAKind - Only three of a kind.
        /// </summary>
        [TestMethod]
        public void PokerHandsIsFourOfAKindOnlyThreeOfAKind()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsFourOfAKind(this.GenerateThreeOfaKindHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsFourOfAKind - Only three of a kind.
        /// </summary>
        [TestMethod]
        public void PokerHandsIsFourOfAKindFullHouse()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsFourOfAKind(this.GenerateFullHouseHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsFourOfAKind - Five of equal suit.
        /// </summary>
        [TestMethod]
        public void PokerHandsIsFourOfAKindFiveOfEqualSuit()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsFourOfAKind(this.GenerateStraightFlushHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsFourOfAKind - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsFourOfAKindInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsFourOfAKind(hand);
        }

        #endregion

        #region Task_6_Rest_Of_Hands_Type

        // IS HIGHCARD Tests

        /// <summary>
        /// A test for IsHighCard - real High Card Hand
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GenerateHighCardHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsHighCard - no HighCard (StraightFlush)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardStraightFlush()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GenerateStraightFlushHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsHighCard - no HighCard (Four of a kind)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardFourOfAKind()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GeneratefourOfKindHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsHighCard - no HighCard (FullHouse)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardFullHouse()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GenerateFullHouseHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsHighCard - no HighCard (Flush)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardFlush()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GenerateFlushHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsHighCard - no HighCard (Straight)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardStraight()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GenerateStraighthHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsHighCard - no HighCard (ThreeOfKind)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardThreeOfaKind()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GenerateThreeOfaKindHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsHighCard - no HighCard (TwoPairs)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardTwoPairs()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GenerateTwoPairHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsHighCard - no HighCard (OnePairs)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsHighCardOnePair()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsHighCard(this.GenerateOnePairHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsHighCard - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsHighCardInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsHighCard(hand);
        }

        // ONE PAIR Tests 

        /// <summary>
        /// A test for IsOnePair - real one pair
        /// </summary>
        [TestMethod]
        public void PokerHandsIsOnePairTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsOnePair(this.GenerateOnePairHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsOnePair - no pairs
        /// </summary>
        [TestMethod]
        public void PokerHandsIsOnePairNoPairs()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsOnePair(this.GenerateHighCardHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsOnePair - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsOnePairInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsOnePair(hand);
        }

        // TWO PAIR Tests

        /// <summary>
        /// A test for IsTwoPair - two pairs
        /// </summary>
        [TestMethod]
        public void PokerHandsIsTwoPairTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsTwoPair(this.GenerateTwoPairHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsTwoPair - two pairs (second)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsTwoPairTrivialSecond()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsTwoPair(this.GenerateTwoPairHandSecond());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsTwoPair - two pairs
        /// </summary>
        [TestMethod]
        public void PokerHandsIsTwoPairOnePair()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsTwoPair(this.GenerateOnePairHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsTwoPair - no pairs
        /// </summary>
        [TestMethod]
        public void PokerHandsIsTwoPairNoPairs()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsTwoPair(this.GenerateHighCardHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsTwoPair - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsTwoPairInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsTwoPair(hand);
        }

        // THREE OF A KIND Tests

        /// <summary>
        /// A test for IsThreeOfAKind - real three of a kind
        /// </summary>
        [TestMethod]
        public void PokerHandsIsThreeOfAKindTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsThreeOfAKind(this.GenerateThreeOfaKindHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsThreeOfAKind - only two of a kind
        /// </summary>
        [TestMethod]
        public void PokerHandsIsThreeOfAKindOnlyTwoOFaKind()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsThreeOfAKind(this.GenerateOnePairHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsThreeOfAKind - five of equal suit
        /// </summary>
        [TestMethod]
        public void PokerHandsIsThreeOfAKindFiveOfEqualSuit()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsThreeOfAKind(this.GenerateStraightFlushHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsThreeOfAKind - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsThreeOfAKindInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsThreeOfAKind(hand);
        }

        // FULL HOUSE Tests

        /// <summary>
        /// A test for IsFullHouse - real FullHouse
        /// </summary>
        [TestMethod]
        public void PokerHandsIsFullHouseTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsFullHouse(this.GenerateFullHouseHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsFullHouse - not a FullHouse (two pairs)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsFullHouseNotAFullHouse()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsFullHouse(this.GenerateTwoPairHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsFullHouse - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsFullHouseInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsFullHouse(hand);
        }

        // STRAIGHT Tests

        /// <summary>
        /// A test for IsStraight - real Straight
        /// </summary>
        [TestMethod]
        public void PokerHandsIsStraightTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsStraight(this.GenerateStraighthHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsStraight - Not a Straight (StraightFlush)
        /// </summary>
        [TestMethod]
        public void PokerHandsIsStraightNotAStright()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsStraight(this.GenerateStraightFlushHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsStraight - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsStraightInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsStraight(hand);
        }

        // STRAIGHTFLUSH Tests

        /// <summary>
        /// A test for IsStraightFlush - real StraightFlush
        /// </summary>
        [TestMethod]
        public void PokerHandsIsStraightFlushTrivial()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsStraightFlush(this.GenerateStraightFlushHand());
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// A test for IsStraightFlush - StraightFlush
        /// </summary>
        [TestMethod]
        public void PokerHandsIsStraightFlushNotAStrightFlush()
        {
            var target = new PokerHandsChecker();
            bool actual = target.IsStraightFlush(this.GenerateStraighthHand());
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// A test for IsStraightFlush - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsIsStraightFlushInvalidHand()
        {
            var target = new PokerHandsChecker();
            var hand = this.GenerateInvalidHand();
            bool actual = target.IsStraightFlush(hand);
        }

        #endregion

        #region Task_7_Compare_Hands

        /// <summary>
        /// A test for CompareHands - StraightFlush versus FourOfKind
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsStraightFlushAndFourOfAKind()
        {
            var target = new PokerHandsChecker();
            var straightFlushHand = this.GenerateStraightFlushHand();
            var fourOfKindHand = this.GeneratefourOfKindHand();
            int expected = -1;
            int actual = target.CompareHands(straightFlushHand, fourOfKindHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - FullHouse versus TwoPair
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsFullHouseAndTwoPair()
        {
            var target = new PokerHandsChecker();
            var fullHouseHand = this.GenerateFullHouseHand();
            var twoPairHand = this.GenerateTwoPairHand();
            int expected = -1;
            int actual = target.CompareHands(fullHouseHand, twoPairHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - ThreeOfKind versus Flush
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsThreeOfAKindAndFlush()
        {
            var target = new PokerHandsChecker();
            var threeOfKind = this.GenerateThreeOfaKindHand();
            var flushHand = this.GenerateFlushHand();
            int expected = 1;
            int actual = target.CompareHands(threeOfKind, flushHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - ThreeOfKind versus HighCard
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsThreeOfAKindAndHighCard()
        {
            var target = new PokerHandsChecker();
            var threeOfKind = this.GenerateThreeOfaKindHand();
            var highCardHand = this.GenerateHighCardHand();
            int expected = -1;
            int actual = target.CompareHands(threeOfKind, highCardHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - StraightFlush versus Straight
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsStraightFlushAndStraight()
        {
            var target = new PokerHandsChecker();
            var straightFlushHand = this.GenerateStraightFlushHand();
            var straightHand = this.GenerateStraighthHand();
            int expected = -1;
            int actual = target.CompareHands(straightFlushHand, straightHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - StraightFlush versus StraightFlush (same cards - not possible in real life)
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsStraightFlushAndStraightFlushSame()
        {
            var target = new PokerHandsChecker();
            var straightFlushOneHand = this.GenerateStraightFlushHand();
            var straightFlushTwoHand = this.GenerateStraightFlushHand();
            int expected = 0;
            int actual = target.CompareHands(straightFlushOneHand, straightFlushTwoHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - StraightFlush versus StraightFlush (different cards - one direction)
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsStraightFlushAndStraightFlushLeft()
        {
            var target = new PokerHandsChecker();
            var straightFlushOneHand = this.GenerateStraightFlushHand();
            var straightFlushTwoHand = this.GenerateStraightFlushHandAdditional();
            int expected = 1;
            int actual = target.CompareHands(straightFlushOneHand, straightFlushTwoHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - StraightFlush versus StraightFlush (different cards - other direction)
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsStraightFlushAndStraightFlushRight()
        {
            var target = new PokerHandsChecker();
            var straightFlushOneHand = this.GenerateStraightFlushHand();
            var straightFlushTwoHand = this.GenerateStraightFlushHandAdditional();
            int expected = -1;
            int actual = target.CompareHands(straightFlushTwoHand, straightFlushOneHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - OnePair versus Straight
        /// </summary>
        [TestMethod]
        public void PokerHandsCompareHandsOnePairAndStraightFlush()
        {
            var target = new PokerHandsChecker();
            var onePairHand = this.GenerateOnePairHand();
            var straightFlushHand = this.GenerateStraightFlushHand();
            int expected = 1;
            int actual = target.CompareHands(onePairHand, straightFlushHand);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for CompareHands - invalid hand
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsCompareHandsInvalidHand()
        {
            var target = new PokerHandsChecker();
            var onePairHand = this.GenerateOnePairHand();
            var invalidHand = this.GenerateInvalidHand();
            target.CompareHands(onePairHand, invalidHand);
        }

        /// <summary>
        /// A test for CompareHands - both invalid hands
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void PokerHandsCompareHandsInvalidHands()
        {
            var target = new PokerHandsChecker();
            var onePairHand = this.GenerateInvalidHand();
            var invalidHand = this.GenerateInvalidHand();
            target.CompareHands(onePairHand, invalidHand);
        }

        #endregion

        #region Generators_of_Hands

        /// <summary>
        /// Creates predefined invalid hand - two duplicated cards.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateInvalidHand()
        {
            var target = new PokerHandsChecker();
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - Flush.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateFlushHand()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - ThreeOfKind.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateThreeOfaKindHand()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - FourOfKind.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GeneratefourOfKindHand()
        {
            var cards = new List<ICard>()
            { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - FullHouse.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateFullHouseHand()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - StraightFlush.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateStraightFlushHand()
        {
            var cards = new List<ICard>()
            { 
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - StraightFlush (Second).
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateStraightFlushHandAdditional()
        {
            var cards = new List<ICard>()
            { 
                new Card(CardFace.King, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Diamonds)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - Straight.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateStraighthHand()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Nine, CardSuit.Spades),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades),
                new Card(CardFace.Six, CardSuit.Hearts),
                new Card(CardFace.Five, CardSuit.Clubs)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - TwoPair.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateTwoPairHand()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Hearts)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - TwoPair (second).
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateTwoPairHandSecond()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - OnePair.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateOnePairHand()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Six, CardSuit.Clubs)
            };
            return new Hand(cards);
        }

        /// <summary>
        /// Creates predefined hand - HighCard.
        /// </summary>
        /// <returns>Hand of cards.</returns>
        private IHand GenerateHighCardHand()
        {
            var cards = new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Diamonds)
            };
            return new Hand(cards);
        }

        #endregion
    }
}
