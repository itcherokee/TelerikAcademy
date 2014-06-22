namespace TestPoker
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    /// <summary>
    /// This is a test class for HandTest and is intended
    /// to contain all HandTest Unit Tests
    /// </summary>
    [TestClass]
    public class HandTest
    {
        /// <summary>
        /// A test for Hand Constructor
        /// </summary>
        [TestMethod]
        public void HandConstructor()
        {
            Hand target = new Hand(this.LoadSomeCards());
            int actual = target.Cards.Count;
            Assert.AreEqual(5, actual);
        }

        /// <summary>
        /// A test for Hand Constructor = null value
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HandConstructorNullValue()
        {
            var target = new Hand(null);
        }

        /// <summary>
        /// A test for ToString
        /// </summary>
        [TestMethod]
        public void HandToString()
        {
            var target = new Hand(this.LoadSomeCards());
            string expected = "Ace " + (char)5 + " / Ace " + (char)4 + " / King " + (char)3 + " / King " + (char)6 + " / Seven " + (char)4;
            string actual = target.ToString();
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Load some predefined cards.
        /// </summary>
        /// <returns>Static pre-defined hand list of cards.</returns>
        private IList<ICard> LoadSomeCards()
        {
            return new List<ICard>
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            };
        }
    }
}