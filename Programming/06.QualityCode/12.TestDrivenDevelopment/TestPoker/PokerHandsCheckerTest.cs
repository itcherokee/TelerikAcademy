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
        ///A test for IsTwoPair - Trivial
        ///</summary>
        [TestMethod()]
        public void IsTwoPairTrivialTest()
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
            bool actual = target.IsTwoPair(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsThreeOfAKind - trivial
        ///</summary>
        [TestMethod()]
        public void IsThreeOfAKindTrivialTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsThreeOfAKind(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsThreeOfAKind - only two of a kind
        ///</summary>
        [TestMethod()]
        public void IsThreeOfAKindOnlyTwoOFAKindTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Four, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsThreeOfAKind(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsThreeOfAKind - five of equal suit
        ///</summary>
        [TestMethod()]
        public void IsThreeOfAKindFiveOfEqualSuitTest()
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
            bool actual = target.IsThreeOfAKind(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsStraightFlush - Trivial
        ///</summary>
        [TestMethod()]
        public void IsStraightFlushTrivialTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsStraightFlush(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsStraightFlush - not a stright flush
        ///</summary>
        [TestMethod()]
        public void IsStraightFlushNotAStrightFlushTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsStraightFlush(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsStraight - Trivial
        ///</summary>
        [TestMethod()]
        public void IsStraightTrivialTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsStraight(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsStraight - Not a stright
        ///</summary>
        [TestMethod()]
        public void IsStraightNotAStrightTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Clubs)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsStraight(hand);
            Assert.IsFalse(actual);
        }

        /// <summary>
        ///A test for IsOnePair - trivial
        ///</summary>
        [TestMethod()]
        public void IsOnePairTrivialTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Two, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsOnePair(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsHighCard
        ///</summary>
        [TestMethod()]
        public void IsHighCardTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsHighCard(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsFullHouse - trivial
        ///</summary>
        [TestMethod()]
        public void IsFullHouseTrivialTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsFullHouse(hand);
            Assert.IsTrue(actual);
        }

        /// <summary>
        ///A test for IsFullHouse - not a fullhouse
        ///</summary>
        [TestMethod()]
        public void IsFullHouseNotAFullHouseTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            List<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Spades),
                new Card(CardFace.Queen, CardSuit.Spades)
            };
            Hand hand = new Hand(cards);
            bool actual = target.IsFullHouse(hand);
            Assert.IsFalse(actual);
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
