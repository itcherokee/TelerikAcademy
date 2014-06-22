namespace Poker
{
    using System;
    using System.Collections.Generic;

    public class PokerExample
    {
        public static void Main()
        {
            ICard card = new Card(CardFace.Ace, CardSuit.Clubs);
            Console.WriteLine("Card - {0}", card);

            IHand hand = new Hand(new List<ICard>() 
            { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            Console.WriteLine("Hand - {0}", hand);

            IPokerHandsChecker checker = new PokerHandsChecker();
            Console.WriteLine("Is it valid hand: {0}", checker.IsValidHand(hand));

            Console.WriteLine("\nIt's possibel one hand to be detected as couple of types");
            Console.WriteLine("but always less powerfull than the higher detected type!");
            Console.WriteLine("(for example TwoPair is also detectable as OnePair - it is!)\n");

            Console.WriteLine("Is it OnePair: {0}", checker.IsOnePair(hand));
            Console.WriteLine("Is it FullHouse: {0}", checker.IsFullHouse(hand));
            Console.WriteLine("Is it Straight: {0}", checker.IsStraight(hand));
            Console.WriteLine("Is it StraightFlush: {0}", checker.IsStraightFlush(hand));
            Console.WriteLine("Is it HighCard: {0}", checker.IsHighCard(hand));
            Console.WriteLine("Is it TwoPair: {0}", checker.IsTwoPair(hand));
            Console.ReadKey();
        }
    }
}
