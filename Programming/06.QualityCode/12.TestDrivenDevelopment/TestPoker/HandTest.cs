using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestPoker
{


    /// <summary>
    ///This is a test class for HandTest and is intended
    ///to contain all HandTest Unit Tests
    ///</summary>
    [TestClass()]
    public class HandTest
    {
        /// <summary>
        ///A test for Hand Constructor
        ///</summary>
        [TestMethod()]
        public void HandConstructorTest()
        {
            IList<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            };
            Hand target = new Hand(cards);
            int actual = target.Cards.Count;
            Assert.AreEqual(5, actual);
        }

        /// <summary>
        ///A test for Hand Constructor = null value
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void HandConstructorNullValueTest()
        {
            Hand target = new Hand(null);
        }

        /// <summary>
        ///A test for ToString
        ///</summary>
        [TestMethod()]
        public void ToStringTest()
        {
            IList<ICard> cards = new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            };
            Hand target = new Hand(cards);
            string expected = "Ace " + (char)5 + " / Ace " + (char)4 + " / King " + (char)3 + " / King " + (char)6 + " / Seven " + (char)4;
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}

