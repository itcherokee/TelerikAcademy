namespace TestPoker
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;

    /// <summary>
    /// This is a test class for CardTest and is intended
    /// to contain all CardTest Unit Tests
    /// </summary>
    [TestClass]
    public class CardTest
    {
        /// <summary>
        /// A test for ToString - Ace ♣
        /// </summary>
        [TestMethod]
        public void CardToStringAceClubs()
        {
            var target = new Card(CardFace.Ace, CardSuit.Clubs);
            string actual = target.ToString();
            string expected = string.Format("{0} {1}", CardFace.Ace, (char)5 + string.Empty);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for ToString - Ace ♦
        /// </summary>
        [TestMethod]
        public void CardToStringAceDiamonds()
        {
            var target = new Card(CardFace.Ace, CardSuit.Diamonds);
            string actual = target.ToString();
            string expected = string.Format("{0} {1}", CardFace.Ace, (char)4 + string.Empty);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for ToString - Ace ♥
        /// </summary>
        [TestMethod]
        public void CardToStringAceHearts()
        {
            var target = new Card(CardFace.Ace, CardSuit.Hearts);
            string actual = target.ToString();
            string expected = string.Format("{0} {1}", CardFace.Ace, (char)3 + string.Empty);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for ToString - Ace ♠
        /// </summary>
        [TestMethod]
        public void CardToStringAceSpades()
        {
            var target = new Card(CardFace.Ace, CardSuit.Spades);
            string actual = target.ToString();
            string expected = string.Format("{0} {1}", CardFace.Ace, (char)6 + string.Empty);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for Card Constructor - Suit assign test
        /// </summary>
        [TestMethod]
        public void CardConstructorSuit()
        {
            var target = new Card(CardFace.Jack, CardSuit.Hearts);
            Assert.AreEqual(CardSuit.Hearts, target.Suit);
        }

        /// <summary>
        /// A test for Card Constructor - Face assign test
        /// </summary>
        [TestMethod]
        public void CardConstructorFace()
        {
            var target = new Card(CardFace.Jack, CardSuit.Hearts);
            Assert.AreEqual(CardFace.Jack, target.Face);
        }

        /// <summary>
        /// A test for CompareTo - cardOne lower / cardTwo higher
        /// </summary>
        [TestMethod]
        public void CardCompareLowerWithHigher()
        {
            var cardOne = new Card(CardFace.Jack, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.King, CardSuit.Hearts);
            int result = cardOne.CompareTo(cardTwo);
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// A test for CompareTo - cardOne higher / cardTwo lower
        /// </summary>
        [TestMethod]
        public void CardCompareHigherToLower()
        {
            var cardOne = new Card(CardFace.Jack, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Two, CardSuit.Hearts);
            int result = cardOne.CompareTo(cardTwo);
            Assert.AreEqual(-1, result);
        }

        /// <summary>
        /// A test for CompareTo - equal
        /// </summary>
        [TestMethod]
        public void CardCompareToEqual()
        {
            var cardOne = new Card(CardFace.Jack, CardSuit.Hearts);
            var cardTwo = new Card(CardFace.Jack, CardSuit.Hearts);
            int result = cardOne.CompareTo(cardTwo);
            Assert.AreEqual(0, result);
        }
    }
}
