using System;

class BonusSystem
{
    static void Main()
    {
        //Write a program that applies bonus scores to given scores in the range [1..9].
        //The program reads a digit as an input. If the digit is between 1 and 3, the program 
        //multiplies it by 10; if it is between 4 and 6, multiplies it by 100; if it is 
        //between 7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit, 
        //the program must report an error. Use a switch statement and at the end print 
        //the calculated new value in the console.
        string inputValue = "";
        bool wrongScore = false;
        Console.Title = "Bonus System";
        do
        {
            Console.Write("Type your score [1..9] in order to see the total score (+bonus): ");
            inputValue = Console.ReadLine();
            switch (inputValue)
            {
                case "1":
                case "2":
                case "3":
                    CheckCalcAndPrint(inputValue, 10);
                    wrongScore = false;
                    break;
                case "4":
                case "5":
                case "6":
                    CheckCalcAndPrint(inputValue, 100);
                    wrongScore = false;
                    break;
                case "7":
                case "8":
                case "9":
                    CheckCalcAndPrint(inputValue, 1000);
                    wrongScore = false;
                    break;
                default:
                    Console.WriteLine("There is no such possible score, please try again. Press a key...");
                    Console.ReadKey();
                    Console.Clear();
                    wrongScore = true;
                    break;
            }
        } while (wrongScore);
    }

    static void CheckCalcAndPrint(string initialValue, int multiplier)
    {
        bool wrongInput = true;
        int initialScore = 0;
        int finalScore = 0;
        do
        {
            wrongInput = int.TryParse(initialValue, out initialScore);
            finalScore = initialScore * multiplier;
        } while (!wrongInput);
        Console.WriteLine("Entered score = {0}, final score = {1} (bonus = {2})", initialScore, finalScore, finalScore - initialScore);
    }
}