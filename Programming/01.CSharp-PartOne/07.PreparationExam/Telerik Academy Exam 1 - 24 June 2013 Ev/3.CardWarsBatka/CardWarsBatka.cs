using System;
using System.Linq;
using System.Numerics;

public class CardWarsBatka
{
    public static void Main()
    {
        byte playerOneGamesWon = 0;
        BigInteger playerOneScore = 0;
        int playerOneHandScore = 0;
        byte playerTwoGamesWon = 0;
        BigInteger playerTwoScore = 0;
        int playerTwoHandScore = 0;
        bool isPlayerOneWonGame = false;
        bool isPlayerTwoWonGame = false;
        string[] cards = new string[3];

        // User input
        int numberOfGames = int.Parse(Console.ReadLine());
        for (int handsIndex = 0; handsIndex < numberOfGames; handsIndex++)
        {
            // First player hand draw
            cards[0] = Console.ReadLine();
            cards[1] = Console.ReadLine();
            cards[2] = Console.ReadLine();
            if (cards.Contains("X"))
            {
                isPlayerOneWonGame = true;
            }

            if (cards.Contains("Y"))
            {
                for (int i = 0; i < 3; i++)
                {
                    playerOneScore += cards[i] == "Y" ? -200 : 0;
                }
            }

            if (cards.Contains("Z"))
            {
                for (int i = 0; i < 3; i++)
                {
                    playerOneScore *= cards[i] == "Z" ? 2 : 1;
                }
            }

            CalcHand(ref playerOneHandScore, cards);

            // Second player hand draw
            cards[0] = Console.ReadLine();
            cards[1] = Console.ReadLine();
            cards[2] = Console.ReadLine();
            if (cards.Contains("X"))
            {
                isPlayerTwoWonGame = true;
            }

            if (cards.Contains("Y"))
            {
                for (int i = 0; i < 3; i++)
                {
                    playerTwoScore += cards[i] == "Y" ? -200 : 0;
                }
            }

            if (cards.Contains("Z"))
            {
                for (int i = 0; i < 3; i++)
                {
                    playerTwoScore *= cards[i] == "Z" ? 2 : 1;
                }
            }

            CalcHand(ref playerTwoHandScore, cards);

            if (isPlayerOneWonGame || isPlayerTwoWonGame)
            {
                // Checks for 'X' card drawn situations
                if (isPlayerOneWonGame && isPlayerTwoWonGame)
                {
                    playerOneScore += 50;
                    playerTwoScore += 50;
                    isPlayerOneWonGame = false;
                    isPlayerTwoWonGame = false;
                }
                else if (isPlayerOneWonGame)
                {
                    Console.WriteLine("X card drawn! Player one wins the match!");
                    return;
                }
                else if (isPlayerTwoWonGame)
                {
                    Console.WriteLine("X card drawn! Player two wins the match!");
                    return;
                }
            }

            //// Calculates who is the winner in this game
            if (playerOneHandScore > playerTwoHandScore)
            {
                playerOneScore += playerOneHandScore;
                playerOneGamesWon++;
            }
            else if (playerOneHandScore < playerTwoHandScore)
            {
                playerTwoScore += playerTwoHandScore;
                playerTwoGamesWon++;
            }

            playerOneHandScore = 0;
            playerTwoHandScore = 0;
            isPlayerOneWonGame = false;
            isPlayerTwoWonGame = false;
        }

        // Calulates, who is the final winner of match of games
        if (playerOneScore == playerTwoScore)
        {
            Console.WriteLine("It's a tie!");
            Console.WriteLine("Score: {0}", playerOneScore);
        }
        else if (playerOneScore > playerTwoScore)
        {
            Console.WriteLine("First player wins!");
            Console.WriteLine("Score: {0}", playerOneScore);
            Console.WriteLine("Games won: {0}", playerOneGamesWon);
        }
        else if (playerOneScore < playerTwoScore)
        {
            Console.WriteLine("Second player wins!");
            Console.WriteLine("Score: {0}", playerTwoScore);
            Console.WriteLine("Games won: {0}", playerTwoGamesWon);
        }
    }

    // Calculates each player hand
    private static void CalcHand(ref int currentPlayerScore, params string[] hand)
    {
        int cardValue = 0;
        for (int cardsIndex = 0; cardsIndex < 3; cardsIndex++)
        {
            switch (hand[cardsIndex])
            {
                case "2":
                    cardValue = 10;
                    break;
                case "3":
                    cardValue = 9;
                    break;
                case "4":
                    cardValue = 8;
                    break;
                case "5":
                    cardValue = 7;
                    break;
                case "6":
                    cardValue = 6;
                    break;
                case "7":
                    cardValue = 5;
                    break;
                case "8":
                    cardValue = 4;
                    break;
                case "9":
                    cardValue = 3;
                    break;
                case "10":
                    cardValue = 2;
                    break;
                case "A":
                    cardValue = 1;
                    break;
                case "J":
                    cardValue = 11;
                    break;
                case "Q":
                    cardValue = 12;
                    break;
                case "K":
                    cardValue = 13;
                    break;
            }

            currentPlayerScore += cardValue;
            cardValue = 0;
        }
    }
}