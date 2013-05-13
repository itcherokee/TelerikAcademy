using Poker;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestPoker
{


    /// <summary>
    ///This is a test class for CardTest and is intended
    ///to contain all CardTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CardTest
    {
        /// <summary>
        ///A test for ToString - Ace ♣
        ///</summary>
        [TestMethod()]
        public void ToStringAceClubsTest()
        {
            CardFace face = new CardFace();
            face = CardFace.Ace;
            CardSuit suit = new CardSuit();
            suit = CardSuit.Clubs;
            Card target = new Card(face, suit);
            string actual = target.ToString();
            string expected = string.Format("{0} {1}", CardFace.Ace, (char)5 + "");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString - Ace ♦
        ///</summary>
        [TestMethod()]
        public void ToStringAceDiamondsTest()
        {
            CardFace face = new CardFace();
            face = CardFace.Ace;
            CardSuit suit = new CardSuit();
            suit = CardSuit.Diamonds;
            Card target = new Card(face, suit);
            string actual = target.ToString();
            string expected = string.Format("{0} {1}", CardFace.Ace, (char)4 + "");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString - Ace ♥
        ///</summary>
        [TestMethod()]
        public void ToStringAceHeartsTest()
        {
            CardFace face = new CardFace();
            face = CardFace.Ace;
            CardSuit suit = new CardSuit();
            suit = CardSuit.Hearts;
            Card target = new Card(face, suit);
            string actual = target.ToString();
            string expected = string.Format("{0} {1}", CardFace.Ace, (char)3 + "");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for ToString - Ace ♠
        ///</summary>
        [TestMethod()]
        public void ToStringAceSpadesTest()
        {
            CardFace face = new CardFace();
            face = CardFace.Ace;
            CardSuit suit = new CardSuit();
            suit = CardSuit.Spades;
            Card target = new Card(face, suit);
            string actual = target.ToString();
            string expected = string.Format("{0} {1}", CardFace.Ace, (char)6 + "");
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        ///A test for Card Constructor - Suit assign test
        ///</summary>
        [TestMethod()]
        public void CardConstructorSuitTest()
        {
            CardFace face = new CardFace();
            face = CardFace.Jack;
            CardSuit suit = new CardSuit();
            suit = CardSuit.Hearts;
            Card target = new Card(face, suit);
            Assert.AreEqual(CardSuit.Hearts, target.Suit);
        }

        /// <summary>
        ///A test for Card Constructor - Face assign test
        ///</summary>
        [TestMethod()]
        public void CardConstructorFaceTest()
        {
            CardFace face = new CardFace();
            face = CardFace.Jack;
            CardSuit suit = new CardSuit();
            suit = CardSuit.Hearts;
            Card target = new Card(face, suit);
            Assert.AreEqual(CardFace.Jack, target.Face);
        }
    }
}
