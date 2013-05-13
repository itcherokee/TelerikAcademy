using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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
        ///A test for IsValidHand
        ///</summary>
        [TestMethod()]
        public void IsValidHandTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsValidHand(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
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
        ///A test for IsStraightFlush
        ///</summary>
        [TestMethod()]
        public void IsStraightFlushTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsStraightFlush(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
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
        ///A test for IsFourOfAKind
        ///</summary>
        [TestMethod()]
        public void IsFourOfAKindTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsFourOfAKind(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsFlush
        ///</summary>
        [TestMethod()]
        public void IsFlushTest()
        {
            PokerHandsChecker target = new PokerHandsChecker(); // TODO: Initialize to an appropriate value
            IHand hand = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.IsFlush(hand);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
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

        /// <summary>
        ///A test for PokerHandsChecker Constructor
        ///</summary>
        [TestMethod()]
        public void PokerHandsCheckerConstructorTest()
        {
            PokerHandsChecker target = new PokerHandsChecker();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }
    }
}
