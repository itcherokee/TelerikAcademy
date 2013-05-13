using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestPoker
{
        /// <summary>
    ///This is a test class for PokerHandsCheckerTest and is intended
    ///to contain all PokerHandsCheckerTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PokerHandsCheckerTest
    {
        /// <summary>
        ///A test for IsValidHand - Five cards
        ///</summary>
        [TestMethod()]
        public void IsValidHandFiveCardsTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsValidHand(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsValidHand - Zero cards
        ///</summary>
        [TestMethod()]
        public void IsValidHandZeroCardsTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>();
            Hand hand = new Hand(cards);
            bool actual = target.IsValidHand(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsValidHand - Six cards
        ///</summary>
        [TestMethod()]
        public void IsValidHandSixCardsTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Seven, CardSuit.Spades)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsValidHand(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsValidHand - Two identical cards in the hand
        ///</summary>
        [TestMethod()]
        public void IsValidHandTwoIdenticalCardsTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsValidHand(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsTwoPair
        ///</summary>
        [TestMethod()]
        public void IsTwoPairTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsTwoPair(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsThreeOfAKind
        ///</summary>
        [TestMethod()]
        public void IsThreeOfAKindTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsThreeOfAKind(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsStraightFlush - Trivial
        ///</summary>
        [TestMethod()]
        public void IsStraightFlushTrivialTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsStraightFlush(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsStraight
        ///</summary>
        [TestMethod()]
        public void IsStraightTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsStraight(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsOnePair
        ///</summary>
        [TestMethod()]
        public void IsOnePairTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsOnePair(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsHighCard
        ///</summary>
        [TestMethod()]
        public void IsHighCardTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsHighCard(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsFullHouse
        ///</summary>
        [TestMethod()]
        public void IsFullHouseTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsFullHouse(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsFourOfAKind - Trivial.
        ///</summary>
        [TestMethod()]
        public void IsFourOfAKindTrivialTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Two, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsFourOfAKind(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsFourOfAKind - Only three of a kind.
        ///</summary>
        [TestMethod()]
        public void IsFourOfAKindOnlyThreeOfAKindTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsFourOfAKind(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsFourOfAKind - Five of equal suit.
        ///</summary>
        [TestMethod()]
        public void IsFourOfAKindFiveOfEqualSuitTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsFourOfAKind(hand);
            Assert.IsFalse(actual);
        }


        /// <summary>
        ///A test for IsFlush - Trivial
        ///</summary>
        [TestMethod()]
        public void IsFlushTrivialTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsFlush(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsFlush - Different suits
        ///</summary>
        [TestMethod()]
        public void IsFlushTwoDifferentSuitsTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsFlush(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for CompareHands
        ///</summary>
        [TestMethod()]
        public void CompareHandsTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand firstHand = null; // TODO: Initialize to an appropriate value
            IHand secondHand = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CompareHands(firstHand, secondHand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
